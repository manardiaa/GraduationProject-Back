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
    public class EnrollCourseAppServices : AppServiceBase
    {
        public EnrollCourseAppServices(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<EnrollCourseViewModel> GetAllEnrollCourses()
        {

            return Mapper.Map<List<EnrollCourseViewModel>>(TheUnitOfWork.enrollCourse.GetAllEnrollCourse());
        }
        public EnrollCourseViewModel GetEnrollCourse(int id)
        {
            return Mapper.Map<EnrollCourseViewModel>(TheUnitOfWork.enrollCourse.GetById(id));
        }



        public bool SaveNewEnrollCourse(EnrollCourseViewModel EnrollcourseViewModel)
        {
            if (EnrollcourseViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var Enrollcourse = Mapper.Map<EnrollCourse>(EnrollcourseViewModel);
            if (TheUnitOfWork.enrollCourse.Insert(Enrollcourse))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateEnrollCourse(EnrollCourseViewModel EnrollcourseViewModel)
        {
            var Enrollcourse = Mapper.Map<EnrollCourse>(EnrollcourseViewModel);
            TheUnitOfWork.enrollCourse.Update(Enrollcourse);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteEnrollCourse(int id)
        {
            bool result = false;

            TheUnitOfWork.enrollCourse.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckEnrollCourseExists(EnrollCourseViewModel EnrollcourseViewModel)
        {
            EnrollCourse Enrollcourse = Mapper.Map<EnrollCourse>(EnrollcourseViewModel);
            return TheUnitOfWork.enrollCourse.CheckEnrollCourseExists(Enrollcourse);
        }
        #endregion



    }
}
