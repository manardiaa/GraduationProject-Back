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
        public List<StudentAnswer> GetStudentAnswersByLessonContentId(int id,string stId)
        {
            return GetWhere(q => q.lessonContentId == id && q.StudentId==stId).ToList();
        }
        public List<StudentAnswer> GetAllStudentAnswer()
        {
            return GetAll().ToList();
        }
        public bool CheckIfAnswerExist(StudentAnswer stdAnswr)
        {
            return GetAny(l => l.StudentId == stdAnswr.StudentId && l.lessonContentId == stdAnswr.lessonContentId && l.QuestionId == stdAnswr.QuestionId);
        }
        public bool InsertStudentAnswer(StudentAnswer studentAnswer)
        {
            var qu = (Question)GetWhere(q => q.QuestionId== studentAnswer.QuestionId);
            if (qu.Type == "TF") {
                var tf = (TrueAndFalse)GetWhere(q => q.QuestionId == qu.Id);
                if (studentAnswer.Studentanswer ==tf.right)
                {
                    return Insert(studentAnswer);
                }
            }
             else if(qu.Type == "DragAndDrop" ) {
                var Dp = (DragAndDrop)GetWhere(q => q.QuestionId == qu.Id);
                if (studentAnswer.Studentanswer == Dp.RightAnswer)
                {
                    return Insert(studentAnswer);
                }
            }
            else if (qu.Type == "MCQ")
            {
                var QO = (QuestionOptions)GetWhere(q => q.QuestionId == qu.Id);
                if (studentAnswer.Studentanswer == QO.right)
                {
                    return Insert(studentAnswer);
                }
            }
            return false;
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
