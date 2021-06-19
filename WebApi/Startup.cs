using BL.AppServices;
using BL.Bases;
using BL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            //});

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddControllers();
            services.AddDbContext<ApplicationDBContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("Udacity"),
                    options => options.EnableRetryOnFailure());
            });
            services.AddIdentity<ApplicationStudentIdentity, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<UserManager<ApplicationStudentIdentity>>();
            services.AddTransient<RoleManager<IdentityRole>>();
            services.AddTransient<AccountAppService>();
            services.AddTransient<CourseAppService>();
            services.AddTransient<CategoryAppService>();
            services.AddTransient<CourseVideosAppService>();
            services.AddTransient<EnrollCourseAppService>();
            services.AddTransient<DragAndDropAppService>();
            services.AddTransient<LectureAppService>();
            services.AddTransient<LessonAppService>();
            services.AddTransient<LessonContentAppService>();
            services.AddTransient<QuestionAppService>();
            services.AddTransient<QuestionGroupAppService>();
            services.AddTransient<RoleAppService>();
            services.AddTransient<QuestionOptionsAppService>();
            services.AddTransient<StudentAnswerAppService>();
            services.AddTransient<TrueAndFalseAppService>();
            services.AddTransient<MentorOrInstractorStoriesAppService>();
            services.AddTransient<CountryAppService>();
            services.AddTransient<ConsultationAppService>();
            services.AddTransient<SubCategoryAppService>();
            services.AddTransient<StudentReviewsAppService>();
            services.AddTransient<StudentStoriesAppService>();
            services.AddTransient<PaymentAppService>();
            services.AddTransient<ProgressAppService>();
            services.AddTransient<WatchedAppService>();

            services.AddHttpContextAccessor();//allow me to get user information such as id
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            RoleAppService roleAppService, AccountAppService accountAppService)
        {
            //app.UseSwagger();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(
                options => options
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            // make uploaded images stored in the Resources folder 
            //  make Resources folder it servable as well
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // create custom roles 
            roleAppService.CreateRoles().Wait();
            // add custom first admin
            accountAppService.CreateFirstAdmin().Wait();
        }

    }
}
