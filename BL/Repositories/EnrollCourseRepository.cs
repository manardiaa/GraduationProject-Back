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
    public class EnrollCourseRepository : BaseRepository<EnrollCourse>
    {

        private DbContext U_DbContext;

        public EnrollCourseRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<EnrollCourse> GetAllEnrollCourse()
        {
            return GetAll().ToList();
        }
        public List<EnrollCourse> AllCrsOfStd(string stdId)
        {
            return GetWhere(crsEnrll => crsEnrll.StudentId == stdId).ToList();
        }

        public bool InsertEnrollCourse(EnrollCourse enrollcourse)
        {
            return Insert(enrollcourse);
        }

        public bool CheckIfCrsEnrollExist(EnrollCourse enrollcourse)
        {
            return GetAny(l => l.StudentId == enrollcourse.StudentId && l.CourseId == enrollcourse.CourseId);
        }
        public void UpdateEnrollCourse(EnrollCourse enrollcourse)
        {
            Update(enrollcourse);
        }
        public void DeleteEnrollCourse(int id)
        {
            Delete(id);
        }

        public bool CheckEnrollCourseExists(EnrollCourse enrollcourse)
        {
            return GetAny(l => l.Id== enrollcourse.Id);
        }
        public EnrollCourse GetOEnrollCourseById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }

        public EnrollCourse GetCrsEnroll(int crsid,string stid)
        {
            return GetFirstOrDefault(l => l.CourseId == crsid && l.StudentId==stid);
        }
        #endregion
    }
}

