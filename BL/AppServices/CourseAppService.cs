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
    public class CourseAppService : AppServiceBase
    {
        public CourseAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<CourseViewModel> GetAllCourses()
        {
            return Mapper.Map<List<CourseViewModel>>(TheUnitOfWork.course.GetAllCourse());
        }

        public List<CourseViewModel> GetFristFourCoures(int CatId)
        {
            return Mapper.Map<List<CourseViewModel>>(TheUnitOfWork.course.GetTopFourCourses(CatId));
        }
        public List<CourseViewModel> GetNextFourCourses(int CatId)
        {
            return Mapper.Map<List<CourseViewModel>>(TheUnitOfWork.course.GetNextFourCourses(CatId));
        }
        public CourseViewModel GetCourse(int id)
        {
            return Mapper.Map<CourseViewModel>(TheUnitOfWork.course.GetById(id));
        }



        public bool SaveNewCourse(CourseViewModel courseViewModel)
        {
            if (courseViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var course = Mapper.Map<Course>(courseViewModel);
            if (TheUnitOfWork.course.Insert(course))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCourse(CourseViewModel courseViewModel)
        {
            var course = Mapper.Map<Course>(courseViewModel);
            TheUnitOfWork.course.Update(course);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCourse(int id)
        {
            bool result = false;

            TheUnitOfWork.course.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCourseExists(CourseViewModel courseViewModel)
        {
            Course course = Mapper.Map<Course>(courseViewModel);
            return TheUnitOfWork.course.CheckCourseExists(course);
        }

        public List<CourseViewModel> GetAllCrsByCatID(int CatID)
        {
            return Mapper.Map<List<CourseViewModel>>(TheUnitOfWork.course.GetAllCourseByCatID(CatID));            
        }

        public List<CourseViewModel> GetListOfTwoCrsByCatID(int CatID)
        {
            return Mapper.Map<List<CourseViewModel>>(TheUnitOfWork.course.GetTopTwoCrs(CatID));
        }

        public bool CheckCourseExistsByData(CourseViewModel courseViewModel)
        {
            Course course = Mapper.Map<Course>(courseViewModel);
            if (course == null)
            {
                return false;
            }
            else
            {
                return TheUnitOfWork.course.CheckCourseExistsByData(course);
            }
        }
        #endregion



    }
}
