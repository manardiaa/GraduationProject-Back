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

        public List<Course> GetAllCourseByCatID(int Catid)
        {
            return GetWhere(crs => crs.CategoryId == Catid).ToList();
        }
        public List<Course> GetTopFourCourses(int Catid)
        {
            return GetWhere(crs => crs.CategoryId == Catid).Take(4).ToList();
        }

        public List<Course> GetNextFourCourses(int Catid)
        {
            return GetWhere(crs => crs.CategoryId == Catid).Skip(4).Take(4).ToList();
        }

        public List<Course> GetTopTwoCrs(int Catid)
        {
            return GetWhere(crs => crs.CategoryId == Catid).Take(2).ToList();
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
        public bool CheckCourseExistsByData(Course course)
        {
            return GetAny(crs => crs.Name == course.Name);
        }
        public Course GetOCourseById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }
        #endregion
    }
}

