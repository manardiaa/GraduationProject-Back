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
    public class CategoryAppService : AppServiceBase
    {
        public CategoryAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<CategoryViewModel> GetAllCateogries()
        {

            return Mapper.Map<List<CategoryViewModel>>(TheUnitOfWork.category.GetAllCategory());
        }
        public CategoryViewModel GetCategory(int id)
        {
            return Mapper.Map<CategoryViewModel>(TheUnitOfWork.category.GetById(id));
        }

        public CategoryViewModel GetIdCategoryByName(string Name)
        {
            return Mapper.Map<CategoryViewModel>(TheUnitOfWork.category.GetIDOfCategoryByName(Name));
        }
        public bool SaveNewCategory(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var category = Mapper.Map<Category>(categoryViewModel);
            if (TheUnitOfWork.category.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCategory(CategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<Category>(categoryViewModel);
            TheUnitOfWork.category.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCategoryExists(CategoryViewModel categoryViewModel)
        {
            Category category = Mapper.Map<Category>(categoryViewModel);
            return TheUnitOfWork.category.CheckCategoryExists(category);
        }
        public bool CheckCategoryExistsByData(CategoryViewModel categoryViewModel)
        {
            Category category = Mapper.Map<Category>(categoryViewModel);
            if (category == null)
            {
                return false;
            }
            else
            {
                return TheUnitOfWork.category.CheckCategoryExistsByData(category);
            }
        }
        #endregion



    }
}
