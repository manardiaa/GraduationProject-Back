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
    public class TrueAndFalseAppService : AppServiceBase
    {
        public TrueAndFalseAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        { }

        #region CURD

        public List<TrueAndFalseViewModel> AllTrueAndFalse()
        {

            return Mapper.Map<List<TrueAndFalseViewModel>>(TheUnitOfWork.trueAndFalse.GetAllTrueAndFalseQuestions());
        }
        public TrueAndFalseViewModel GetTrueAndFalse(int id)
        {
            return Mapper.Map<TrueAndFalseViewModel>(TheUnitOfWork.trueAndFalse.GetById(id));
        }
        public bool SaveNewTrueAndFalse(TrueAndFalseViewModel trueAndFalseViewModel)
        {
            if (trueAndFalseViewModel == null)

                throw new ArgumentNullException();
            bool result = false;
            var trueAndFalse = Mapper.Map<TrueAndFalse>(trueAndFalseViewModel);
            if (TheUnitOfWork.trueAndFalse.Insert(trueAndFalse))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateTrueAndFalse(TrueAndFalseViewModel trueAndFalseViewModel)
        {
            var trueAndFalse = Mapper.Map<TrueAndFalse>(trueAndFalseViewModel);
            TheUnitOfWork.trueAndFalse.Update(trueAndFalse);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool DeleteTrueAndFalse(int id)
        {
            bool result = false;
            TheUnitOfWork.trueAndFalse.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckTrueAndFalseExists(TrueAndFalseViewModel trueAndFalseViewModel)
        {
            var trueAndFalse = Mapper.Map<TrueAndFalse>(trueAndFalseViewModel);
            return TheUnitOfWork.trueAndFalse.CheckTrueAndFalseQuestionExists(trueAndFalse);
        }
        #endregion
    }
}
