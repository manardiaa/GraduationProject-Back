using BL.Dtos;
using DAL;
using BL.Bases;
using BL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Marten.Services;

namespace BL.AppServices
{
    public class CourseVideosAppService : AppServiceBase
    {
        public CourseVideosAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<CourseVideosViewModel> GetAllCoursesVideos()
        {

            return Mapper.Map<List<CourseVideosViewModel>>(TheUnitOfWork.courseVideos.GetAllCourseVideos());
        }

        public List<CourseVideosViewModel> GetAllCourseVideosByLessonId(int lessonId)
        {

            return Mapper.Map<List<CourseVideosViewModel>>(TheUnitOfWork.courseVideos.GetAllCourseVideosByLessonId(lessonId));
        }
        
        public CourseVideosViewModel GetCourseVideos(int id)
        {
            return Mapper.Map<CourseVideosViewModel>(TheUnitOfWork.courseVideos.GetById(id));
        }



        public bool SaveNewCourseVideos(CourseVideosViewModel courseVideosViewModel)
        {
            if (courseVideosViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var courseVideos = Mapper.Map<CourseVideos>(courseVideosViewModel);
            if (TheUnitOfWork.courseVideos.Insert(courseVideos))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCourseVideos(CourseVideosViewModel courseVideosViewModel)
        {
            var courseVideos = Mapper.Map<CourseVideos>(courseVideosViewModel);
            TheUnitOfWork.courseVideos.Update(courseVideos);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCourseVideos(int id)
        {
            bool result = false;

            TheUnitOfWork.courseVideos.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCourseVideosExists(CourseVideosViewModel courseVideosViewModel)
        {
            CourseVideos courseVideos = Mapper.Map<CourseVideos>(courseVideosViewModel);
            return TheUnitOfWork.courseVideos.CheckCourseVideosExists(courseVideos);
        }
        public bool CheckCourseVideosExistsByData(CourseVideosViewModel courseVideosViewModel)
        {
            CourseVideos courseVideos = Mapper.Map<CourseVideos>(courseVideosViewModel);
            if (courseVideos == null)
            {
                return false;
            }
            else
            {
                return TheUnitOfWork.courseVideos.CheckCourseVideosExistsByData(courseVideos);
            }
        }
        #endregion



    }
}
