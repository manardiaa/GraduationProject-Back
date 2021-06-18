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
        public List<Question> GetAllQuestionByLessonContent(int LesId)
        {

            lessonContent LC = (lessonContent)GetWhere(ls => ls.Id== LesId);

            return GetWhere(Qes => Qes.QuestionGroupId == LC.QuestionGroupId).ToList();


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
