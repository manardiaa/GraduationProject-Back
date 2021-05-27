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
    public class StudentAnswerRepository : BaseRepository<StudentAnswer>
    {

        private DbContext U_DbContext;

        public StudentAnswerRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<StudentAnswer> GetAllStudentAnswer()
        {
            return GetAll().ToList();
        }

        public bool InsertStudentAnswer(StudentAnswer studentAnswer)
        {
            return Insert(studentAnswer);
        }
        public void UpdateStudentAnswer(StudentAnswer studentAnswer)
        {
            Update(studentAnswer);
        }
        public void DeleteStudentAnswer(int id)
        {
            Delete(id);
        }

        public bool CheckStudentAnswerExists(StudentAnswer studentAnswer)
        {
            return GetAny(l => l.id == studentAnswer.id);
        }
        public StudentAnswer GetOStudentAnswerById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }
        #endregion
    }
}
