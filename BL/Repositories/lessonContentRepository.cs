
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


    public class lessonContentRepository : BaseRepository<lessonContent>
    {

        private DbContext U_DbContext;

        public lessonContentRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }

        

        #region CRUB

        public List<lessonContent> GetAlllessonContent()
        {
            return GetAll().ToList();
        }
        public List<lessonContent> GetAllLessonContentByLesson(int LesId)
        {
            return GetWhere(Less => Less.LessonId == LesId).ToList();
        }
        public List<lessonContent> GetAllLessonContentByCrsID(int CrsId)
        {
            return GetWhere(Less => Less.crsID == CrsId).ToList();
        }
        

        public bool InsertlessonContent(lessonContent lessonContent)
        {
            return Insert(lessonContent);
        }
        public void UpdatelessonContent(lessonContent lessonContent)
        {
            Update(lessonContent);
        }
        public void DeletelessonContent(int id)
        {
            Delete(id);
        }

        public bool ChecklessonContentExists(lessonContent lessonContent)
        {
            return GetAny(l => l.Id == lessonContent.Id);
        }
        public lessonContent GetlessonContentById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }

        public int GetFirstLessonContentByLessonId(int id)
        {
            lessonContent lessonContendId = GetFirstOrDefault(l => l.LessonId == id);
            return lessonContendId.Id;
        }

        public int lessonContentCount(int crsId)
        {
            return GetWhere(l => l.crsID == crsId).ToList().Count();
        }
        #endregion
    }
}