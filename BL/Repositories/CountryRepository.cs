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
    public class CountryRepository : BaseRepository<Country>
    {

        private DbContext U_DbContext;

        public CountryRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<Country> GetAllCountries()
        {
            return GetAll().ToList();
        }

        public bool InsertCountry(Country country)
        {
            return Insert(country);
        }
        public void UpdateCountry(Country country)
        {
            Update(country);
        }
        public void DeleteCountry(int id)
        {
            Delete(id);
        }

        public bool CheckCountryExists(Country country)
        {
            return GetAny(l => l.id == country.id);
        }
        public Country GetOCountryById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }

        
        #endregion
    }
}

