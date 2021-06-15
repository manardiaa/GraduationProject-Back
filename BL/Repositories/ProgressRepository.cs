
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
    public class ProgressRepository: BaseRepository<Progress>
    {

        private DbContext U_DbContext;

        public ProgressRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<Progress> GetAllProgress()
        {
            return GetAll().ToList();
        }

        //public int GetNumberOfLesson(int courseid)
        //{
        //    //Course c = GetFirstOrDefault(c => c.Course.id == courseid);
            
        //    Course c= (Course)GetWhere(course=> course.CourseId == courseid);
        //    Progress p = GetWhere(crs => crs.CourseId == c.id).FirstOrDefault();
        //    p.NumOfLesson = c.LectureNumber;
        //    return p.NumOfLesson;
        //}
        public bool InsertProgress(Progress Progress)
        {
            return Insert(Progress);
        }
        public void UpdateProgress(Progress Progress)
        {
            Update(Progress);
        }
        public void DeleteProgress(int id)
        {
            Delete(id);
        }

        public bool CheckProgressExists(Progress Progress)
        {
            return GetAny(l => l.Id == Progress.Id);
        }
        public Progress GetOProgressById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}

