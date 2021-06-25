using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class QuestionRepository : BaseRepository<Question>
    {

        private DbContext U_DbContext;

        public QuestionRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<Question> GetAllQuestion()
        {
            return GetAll().ToList();
        }

        public List<Question> GetAllQuestionbyIds(int lessonContentId,int questionGroupId)
        {
            return GetWhere(l => l.LessonContentId == lessonContentId && l.QuestionGroupId == questionGroupId).ToList();
        }

        public List<Question> GetAllQuestionByType(string type)
        {
            return GetWhere(l=>l.Type==type).ToList();
        }
        public List<Question> GetAllQuestionByLessonContent(int LesId)
        {
        return GetWhere(Qes => Qes.LessonContentId == LesId).ToList();
         }

        public bool InsertQuestion(Question question)
        {
            return Insert(question);
        }
        public void UpdateQuestion(Question question)
        {
            Update(question);
        }
        public void DeleteQuestion(int id)
        {
            Delete(id);
        }

        public bool CheckQuestionExists(Question question)
        {
            return GetAny(l => l.Id == question.Id);
        }
        public Question GetOQuestionById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
