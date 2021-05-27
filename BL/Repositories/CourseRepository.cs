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
    public class CourseRepository : BaseRepository<Course>
    {

        private DbContext U_DbContext;

        public CourseRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<Course> GetAllCourse()
        {
            return GetAll().ToList();
        }

        public bool InsertCourse(Course course)
        {
            return Insert(course);
        }
        public void UpdateCourse(Course course)
        {
            Update(course);
        }
        public void DeleteCourse(int id)
        {
            Delete(id);
        }

        public bool CheckCourseExists(Course course)
        {
            return GetAny(l => l.id == course.id);
        }
        public Course GetOCourseById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }
        #endregion
    }
}

