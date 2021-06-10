using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Repositories
{
    public class StudentReviewsRepository : BaseRepository<StudentReviews>
    {

        private DbContext U_DbContext;

        public StudentReviewsRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<StudentReviews> GetAllStudentReviews()
        {
            return GetAll().ToList();
        }


        public List<StudentReviews> GetTopFourReviews()
        {
            return GetWhere(stdR => stdR.ShowOrNot == 1).Take(4).ToList();
        }

        public bool InsertStudentReviews(StudentReviews studentReviews)
        {
            return Insert(studentReviews);
        }
        public void UpdateStudentReviews(StudentReviews studentReviews)
        {
            Update(studentReviews);
        }
        public void DeleteStudentReviews(int id)
        {
            Delete(id);
        }

        public bool CheckStudentReviewsExists(StudentReviews studentReviews)
        {
            return GetAny(l => l.id == studentReviews.id);
        }
        public StudentReviews GetOStudentReviewsById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }
        #endregion
    }
}

