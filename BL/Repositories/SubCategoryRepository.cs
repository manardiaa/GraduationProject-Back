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
    public class SubCategoryRepository : BaseRepository<SubCategory>
    {

        private DbContext U_DbContext;

        public SubCategoryRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<SubCategory> GetAllSubCategory()
        {
            return GetAll().ToList();
        }

        public bool InsertSubCategory(SubCategory subCategory)
        {
            return Insert(subCategory);
        }
        public void UpdateSubCategory(SubCategory subCategory)
        {
            Update(subCategory);
        }
        public void DeleteSubCategory(int id)
        {
            Delete(id);
        }

        public bool CheckSubCategoryExists(SubCategory subCategory)
        {
            return GetAny(l => l.ID == subCategory.ID);
        }
        public SubCategory GetSubCategoryById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion
    }
}

