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
    public class DragAndDropRepository : BaseRepository<DragAndDrop>
    {

        private DbContext U_DbContext;

        public DragAndDropRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<DragAndDrop> GetAllDragAndDrop()
        {
            return GetAll().ToList();
        }

        public bool InsertDragAndDrop(DragAndDrop dragAndDrop)
        {
            return Insert(dragAndDrop);
        }
        public void UpdateDragAndDrop(DragAndDrop dragAndDrop)
        {
            Update(dragAndDrop);
        }
        public void DeleteDragAndDrop(int id)
        {
            Delete(id);
        }

        public bool CheckDragAndDropExists(DragAndDrop dragAndDrop)
        {
            return GetAny(l => l.id == dragAndDrop.id);
        }
        public DragAndDrop GetODragAndDropById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }
        #endregion
    }
}

