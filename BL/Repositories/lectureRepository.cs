using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    
   
     public class lectureRepository : BaseRepository<lecture>
    {

        private DbContext U_DbContext;

        public lectureRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<lecture> GetCrsLectures(int CrsID)
        {
            return GetWhere(crs => crs.CourseId == CrsID).ToList();
        }
        public List<lecture> GetAllLecture()
        {
            return GetAll().ToList();
        }

        public bool Insertlecture(lecture lecture)
        {
            return Insert(lecture);
        }
        public void Updatelecture(lecture lecture)
        {
            Update(lecture);
        }
        public void Deletelecture(int id)
        {
            Delete(id);
        }

        public bool ChecklectureExists(lecture lecture)
        {
            return GetAny(l => l.Id == lecture.Id);
        }
        public lecture GetlectureById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
