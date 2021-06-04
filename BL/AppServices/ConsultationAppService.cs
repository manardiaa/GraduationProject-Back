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
    public class ConsultationAppService : AppServiceBase
    {
        public ConsultationAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<ConsultationViewModel> GetAllConsultations()
        {

            return Mapper.Map<List<ConsultationViewModel>>(TheUnitOfWork.consultation.GetAllConsultations());
        }
        public ConsultationViewModel GetConsultation(int id)
        {
            return Mapper.Map<ConsultationViewModel>(TheUnitOfWork.consultation.GetById(id));
        }
        public bool SaveNewConsultation(ConsultationViewModel consultationViewModel)
        {
            if (consultationViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var consultation = Mapper.Map<Consultation>(consultationViewModel);
            if (TheUnitOfWork.consultation.InsertConsultation(consultation))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateConsultation(ConsultationViewModel consultationViewModel)
        {
            var consultation = Mapper.Map<Consultation>(consultationViewModel);
            TheUnitOfWork.consultation.Update(consultation);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteConsultation(int id)
        {
            bool result = false;

            TheUnitOfWork.consultation.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckConsultationExists(ConsultationViewModel consultationViewModel)
        {
            var consultation = Mapper.Map<Consultation>(consultationViewModel);
            return TheUnitOfWork.consultation.CheckConsultationExists(consultation);
        }
        #endregion



    }
}
