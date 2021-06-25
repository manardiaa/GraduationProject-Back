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
    public class QuestionAppService : AppServiceBase
    {
        public QuestionAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        { }

        #region CURD

        public List<QuestionViewModel> AllQuestions()
        {
            return Mapper.Map<List<QuestionViewModel>>(TheUnitOfWork.question.GetAllQuestion());
        }
        public List<QuestionViewModel> GetAllQuestionbyIds(int lessonContentId, int questionGroupId)
        {
            return Mapper.Map<List<QuestionViewModel>>(TheUnitOfWork.question.GetAllQuestionbyIds(lessonContentId,questionGroupId));
        }

        public List<QuestionViewModel> GetAllQuestionByType(string type)
        {
            return Mapper.Map<List<QuestionViewModel>>(TheUnitOfWork.question.GetAllQuestionByType(type));
        }


        public QuestionViewModel GetQuestions(int id)
        {
            return Mapper.Map<QuestionViewModel>(TheUnitOfWork.question.GetById(id));
        }
        public List<QuestionViewModel> GetAllQuestionByLessonContent(int LesId)
        {
            return Mapper.Map<List<QuestionViewModel>>(TheUnitOfWork.question.GetAllQuestionByLessonContent(LesId));
        }

        public bool SaveNewQuestions(QuestionViewModel questionViewModel)
        {
            if (questionViewModel == null)

                throw new ArgumentNullException();
            bool result = false;
            var question = Mapper.Map<Question>(questionViewModel);
            if (TheUnitOfWork.question.Insert(question))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateQuestions(QuestionViewModel questionViewModel)
        {
            var question = Mapper.Map<Question>(questionViewModel);
            TheUnitOfWork.question.Update(question);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool DeleteQuestions(int id)
        {
            bool result = false;
            TheUnitOfWork.question.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckQuestionsExists(QuestionViewModel questionViewModel)
        {
            Question question = Mapper.Map<Question>(questionViewModel);
            return TheUnitOfWork.question.CheckQuestionExists(question);
        }
        #endregion
    }
}