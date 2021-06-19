
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
        public bool CheckInsertProgressExists(Progress Progress)
        {
            return GetAny(l => l.CourseId == Progress.CourseId&& l.StudentId==Progress.StudentId);
        }
        public Progress GetOProgressById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        public Progress GetProgressByCrsIDAndStID(int crsid,string stId)
        {
            return GetFirstOrDefault(l => l.CourseId == crsid && l.StudentId==stId);
        }

       


        #endregion
    }
}

