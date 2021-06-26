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
    public class EnrollCourseController : ControllerBase
    {
        EnrollCourseAppService _enrollcourseAppService;

        public EnrollCourseController(EnrollCourseAppService enrollcourseAppService)
        {
            this._enrollcourseAppService = enrollcourseAppService;
        }

        [HttpGet]
        public IActionResult GetAllEnrollCourses()
        {
            return Ok(_enrollcourseAppService.GetAllEnrollCourses());
        }

        [HttpGet("/AllStdEnrollCourses/{Stid}")]
        public IActionResult GetAllStdEnrollCourses(string Stid)
        {
            return Ok(_enrollcourseAppService.GetAllCrsOfStd(Stid));
        }


        [HttpGet("{id}")]
        public IActionResult GetEnrollCourseById(int id)
        {
            return Ok(_enrollcourseAppService.GetEnrollCourse(id));
        }
        [HttpGet("EnrollCrs/{crsid}/{stid}")]
        public IActionResult GetEnrollCourse(int crsid,string stid)
        {
            return Ok(_enrollcourseAppService.GetEnrollCourse(stid,crsid));
        }

        [HttpPost]
        public IActionResult Create(EnrollCourseViewModel enrollcourseViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if(!_enrollcourseAppService.CheckIfCrsEnrollExist(enrollcourseViewModel))
                {
                    _enrollcourseAppService.SaveNewEnrollCourse(enrollcourseViewModel);
                    return Created("CreateEnrollCourse", enrollcourseViewModel);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, EnrollCourseViewModel enrollcourseViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _enrollcourseAppService.UpdateEnrollCourse(enrollcourseViewModel);
                return Ok(enrollcourseViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("Test/{id}")]
       [HttpDelete("{id}")]
        public IActionResult DeleteCrsEnrollment(int id)
        {
            try
            {
                _enrollcourseAppService.DeleteEnrollCourse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
