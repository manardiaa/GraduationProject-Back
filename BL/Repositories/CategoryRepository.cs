using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {

        private DbContext U_DbContext;

        public CategoryRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<Category> GetAllCategory()
        {
            return GetAll().ToList();
        }
        public Category GetIDOfCategoryByName(string name)
        {

          return GetFirstOrDefault(cat => cat.CatName == name);
        }

        public bool InsertCategory(Category category)
        {
            return Insert(category);
        }
        public void UpdateCategory(Category category)
        {
            Update(category);
        }
        public void DeleteCategory(int id)
        {
            Delete(id);
        }

        public bool CheckCategoryExists(Category category)
        {
            return GetAny(l => l.Id == category.Id);
        }
        public bool CheckCategoryExistsByData(Category category)
        {
            return GetAny(cat =>  cat.CatName == category.CatName);
        }
        public Category GetOCategoryById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}

