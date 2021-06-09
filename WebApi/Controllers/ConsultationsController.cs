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
    [Route("api/Consultations")]
    [ApiController]    
    public class ConsultationsController : ControllerBase
    {
        ConsultationAppService consultationAppService;

        public ConsultationsController(ConsultationAppService consultationAppService)
        {
            this.consultationAppService = consultationAppService;
        }

        [HttpGet]
        public IActionResult GetAllConsultation()
        {
            return Ok(consultationAppService.GetAllConsultations());
        }
        [HttpGet("{id}")]
        public IActionResult GetConsultationById(int id)
        {
            return Ok(consultationAppService.GetConsultation(id));
        }

        [HttpPost]
        public IActionResult Create(ConsultationViewModel consultationViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                consultationAppService.SaveNewConsultation(consultationViewModel);
                return Created("Create Consultation", consultationViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, ConsultationViewModel consultationViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                consultationAppService.UpdateConsultation(consultationViewModel);
                return Ok(consultationViewModel);
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
                consultationAppService.DeleteConsultation(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
