using BL.Dtos;
using DAL;
using BL.Bases;
using BL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Marten.Services;

namespace BL.AppServices
{
    public class StudentAnswerAppService : AppServiceBase
    {
        public StudentAnswerAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        { }

        #region CURD

        public List<StudentAnswerViewModel> AllStudentAnswer()
        {

            return Mapper.Map<List<StudentAnswerViewModel>>(TheUnitOfWork.studentAnswer.GetAllStudentAnswer());
        }
        public List<StudentAnswerViewModel> GetStudentAnswersByLessonContentId(int id,string stId)
        {

            return Mapper.Map<List<StudentAnswerViewModel>>(TheUnitOfWork.studentAnswer.GetStudentAnswersByLessonContentId(id,stId));
        }
        public StudentAnswerViewModel GetStudentAnswer(int id)
        {
            return Mapper.Map<StudentAnswerViewModel>(TheUnitOfWork.studentAnswer.GetById(id));
        }
        public bool CheckIfAnswerExist(StudentAnswerViewModel studentAnswerViewModel)
        {
            {
                StudentAnswer studentAnswer = Mapper.Map<StudentAnswer>(studentAnswerViewModel);
                if (studentAnswer == null)
                {
                    return false;
                }
                else
                {
                    return TheUnitOfWork.studentAnswer.CheckIfAnswerExist(studentAnswer);
                }
            }

        }
        public bool SaveNewStudentAnswer(StudentAnswerViewModel studentAnswerViewModel)
        {
            if (studentAnswerViewModel == null)

                throw new ArgumentNullException();
            bool result = false;
            var studentAnswer = Mapper.Map<StudentAnswer>(studentAnswerViewModel);
            if (TheUnitOfWork.studentAnswer.Insert(studentAnswer))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateStudentAnswer(StudentAnswerViewModel studentAnswerViewModel)
        {
            var studentAnswer = Mapper.Map<StudentAnswer>(studentAnswerViewModel);
            TheUnitOfWork.studentAnswer.Update(studentAnswer);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool DeleteStudentAnswer(int id)
        {
            bool result = false;
            TheUnitOfWork.studentAnswer.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckStudentAnswerExists(StudentAnswerViewModel studentAnswerViewModel)
        {
            var studentAnswer = Mapper.Map<StudentAnswer>(studentAnswerViewModel);
            return TheUnitOfWork.studentAnswer.CheckStudentAnswerExists(studentAnswer);
        }
        #endregion
    }
}
