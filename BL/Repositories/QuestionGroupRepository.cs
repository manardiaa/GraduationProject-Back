﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{


    public class QuestionGroupRepository : BaseRepository<QuestionGroup>
    {

        private DbContext U_DbContext;

        public QuestionGroupRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<QuestionGroup> GetAllQuestionGroup()
        {
            return GetAll().ToList();
        }

        public bool InsertQuestionGroup(QuestionGroup QuestionGroup)
        {
            return Insert(QuestionGroup);
        }
        public void UpdateQuestionGroup(QuestionGroup QuestionGroup)
        {
            Update(QuestionGroup);
        }
        public void DeleteQuestionGroup(int id)
        {
            Delete(id);
        }

        public bool CheckQuestionGroupExists(QuestionGroup QuestionGroup)
        {
            return GetAny(l => l.Id == QuestionGroup.Id);
        }
        public QuestionGroup GetQuestionGroupById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}