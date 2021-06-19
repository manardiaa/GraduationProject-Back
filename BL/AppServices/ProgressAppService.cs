using System;
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
    public class ProgressAppService : AppServiceBase
    {
        public ProgressAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<ProgressViewModel> GetAllProgress()
        {

            return Mapper.Map<List<ProgressViewModel>>(TheUnitOfWork.Progress.GetAllProgress());
        }
       

        public ProgressViewModel GetProgress(int id)
        {
            return Mapper.Map<ProgressViewModel>(TheUnitOfWork.Progress.GetById(id));
        }
        public ProgressViewModel ProgressByCrsIDAndStID(int crsid, string stId)
        {
            return Mapper.Map<ProgressViewModel>(TheUnitOfWork.Progress.GetProgressByCrsIDAndStID(crsid,stId));
        }



        public bool SaveNewProgress(ProgressViewModel ProgressViewModel)
        {
            if (ProgressViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var Progress = Mapper.Map<Progress>(ProgressViewModel);
            if (TheUnitOfWork.Progress.Insert(Progress))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateProgress(ProgressViewModel ProgressViewModel)
        {
            var Progress = Mapper.Map<Progress>(ProgressViewModel);
            TheUnitOfWork.Progress.Update(Progress);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteProgress(int id)
        {
            bool result = false;

            TheUnitOfWork.Progress.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckProgressExists(ProgressViewModel ProgressViewModel)
        {
            Progress Progress = Mapper.Map<Progress>(ProgressViewModel);
            return TheUnitOfWork.Progress.CheckProgressExists(Progress);
        } 
        public bool CheckInsertProgressExists(ProgressViewModel ProgressViewModel)
        {
            Progress Progress = Mapper.Map<Progress>(ProgressViewModel);
            return TheUnitOfWork.Progress.CheckInsertProgressExists(Progress);
        }
        #endregion



    }
}
