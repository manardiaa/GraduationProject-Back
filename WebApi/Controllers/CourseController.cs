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
    public class CourseController : ControllerBase
    {
        CourseAppService _courseAppService;

        public CourseController(CourseAppService courseAppService)
        {
            this._courseAppService = courseAppService;
        }

        [HttpGet]
        //       api/Course
        public IActionResult GetAllCourses()
        {
            return Ok(_courseAppService.GetAllCourses());
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            return Ok(_courseAppService.GetCourse(id));
        }

        [HttpGet("/CourseByCategory/{Catid}")]

        public IActionResult GetCrsListByCatid(int Catid)
        {
            return Ok(_courseAppService.GetAllCrsByCatID(Catid));
        }
        
        [HttpGet("/GetTopTwoCrs/{Catid}")]
        public IActionResult GetListOfTwoCrs(int Catid)
        {
            return Ok(_courseAppService.GetListOfTwoCrsByCatID(Catid));
        }


        [HttpGet("/PrevCrs")]
        public IActionResult PrevFourCourses(int CatId)
        {
            return Ok(_courseAppService.GetFristFourCoures(CatId));
        }
        [HttpGet("/NextCrs")]
        public IActionResult NextFourCourses(int CatId)
        {
            return Ok(_courseAppService.GetNextFourCourses(CatId));
        }



        [HttpPost]
        public IActionResult Create(CourseViewModel courseViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!_courseAppService.CheckCourseExistsByData(courseViewModel))
                {
                    _courseAppService.SaveNewCourse(courseViewModel);
                    return Created("CreateCourse", courseViewModel);
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
        public IActionResult Edit(int id, CourseViewModel courseViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _courseAppService.UpdateCourse(courseViewModel);
                return Ok(courseViewModel);
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
                _courseAppService.DeleteCourse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
