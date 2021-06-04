using BL.Interfaces;
using BL.Repositories;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Common Properties
        private DbContext U_DbContext { get; set; }
        private UserManager<ApplicationStudentIdentity> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        #endregion

        #region Constructors
        public UnitOfWork(ApplicationDBContext U_DbContext, UserManager<ApplicationStudentIdentity> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this.U_DbContext = U_DbContext;//


            // Avoid load navigation properties
            //EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Methods
        public int Commit()
        {
            return U_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            U_DbContext.Dispose();
        }
        #endregion


        
       

        public CategoryRepository Category;//=> throw new NotImplementedException();
        public CategoryRepository category
        {
            get
            {
                if (Category == null)
                    Category = new CategoryRepository(U_DbContext);
                return Category;
            }
        }

        public CourseRepository Course;//=> throw new NotImplementedException();
        public CourseRepository course
        {
            get
            {
                if (Course == null)
                    Course = new CourseRepository(U_DbContext);
                return Course;
            }
        }

        public CourseVideosRepository CourseVideos;//=> throw new NotImplementedException();
        public CourseVideosRepository courseVideos
        {
            get
            {
                if (CourseVideos == null)
                    CourseVideos = new CourseVideosRepository(U_DbContext);
                return CourseVideos;
            }
        }

        public DragAndDropRepository DragAndDrop;//=> throw new NotImplementedException();
        public DragAndDropRepository dragAndDrop
        {
            get
            {
                if (DragAndDrop == null)
                    DragAndDrop = new DragAndDropRepository(U_DbContext);
                return DragAndDrop;
            }
        }


        public EnrollCourseRepository Enrollcourse;//=> throw new NotImplementedException();
        public EnrollCourseRepository enrollCourse
        {
            get
            {
                if (Enrollcourse == null)
                    Enrollcourse = new EnrollCourseRepository(U_DbContext);
                return Enrollcourse;
            }
        }

    
        public lectureRepository Lecture;//=> throw new NotImplementedException();
        public lectureRepository lecture
        {
            get
            {
                if (Lecture == null)
                    Lecture = new lectureRepository(U_DbContext);
                return Lecture;
            }
        }

        public lessonRepository Lesson;//=> throw new NotImplementedException();
        public lessonRepository lesson
        {
            get
            {
                if (Lesson == null)
                    Lesson = new lessonRepository(U_DbContext);
                return Lesson;
            }
        }

        public lessonContentRepository LessonContent;//=> throw new NotImplementedException();
        public lessonContentRepository lessonContent
        {
            get
            {
                if (LessonContent == null)
                    LessonContent = new lessonContentRepository(U_DbContext);
                return LessonContent;
            }
        }

        public QuestionOptionsRepository QuestionOptions;//=> throw new NotImplementedException();
        public QuestionOptionsRepository questionOptions
        {
            get
            {
                if (QuestionOptions == null)
                    QuestionOptions = new QuestionOptionsRepository(U_DbContext);
                return QuestionOptions;
            }
        }

        public QuestionRepository Question;//=> throw new NotImplementedException();
        public QuestionRepository question
        {
            get
            {
                if (Question == null)
                    Question= new QuestionRepository(U_DbContext);
                return Question;
            }
        }

        public QuestionGroupRepository QuestionGroup;//=> throw new NotImplementedException();
        public QuestionGroupRepository questionGroup
        {
            get
            {
                if (QuestionGroup == null)
                    QuestionGroup = new QuestionGroupRepository(U_DbContext);
                return QuestionGroup;
            }
        }
        

    public StudentAnswerRepository StudentAnswer;//=> throw new NotImplementedException();
        public StudentAnswerRepository studentAnswer
        {
            get
            {
                if (StudentAnswer == null)
                    StudentAnswer = new StudentAnswerRepository(U_DbContext);
                return StudentAnswer;
            }
        }

        public TrueAndFalseRepository TrueAndFalse;//=> throw new NotImplementedException();
        public TrueAndFalseRepository trueAndFalse
        {
            get
            {
                if (TrueAndFalse == null)
                    TrueAndFalse = new TrueAndFalseRepository(U_DbContext);
                return TrueAndFalse;
            }
        }
        public AccountRepository Account;//=> throw new NotImplementedException();
        public AccountRepository account
        {
            get
            {
                if (Account == null)
                    Account = new AccountRepository(U_DbContext, _userManager, _roleManager);
                return Account;
            }
        }

        public RoleRepository Role;//=> throw new NotImplementedException();
        public RoleRepository role
        {
            get
            {
                if (Role == null)
                    Role = new RoleRepository(U_DbContext, _roleManager);
                return Role;
            }
        }


        public CountryRepository Country;
        public CountryRepository country
        {
            get
            {
                if (Country == null)
                    Country = new CountryRepository(U_DbContext);
                return Country;
            }
        }

        public ConsultationRepository Consultation;
        public ConsultationRepository consultation
        {
            get
            {
                if (Consultation == null)
                    Consultation = new ConsultationRepository(U_DbContext);
                return Consultation;
            }
        }


        public MentorOrInstractorStoriesRepository MentorOrInstractor;
        public MentorOrInstractorStoriesRepository mentorOrInstractor
        {
            get
            {
                if (MentorOrInstractor == null)
                    MentorOrInstractor = new MentorOrInstractorStoriesRepository(U_DbContext);
                return MentorOrInstractor;
            }
        }


        public StudentReviewsRepository StudentReviews;
        public StudentReviewsRepository studentReviews
        {
            get
            {
                if (StudentReviews == null)
                    StudentReviews = new StudentReviewsRepository(U_DbContext);
                return StudentReviews;
            }
        }



        public StudentStoriesRepository StudentStories;
        public StudentStoriesRepository studentStories
        {
            get
            {
                if (StudentStories == null)
                    StudentStories = new StudentStoriesRepository(U_DbContext);
                return StudentStories;
            }
        }
    }
}
