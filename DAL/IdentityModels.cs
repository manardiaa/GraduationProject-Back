﻿using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class ApplicationStudentIdentity : IdentityUser
    {
        // public int Id { get; set; }
       // public string Name { get; set; }
       // public string Phone { get; set; }
        // public string Email { get; set; }
        public string countery { get; set; }
        public string Image { get; set; }
       // public string password { get; set; }
        public List<EnrollCourse> EnrollCourses { get; set; } = new List<EnrollCourse>();
    }

    public class ApplicationUserStore : UserStore<ApplicationStudentIdentity>
    {

        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }
    public class ApplicationDBContext : IdentityDbContext<ApplicationStudentIdentity>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Data Source=.;Initial Catalog=BDCore;Integrated Security=True"
               , options => options.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<lecture> lectures { get; set; }
        public DbSet<lesson> lessones { get; set; }
        public DbSet<lessonContent> lessonContents { get; set; }
        public DbSet<Question> Questiones { get; set; }
        public DbSet<QuestionGroup> QuestionGroupes { get; set; }
        public DbSet<QuestionOptions> QuestionOptiones { get; set; }
        public DbSet<TrueAndFalse> TrueAndFalses { get; set; }
        public DbSet<EnrollCourse> EnrollCourses { get; set; }
        public DbSet<CourseVideos> CourseVideos { get; set; }
        public DbSet<DragAndDrop> DragAndDrop { get; set; }
    }
}
