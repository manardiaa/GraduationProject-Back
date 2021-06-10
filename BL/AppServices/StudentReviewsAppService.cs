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
    public class StudentReviewsAppService : AppServiceBase
    {
        public StudentReviewsAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<StudentReviewsViewModel> GetAllStudentReviews()
        {

            return Mapper.Map<List<StudentReviewsViewModel>>(TheUnitOfWork.studentReviews.GetAllStudentReviews());
        }


        public List<StudentReviewsViewModel> TopFourStdReviews()
        {

            return Mapper.Map<List<StudentReviewsViewModel>>(TheUnitOfWork.studentReviews.GetTopFourReviews());
        }
        public StudentReviewsViewModel GetStudentReviews(int id)
        {
            return Mapper.Map<StudentReviewsViewModel>(TheUnitOfWork.studentReviews.GetById(id));
        }
        public bool SaveNewStudentReviews(StudentReviewsViewModel studentReviewsViewModel)
        {
            if (studentReviewsViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var studentReviews = Mapper.Map<StudentReviews>(studentReviewsViewModel);
            if (TheUnitOfWork.studentReviews.InsertStudentReviews(studentReviews))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateStudentReviews(StudentReviewsViewModel studentReviewsViewModel)
        {
            var studentReviews = Mapper.Map<StudentReviews>(studentReviewsViewModel);
            TheUnitOfWork.studentReviews.Update(studentReviews);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteStudentReviews(int id)
        {
            bool result = false;

            TheUnitOfWork.studentReviews.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckStudentReviewsExists(StudentReviewsViewModel studentReviewsViewModel)
        {
            var studentReviews = Mapper.Map<StudentReviews>(studentReviewsViewModel);
            return TheUnitOfWork.studentReviews.CheckStudentReviewsExists(studentReviews);
        }
        #endregion



    }
}
