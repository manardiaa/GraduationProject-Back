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
    public class SubCategoryAppService : AppServiceBase
    {
        public SubCategoryAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<SubCategoryViewModel> GetAllSubCateogries()
        {

            return Mapper.Map<List<SubCategoryViewModel>>(TheUnitOfWork.subCategory.GetAllSubCategory());
        }
        public SubCategoryViewModel GetSubCategory(int id)
        {
            return Mapper.Map<SubCategoryViewModel>(TheUnitOfWork.subCategory.GetById(id));
        }
        public bool SaveNewSubCategory(SubCategoryViewModel subCategoryViewModel)
        {
            if (subCategoryViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var subCategory = Mapper.Map<SubCategory>(subCategoryViewModel);
            if (TheUnitOfWork.subCategory.Insert(subCategory))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateSubCategory(SubCategoryViewModel subCategoryViewModel)
        {
            var subCategory = Mapper.Map<SubCategory>(subCategoryViewModel);
            TheUnitOfWork.subCategory.Update(subCategory);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteSubCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.subCategory.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckSubCategoryExists(SubCategoryViewModel subCategoryViewModel)
        {
            SubCategory subCategory = Mapper.Map<SubCategory>(subCategoryViewModel);
            return TheUnitOfWork.subCategory.CheckSubCategoryExists(subCategory);
        }
        #endregion



    }
}
