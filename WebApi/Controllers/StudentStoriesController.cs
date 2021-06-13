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
    public class StudentStoriesController : ControllerBase
    {
        StudentStoriesAppService studentStoriesAppService;

        public StudentStoriesController(StudentStoriesAppService studentStoriesAppService)
        {
            this.studentStoriesAppService = studentStoriesAppService;
        }

        [HttpGet]
        public IActionResult GetAllStudentStories()
        {
            return Ok(studentStoriesAppService.GetAllStudentStories());
        }

        [HttpGet("TopFiveStdStories")]
        public IActionResult GetTopFiveStdStories()
        {
            return Ok(studentStoriesAppService.TopFiveStories());
        }

        [HttpGet]
        [Route("StdTopStory/{id}")]
        public IActionResult GetTopStudentStories(int id)
        {
            return Ok(studentStoriesAppService.GetTopStudentStories(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentStoriesById(int id)
        {
            return Ok(studentStoriesAppService.GetStudentStories(id));
        }

        [HttpPost]
        public IActionResult Create(StudentStoriesViewModel studentStoriesViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                studentStoriesAppService.SaveNewStudentStories(studentStoriesViewModel);
                return Created("Create StudentStories", studentStoriesViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, StudentStoriesViewModel studentStoriesViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                studentStoriesAppService.UpdateStudentStories(studentStoriesViewModel);
                return Ok(studentStoriesViewModel);
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
                studentStoriesAppService.DeleteStudentStories(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
