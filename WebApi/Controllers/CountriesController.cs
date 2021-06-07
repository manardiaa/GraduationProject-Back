using BL.AppServices;
using BL.StaticClasses;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/Country")]
    [ApiController]
    //[Authorize]
    public class CountryController : ControllerBase
    {
        CountryAppService _countryAppService;

        public CountryController(CountryAppService countryAppService)
        {
            this._countryAppService = countryAppService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_countryAppService.GetAllCountries());
        }
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            return Ok(_countryAppService.GetCountry(id));
        }

        [HttpPost]
        public IActionResult Create(CountryViewModel countryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _countryAppService.SaveNewCountry(countryViewModel);
                return Created("Create Country", countryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, CountryViewModel countryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _countryAppService.UpdateCountry(countryViewModel);
                return Ok(countryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _countryAppService.DeleteCountry(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
