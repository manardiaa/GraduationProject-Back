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
    public class CountryAppService : AppServiceBase
    {
        public CountryAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<CountryViewModel> GetAllCountries()
        {

            return Mapper.Map<List<CountryViewModel>>(TheUnitOfWork.country.GetAllCountries());
        }
        public CountryViewModel GetCountry(int id)
        {
            return Mapper.Map<CountryViewModel>(TheUnitOfWork.country.GetById(id));
        }
        public bool SaveNewCountry(CountryViewModel countryViewModel)
        {
            if (countryViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var country = Mapper.Map<Country>(countryViewModel);
            if (TheUnitOfWork.country.InsertCountry(country))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCountry(CountryViewModel countryViewModel)
        {
            var country = Mapper.Map<Country>(countryViewModel);
            TheUnitOfWork.country.Update(country);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCountry(int id)
        {
            bool result = false;

            TheUnitOfWork.country.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCountryExists(CountryViewModel countryViewModel)
        {
            var country = Mapper.Map<Country>(countryViewModel);
            return TheUnitOfWork.country.CheckCountryExists(country);
        }
        #endregion



    }
}
