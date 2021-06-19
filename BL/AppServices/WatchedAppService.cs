using BL.Dtos;
using BL.Bases;
using DAL.Models;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace BL.AppServices
{
    public class WatchedAppService : AppServiceBase
    {
        public WatchedAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<WatchedViewModel> GetAllWatched()
        {

            return Mapper.Map<List<WatchedViewModel>>(TheUnitOfWork.Watched.GetAllWatched());
        }
        public WatchedViewModel GetWatched(int id)
        {
            return Mapper.Map<WatchedViewModel>(TheUnitOfWork.Watched.GetById(id));
        }
        public bool SaveNewWatched(WatchedViewModel WatchedViewModel)
        {
            if (WatchedViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var Watched = Mapper.Map<Watched>(WatchedViewModel);
            if (TheUnitOfWork.Watched.Insert(Watched))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateWatched(WatchedViewModel WatchedViewModel)
        {
            var Watched = Mapper.Map<Watched>(WatchedViewModel);
            TheUnitOfWork.Watched.Update(Watched);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteWatched(int id)
        {
            bool result = false;

            TheUnitOfWork.Watched.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckWatchedExists(WatchedViewModel WatchedViewModel)
        {
            Watched Watched = Mapper.Map<Watched>(WatchedViewModel);
            return TheUnitOfWork.Watched.CheckWatchedExists(Watched);
        }
        public bool CheckWatchedExistsByData(WatchedViewModel WatchedViewModel)
        {
            Watched Watched = Mapper.Map<Watched>(WatchedViewModel);
            if (Watched == null)
            {
                return false;
            }
            else
            {
                return TheUnitOfWork.Watched.CheckWatchedExistsByData(Watched);
            }
        }
        public WatchedViewModel GetWatchedObj(string stId, int crsID, int lessonContentID)
        {
            return Mapper.Map<WatchedViewModel>(TheUnitOfWork.Watched.GetWatchedObj(stId,crsID,lessonContentID));
        }
        #endregion



    }
}
