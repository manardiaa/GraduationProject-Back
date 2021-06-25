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
    public class QuestionOptionsAppService : AppServiceBase
    {
        public QuestionOptionsAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {}

        #region CURD

        public List<QuestionOptionsViewModel> AllQuestionOptions()
        {

            return Mapper.Map<List<QuestionOptionsViewModel>>(TheUnitOfWork.questionOptions.GetAllQuestionOptions());
        }
        public QuestionOptionsViewModel GetQuestionOptByQuestionID(int QID)
        {
            return Mapper.Map<QuestionOptionsViewModel>(TheUnitOfWork.questionOptions.GetQuestionOptByQuestionID(QID));
        }
        public QuestionOptionsViewModel GetQuestionOptions(int id)
        {
            return Mapper.Map<QuestionOptionsViewModel>(TheUnitOfWork.questionOptions.GetById(id));
        }
        public bool SaveNewQuestionOptions(QuestionOptionsViewModel questionOptionsViewModel)
        {
            if (questionOptionsViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var questionOptions = Mapper.Map<QuestionOptions>(questionOptionsViewModel);
            if (TheUnitOfWork.questionOptions.Insert(questionOptions))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateQuestionOptions(QuestionOptionsViewModel questionOptionsViewModel)
        {
            var questionOptions = Mapper.Map<QuestionOptions>(questionOptionsViewModel);
            TheUnitOfWork.questionOptions.Update(questionOptions);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteQuestionOptions(int id)
        {
            bool result = false;

            TheUnitOfWork.questionOptions.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckQuestionOptionsExists(QuestionOptionsViewModel questionOptionsViewModel)
        {
            QuestionOptions questionOptions = Mapper.Map<QuestionOptions>(questionOptionsViewModel);
            return TheUnitOfWork.questionOptions.CheckQuestionOptionsExists(questionOptions);
        }
        #endregion
    }
}
