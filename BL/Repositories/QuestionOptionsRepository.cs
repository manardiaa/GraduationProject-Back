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
    public class QuestionOptionsRepository : BaseRepository<QuestionOptions>
    {

        private DbContext U_DbContext;

        public QuestionOptionsRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<QuestionOptions> GetAllQuestionOptions()
        {
            return GetAll().ToList();
        }

        public QuestionOptions GetQuestionOptByQuestionID(int QID)
        {
            return GetFirstOrDefault(l => l.QustionId == QID);
        }

        public bool InsertQuestionOptions(QuestionOptions questionOptions)
        {
            return Insert(questionOptions);
        }
        public void UpdateQuestionOptions(QuestionOptions questionOptions)
        {
            Update(questionOptions);
        }
        public void DeleteQuestionOptions(int id)
        {
            Delete(id);
        }

        public bool CheckQuestionOptionsExists(QuestionOptions questionOptions)
        {
            return GetAny(l => l.id == questionOptions.id);
        }
        public QuestionOptions GetQuestionOptionsById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }
        #endregion
    }
}
