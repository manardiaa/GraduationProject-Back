using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.CreateTable(
        //        name: "AspNetRoles",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetRoles", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Category",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            CatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CatImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CatDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Category", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Consultation",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FristName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            OrganizationSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Consultation", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Country",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Country", x => x.id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetRoleClaims",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
        //                column: x => x.RoleId,
        //                principalTable: "AspNetRoles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SubCategory",
        //        columns: table => new
        //        {
        //            ID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            SubCategoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SubCategoryDescribtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CategoryID = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SubCategory", x => x.ID);
        //            table.ForeignKey(
        //                name: "FK_SubCategory_Category_CategoryID",
        //                column: x => x.CategoryID,
        //                principalTable: "Category",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MentorOrInstractorStories",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Specialzation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Story = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CountryID = table.Column<int>(type: "int", nullable: false),
        //            MemberType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ShowOrNot = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_MentorOrInstractorStories", x => x.id);
        //            table.ForeignKey(
        //                name: "FK_MentorOrInstractorStories_Country_CountryID",
        //                column: x => x.CountryID,
        //                principalTable: "Country",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Course",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Price = table.Column<float>(type: "real", nullable: false),
        //            Discount = table.Column<float>(type: "real", nullable: false),
        //            duration = table.Column<float>(type: "real", nullable: false),
        //            type = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            description = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            LectureNumber = table.Column<int>(type: "int", nullable: false),
        //            CategoryId = table.Column<int>(type: "int", nullable: false),
        //            SubCategoryId = table.Column<int>(type: "int", nullable: false),
        //            PartLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PreRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CrsLogo = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Course", x => x.id);
        //            table.ForeignKey(
        //                name: "FK_Course_Category_CategoryId",
        //                column: x => x.CategoryId,
        //                principalTable: "Category",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Course_SubCategory_SubCategoryId",
        //                column: x => x.SubCategoryId,
        //                principalTable: "SubCategory",
        //                principalColumn: "ID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUsers",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            countery = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            isDelete = table.Column<bool>(type: "bit", nullable: false),
        //            Courseid = table.Column<int>(type: "int", nullable: true),
        //            UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
        //            PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
        //            TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
        //            LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //            LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
        //            AccessFailedCount = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUsers", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AspNetUsers_Course_Courseid",
        //                column: x => x.Courseid,
        //                principalTable: "Course",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "lecture",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Tilte = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CourseId = table.Column<int>(type: "int", nullable: false),
        //            lessoneNumber = table.Column<int>(type: "int", nullable: false),
        //            LectureDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_lecture", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_lecture_Course_CourseId",
        //                column: x => x.CourseId,
        //                principalTable: "Course",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserClaims",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserLogins",
        //        columns: table => new
        //        {
        //            LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserRoles",
        //        columns: table => new
        //        {
        //            UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
        //                column: x => x.RoleId,
        //                principalTable: "AspNetRoles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserTokens",
        //        columns: table => new
        //        {
        //            UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EnrollCourse",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            EnrollDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            EndEnrollDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
        //            CourseId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EnrollCourse", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_EnrollCourse_AspNetUsers_StudentId",
        //                column: x => x.StudentId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_EnrollCourse_Course_CourseId",
        //                column: x => x.CourseId,
        //                principalTable: "Course",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Payment",
        //        columns: table => new
        //        {
        //            ID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
        //            ExperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            cvc = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
        //            ApplicationStudentIdentity_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Payment", x => x.ID);
        //            table.ForeignKey(
        //                name: "FK_Payment_AspNetUsers_ApplicationStudentIdentity_Id",
        //                column: x => x.ApplicationStudentIdentity_Id,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StudentReview",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Rate = table.Column<int>(type: "int", nullable: false),
        //            StdReviews = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            StudentID = table.Column<string>(type: "nvarchar(450)", nullable: true),
        //            ShowOrNot = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StudentReview", x => x.id);
        //            table.ForeignKey(
        //                name: "FK_StudentReview_AspNetUsers_StudentID",
        //                column: x => x.StudentID,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StudentStories",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Specialzation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Story = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
        //            ShowOrNot = table.Column<int>(type: "int", nullable: false),
        //            CategoryId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StudentStories", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_StudentStories_AspNetUsers_StudentId",
        //                column: x => x.StudentId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_StudentStories_Category_CategoryId",
        //                column: x => x.CategoryId,
        //                principalTable: "Category",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "lessones",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ContentNumber = table.Column<int>(type: "int", nullable: false),
        //            Duration = table.Column<float>(type: "real", nullable: false),
        //            LectureId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_lessones", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_lessones_lecture_LectureId",
        //                column: x => x.LectureId,
        //                principalTable: "lecture",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CourseVideos",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            LessonId = table.Column<int>(type: "int", nullable: false),
        //            CourseId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CourseVideos", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_CourseVideos_Course_CourseId",
        //                column: x => x.CourseId,
        //                principalTable: "Course",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_CourseVideos_lessones_LessonId",
        //                column: x => x.LessonId,
        //                principalTable: "lessones",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StudentAnswers",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Studentanswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            QuestionId = table.Column<int>(type: "int", nullable: false),
        //            StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StudentAnswers", x => x.id);
        //            table.ForeignKey(
        //                name: "FK_StudentAnswers_AspNetUsers_StudentId",
        //                column: x => x.StudentId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "QuestionGroupes",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            title = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            QGroupID = table.Column<int>(type: "int", nullable: false),
        //            LectureId = table.Column<int>(type: "int", nullable: false),
        //            CourseId = table.Column<int>(type: "int", nullable: false),
        //            LessonId = table.Column<int>(type: "int", nullable: false),
        //            LessonContentId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_QuestionGroupes", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_QuestionGroupes_Course_CourseId",
        //                column: x => x.CourseId,
        //                principalTable: "Course",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_QuestionGroupes_lecture_LectureId",
        //                column: x => x.LectureId,
        //                principalTable: "lecture",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_QuestionGroupes_lessones_LessonId",
        //                column: x => x.LessonId,
        //                principalTable: "lessones",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "lessonContents",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            VideoLinkId = table.Column<int>(type: "int", nullable: false),
        //            QuestionGroupId = table.Column<int>(type: "int", nullable: false),
        //            LessonId = table.Column<int>(type: "int", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_lessonContents", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_lessonContents_CourseVideos_VideoLinkId",
        //                column: x => x.VideoLinkId,
        //                principalTable: "CourseVideos",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_lessonContents_lessones_LessonId",
        //                column: x => x.LessonId,
        //                principalTable: "lessones",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_lessonContents_QuestionGroupes_QuestionGroupId",
        //                column: x => x.QuestionGroupId,
        //                principalTable: "QuestionGroupes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Questiones",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            QuestionGroupId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Questiones", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Questiones_QuestionGroupes_QuestionGroupId",
        //                column: x => x.QuestionGroupId,
        //                principalTable: "QuestionGroupes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DragAndDrop",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RightAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            QustionId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DragAndDrop", x => x.id);
        //            table.ForeignKey(
        //                name: "FK_DragAndDrop_Questiones_QustionId",
        //                column: x => x.QustionId,
        //                principalTable: "Questiones",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "QuestionOptiones",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            right = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            QustionId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_QuestionOptiones", x => x.id);
        //            table.ForeignKey(
        //                name: "FK_QuestionOptiones_Questiones_QustionId",
        //                column: x => x.QustionId,
        //                principalTable: "Questiones",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TrueAndFalses",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            right = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            QustionId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TrueAndFalses", x => x.id);
        //            table.ForeignKey(
        //                name: "FK_TrueAndFalses_Questiones_QustionId",
        //                column: x => x.QustionId,
        //                principalTable: "Questiones",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetRoleClaims_RoleId",
        //        table: "AspNetRoleClaims",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "RoleNameIndex",
        //        table: "AspNetRoles",
        //        column: "NormalizedName",
        //        unique: true,
        //        filter: "[NormalizedName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserClaims_UserId",
        //        table: "AspNetUserClaims",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserLogins_UserId",
        //        table: "AspNetUserLogins",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserRoles_RoleId",
        //        table: "AspNetUserRoles",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "EmailIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedEmail");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUsers_Courseid",
        //        table: "AspNetUsers",
        //        column: "Courseid");

        //    migrationBuilder.CreateIndex(
        //        name: "UserNameIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedUserName",
        //        unique: true,
        //        filter: "[NormalizedUserName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Course_CategoryId",
        //        table: "Course",
        //        column: "CategoryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Course_SubCategoryId",
        //        table: "Course",
        //        column: "SubCategoryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CourseVideos_CourseId",
        //        table: "CourseVideos",
        //        column: "CourseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CourseVideos_LessonId",
        //        table: "CourseVideos",
        //        column: "LessonId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DragAndDrop_QustionId",
        //        table: "DragAndDrop",
        //        column: "QustionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_EnrollCourse_CourseId",
        //        table: "EnrollCourse",
        //        column: "CourseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_EnrollCourse_StudentId",
        //        table: "EnrollCourse",
        //        column: "StudentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_lecture_CourseId",
        //        table: "lecture",
        //        column: "CourseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_lessonContents_LessonId",
        //        table: "lessonContents",
        //        column: "LessonId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_lessonContents_QuestionGroupId",
        //        table: "lessonContents",
        //        column: "QuestionGroupId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_lessonContents_VideoLinkId",
        //        table: "lessonContents",
        //        column: "VideoLinkId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_lessones_LectureId",
        //        table: "lessones",
        //        column: "LectureId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_MentorOrInstractorStories_CountryID",
        //        table: "MentorOrInstractorStories",
        //        column: "CountryID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Payment_ApplicationStudentIdentity_Id",
        //        table: "Payment",
        //        column: "ApplicationStudentIdentity_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Questiones_QuestionGroupId",
        //        table: "Questiones",
        //        column: "QuestionGroupId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionGroupes_CourseId",
        //        table: "QuestionGroupes",
        //        column: "CourseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionGroupes_LectureId",
        //        table: "QuestionGroupes",
        //        column: "LectureId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionGroupes_LessonContentId",
        //        table: "QuestionGroupes",
        //        column: "LessonContentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionGroupes_LessonId",
        //        table: "QuestionGroupes",
        //        column: "LessonId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionOptiones_QustionId",
        //        table: "QuestionOptiones",
        //        column: "QustionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StudentAnswers_QuestionId",
        //        table: "StudentAnswers",
        //        column: "QuestionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StudentAnswers_StudentId",
        //        table: "StudentAnswers",
        //        column: "StudentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StudentReview_StudentID",
        //        table: "StudentReview",
        //        column: "StudentID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StudentStories_CategoryId",
        //        table: "StudentStories",
        //        column: "CategoryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StudentStories_StudentId",
        //        table: "StudentStories",
        //        column: "StudentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_SubCategory_CategoryID",
        //        table: "SubCategory",
        //        column: "CategoryID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TrueAndFalses_QustionId",
        //        table: "TrueAndFalses",
        //        column: "QustionId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_StudentAnswers_Questiones_QuestionId",
        //        table: "StudentAnswers",
        //        column: "QuestionId",
        //        principalTable: "Questiones",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Restrict);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_QuestionGroupes_lessonContents_LessonContentId",
        //        table: "QuestionGroupes",
        //        column: "LessonContentId",
        //        principalTable: "lessonContents",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Restrict);
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_CourseVideos_Course_CourseId",
        //        table: "CourseVideos");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_lecture_Course_CourseId",
        //        table: "lecture");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_QuestionGroupes_Course_CourseId",
        //        table: "QuestionGroupes");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_CourseVideos_lessones_LessonId",
        //        table: "CourseVideos");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_lessonContents_lessones_LessonId",
        //        table: "lessonContents");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_QuestionGroupes_lessones_LessonId",
        //        table: "QuestionGroupes");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_lessonContents_CourseVideos_VideoLinkId",
        //        table: "lessonContents");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_lessonContents_QuestionGroupes_QuestionGroupId",
        //        table: "lessonContents");

        //    migrationBuilder.DropTable(
        //        name: "AspNetRoleClaims");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserClaims");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserLogins");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserRoles");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserTokens");

        //    migrationBuilder.DropTable(
        //        name: "Consultation");

        //    migrationBuilder.DropTable(
        //        name: "DragAndDrop");

        //    migrationBuilder.DropTable(
        //        name: "EnrollCourse");

        //    migrationBuilder.DropTable(
        //        name: "MentorOrInstractorStories");

        //    migrationBuilder.DropTable(
        //        name: "Payment");

        //    migrationBuilder.DropTable(
        //        name: "QuestionOptiones");

        //    migrationBuilder.DropTable(
        //        name: "StudentAnswers");

        //    migrationBuilder.DropTable(
        //        name: "StudentReview");

        //    migrationBuilder.DropTable(
        //        name: "StudentStories");

        //    migrationBuilder.DropTable(
        //        name: "TrueAndFalses");

        //    migrationBuilder.DropTable(
        //        name: "AspNetRoles");

        //    migrationBuilder.DropTable(
        //        name: "Country");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUsers");

        //    migrationBuilder.DropTable(
        //        name: "Questiones");

        //    migrationBuilder.DropTable(
        //        name: "Course");

        //    migrationBuilder.DropTable(
        //        name: "SubCategory");

        //    migrationBuilder.DropTable(
        //        name: "Category");

        //    migrationBuilder.DropTable(
        //        name: "lessones");

        //    migrationBuilder.DropTable(
        //        name: "CourseVideos");

        //    migrationBuilder.DropTable(
        //        name: "QuestionGroupes");

        //    migrationBuilder.DropTable(
        //        name: "lecture");

        //    migrationBuilder.DropTable(
        //        name: "lessonContents");
        //}
    }
}
