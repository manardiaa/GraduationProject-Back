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
    public class ConsultationRepository : BaseRepository<Consultation>
    {

        private DbContext U_DbContext;

        public ConsultationRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<Consultation> GetAllConsultations()
        {
            return GetAll().ToList();
        }

        public bool InsertConsultation(Consultation consultation)
        {
            return Insert(consultation);
        }
        public void UpdateConsultation(Consultation consultation)
        {
            Update(consultation);
        }
        public void DeleteConsultation(int id)
        {
            Delete(id);
        }

        public bool CheckConsultationExists(Consultation consultation)
        {
            return GetAny(l => l.Id == consultation.Id);
        }
        public Consultation GetOConsultationById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}

