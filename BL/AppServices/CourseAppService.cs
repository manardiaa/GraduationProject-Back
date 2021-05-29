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
    public class CourseAppServices : AppServiceBase
    {
        public CourseAppServices(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<CourseViewModel> GetAllCourses()
        {

            return Mapper.Map<List<CourseViewModel>>(TheUnitOfWork.course.GetAllCourse());
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
        #endregion



    }
}
