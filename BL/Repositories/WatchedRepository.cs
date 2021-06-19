using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bases;
using BL.Dtos;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Repositories
{
    public class WatchedRepository : BaseRepository<Watched>
    {

        private DbContext U_DbContext;

        public WatchedRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<Watched> GetAllWatched()
        {
            return GetAll().ToList();
        }

        public bool InsertWatched(Watched Watched)
        {
            return Insert(Watched);
        }
        public void UpdateWatched(Watched Watched)
        {
            Update(Watched);
        }
        public void DeleteWatched(int id)
        {
            Delete(id);
        }

        public bool CheckWatchedExists(Watched Watched)
        {
            return GetAny(l => l.id == Watched.id);
        }
        public bool CheckWatchedExistsByData(Watched watched)
        {
            return GetAny(l => l.stID == watched.stID && l.lessonContentID == watched.lessonContentID && l.CrsID == watched.CrsID);
        }

        public Watched GetOWatchedById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }

        public Watched GetWatchedObj(string stId, int crsID, int lessonContentID)
        {
            return GetFirstOrDefault(l => l.stID == stId && l.lessonContentID == lessonContentID && l.CrsID == crsID);
        }

        #endregion
    }
}

