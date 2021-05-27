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
    public class TrueAndFalseRepository : BaseRepository<TrueAndFalse>
    {

        private DbContext U_DbContext;

        public TrueAndFalseRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<TrueAndFalse> GetAllTrueAndFalseQuestions()
        {
            return GetAll().ToList();
        }

        public bool InsertTrueAndFalseQuestions(TrueAndFalse trueAndFalse)
        {
            return Insert(trueAndFalse);
        }
        public void UpdateTrueAndFalseQuestions(TrueAndFalse trueAndFalse)
        {
            Update(trueAndFalse);
        }
        public void DeleteTrueAndFalseQuestions(int id)
        {
            Delete(id);
        }

        public bool CheckTrueAndFalseQuestionExists(TrueAndFalse trueAndFalse)
        {
            return GetAny(l => l.id == trueAndFalse.id);
        }
        public TrueAndFalse GetTrueAndFalseQuestionById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }
        #endregion
    }
}