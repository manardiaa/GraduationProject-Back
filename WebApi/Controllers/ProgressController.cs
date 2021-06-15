using BL.AppServices;
using BL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        ProgressAppService _ProgressAppService;

        public ProgressController(ProgressAppService ProgressAppService)
        {
            this._ProgressAppService = ProgressAppService;
        }

        [HttpGet]
        public IActionResult GetAllProgress()
        {
            return Ok(_ProgressAppService.GetAllProgress());
        }




        [HttpGet("{id}")]
        public IActionResult GetProgressById(int id)
        {
            return Ok(_ProgressAppService.GetProgress(id));
        }

        [HttpPost]
        public IActionResult Create(ProgressViewModel ProgressViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _ProgressAppService.SaveNewProgress(ProgressViewModel);
                return Created("CreateProgress", ProgressViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, ProgressViewModel ProgressViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _ProgressAppService.UpdateProgress(ProgressViewModel);
                return Ok(ProgressViewModel);
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
                _ProgressAppService.DeleteProgress(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

