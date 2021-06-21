
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


    public class lessonRepository : BaseRepository<lesson>
    {

        private DbContext U_DbContext;

        public lessonRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<lesson> GetAllLesson()
        {
            return GetAll().ToList();
        }
        public List<lesson> GetAllLessonByLecture(int LecId)
        {
            return GetWhere(Less => Less.LectureId == LecId).ToList();
        }

        public List<lesson> GetAllLessonByCrsID(int CrsID)
        {
            return GetWhere(Less => Less.CrsId == CrsID).ToList();
        }

        public bool Insertlesson(lesson lesson)
        {
            return Insert(lesson);
        }
        public void Updatelesson(lesson lesson)
        {
            Update(lesson);
        }
        public void Deletelesson(int id)
        {
            Delete(id);
        }

        public bool ChecklessonExists(lesson lesson)
        {
            return GetAny(l => l.Id == lesson.Id);
        }
        public lesson GetlessonById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}