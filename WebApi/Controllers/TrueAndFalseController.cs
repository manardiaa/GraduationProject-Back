using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.AppServices;
using BL.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrueAndFalseController : ControllerBase
    {

        TrueAndFalseAppService trueAndFalseAppService;

        public TrueAndFalseController(TrueAndFalseAppService trueAndFalseAppService)
        {
            this.trueAndFalseAppService = trueAndFalseAppService;
        }

        [HttpGet]
        public IActionResult GetAllStudentAnswers()
        {
            return Ok(trueAndFalseAppService.AllTrueAndFalse());
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentAnswersById(int id)
        {
            return Ok(trueAndFalseAppService.GetTrueAndFalse(id));
        }

        [HttpPost]
        public IActionResult Create(TrueAndFalseViewModel trueAndFalseViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                trueAndFalseAppService.SaveNewTrueAndFalse(trueAndFalseViewModel);
                return Created("True And False Added", trueAndFalseViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, TrueAndFalseViewModel trueAndFalseViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                trueAndFalseAppService.UpdateTrueAndFalse(trueAndFalseViewModel);
                return Ok(trueAndFalseViewModel);
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
                trueAndFalseAppService.DeleteTrueAndFalse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

