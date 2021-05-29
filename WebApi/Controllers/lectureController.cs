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
    public class lectureController : ControllerBase
    {

        LectureAppService _lectureAppService;

        public lectureController(LectureAppService lectureAppService)
        {
            this._lectureAppService = lectureAppService;
        }

        [HttpGet]
        public IActionResult GetAllLecture()
        {
            return Ok(_lectureAppService.AllLecture());
        }
        [HttpGet("{id}")]
        public IActionResult GetLectureById(int id)
        {
            return Ok(_lectureAppService.GetLecture(id));
        }

        [HttpPost]
        public IActionResult Create(lectureViewModel LectureViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _lectureAppService.SaveNewlecture(LectureViewModel);
                return Created("CreateLecture", LectureViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, lectureViewModel LectureViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _lectureAppService.Updatelecture(LectureViewModel);
                return Ok(LectureViewModel);
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
                _lectureAppService.Deletelecture(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
