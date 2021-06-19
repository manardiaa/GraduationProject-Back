using AutoMapper;
using BL.Dtos;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course, CourseViewModel>().ReverseMap();
            CreateMap<CourseVideos, CourseVideosViewModel>().ReverseMap();
            CreateMap<EnrollCourse, EnrollCourseViewModel>().ReverseMap();
            CreateMap<DragAndDrop, DragAndDropViewModel>().ReverseMap();
            CreateMap<lecture, lectureViewModel>().ReverseMap();
            CreateMap<lesson, lessonViewModel>().ReverseMap();
            CreateMap<lessonContent, lessonContentViewModel>().ReverseMap();
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<QuestionGroup, QuestionGroupViewModel>().ReverseMap();
            CreateMap<QuestionOptions, QuestionOptionsViewModel>().ReverseMap();
            CreateMap<StudentAnswer, StudentAnswerViewModel>().ReverseMap();
            CreateMap<TrueAndFalse, TrueAndFalseViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<ApplicationStudentIdentity, LoginViewModel>().ReverseMap();
            CreateMap<ApplicationStudentIdentity, RegisterViewodel>().ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<IdentityRole, UserRolesViewModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<Consultation, ConsultationViewModel>().ReverseMap();
            CreateMap<MentorOrInstractorStories, MentorOrInstractorStoriesViewModel>().ReverseMap();
            CreateMap<StudentReviews, StudentReviewsViewModel>().ReverseMap();
            CreateMap<StudentStories, StudentStoriesViewModel>().ReverseMap();
            CreateMap<SubCategory, SubCategoryViewModel>().ReverseMap();

            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<Progress, ProgressViewModel>().ReverseMap();
            CreateMap<Watched, WatchedViewModel>().ReverseMap();



        }

    }
}
