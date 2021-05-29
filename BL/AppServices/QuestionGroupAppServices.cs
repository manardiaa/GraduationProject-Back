﻿using BL.Dtos;
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
   public class QuestionGroupAppServices : AppServiceBase
    {
        public QuestionGroupAppServices(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        { }

        #region CURD

        public List<QuestionGroupViewModel> AllQuestions()
        {

            return Mapper.Map<List<QuestionGroupViewModel>>(TheUnitOfWork.questionGroup.GetAllQuestionGroup());
        }
        public QuestionGroupViewModel GetQuestionGroup(int id)
        {
            return Mapper.Map<QuestionGroupViewModel>(TheUnitOfWork.questionGroup.GetById(id));
        }
        public bool SaveNewQuestionGroup(QuestionGroupViewModel questionGroupViewModel)
        {
            if (questionGroupViewModel == null)

                throw new ArgumentNullException();
            bool result = false;
            var questionGroup = Mapper.Map<QuestionGroup>(questionGroupViewModel);
            if (TheUnitOfWork.questionGroup.Insert(questionGroup))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateQuestionGroup(QuestionGroupViewModel questionGroupViewModel)
        {
            var questionGroup = Mapper.Map<QuestionGroup>(questionGroupViewModel);
            TheUnitOfWork.questionGroup.Update(questionGroup);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool DeleteQuestionGroup(int id)
        {
            bool result = false;
            TheUnitOfWork.questionGroup.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckQuestionGroupExists(QuestionGroupViewModel questionGroupViewModel)
        {
            QuestionGroup questionGroup = Mapper.Map<QuestionGroup>(questionGroupViewModel);
            return TheUnitOfWork.questionGroup.CheckQuestionGroupExists(questionGroup);
        }
        #endregion
    }
}