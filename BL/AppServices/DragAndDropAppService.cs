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
    public class DragAndDropAppService : AppServiceBase
    {
        public DragAndDropAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<DragAndDropViewModel> GetAllDragAndDrop()
        {

            return Mapper.Map<List<DragAndDropViewModel>>(TheUnitOfWork.dragAndDrop.GetAllDragAndDrop());
        }
        public DragAndDropViewModel GetDragAndDrop(int id)
        {
            return Mapper.Map<DragAndDropViewModel>(TheUnitOfWork.dragAndDrop.GetById(id));
        }



        public bool SaveNewDragAndDrop(DragAndDropViewModel DragAndDropViewModel)
        {
            if (DragAndDropViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var DragAndDrop = Mapper.Map<DragAndDrop>(DragAndDropViewModel);
            if (TheUnitOfWork.dragAndDrop.Insert(DragAndDrop))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateDragAndDrop(DragAndDropViewModel DragAndDropViewModel)
        {
            var DragAndDrop = Mapper.Map<DragAndDrop>(DragAndDropViewModel);
            TheUnitOfWork.dragAndDrop.Update(DragAndDrop);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteDragAndDrop(int id)
        {
            bool result = false;

            TheUnitOfWork.dragAndDrop.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckDragAndDropExists(DragAndDropViewModel DragAndDropViewModel)
        {
            DragAndDrop DragAndDrop = Mapper.Map<DragAndDrop>(DragAndDropViewModel);
            return TheUnitOfWork.dragAndDrop.CheckDragAndDropExists(DragAndDrop);
        }
        #endregion



    }
}
