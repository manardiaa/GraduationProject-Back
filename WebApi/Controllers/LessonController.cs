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
    public class LessonController : ControllerBase
    {
        LessonAppService lessonAppService;

        public LessonController(LessonAppService lessonAppService)
        {
            this.lessonAppService = lessonAppService;
        }

        [HttpGet]
        public IActionResult GetAllLessons()
        {
            return Ok(lessonAppService.AllLesson());
        }
        [HttpGet("{id}")]
        public IActionResult GetLessonById(int id)
        {
            return Ok(lessonAppService.Getlesson(id));
        }

        [HttpGet]
        [Route("LessonByLec/{id}")]
        public IActionResult GetLessonByLectureId(int id)
        {
            return Ok(lessonAppService.GetLessonByLecture(id));
        }
        [HttpGet]
        [Route("LessonByCrsID/{id}")]
        public IActionResult GetLessonByCrsId(int id)
        {
            return Ok(lessonAppService.GetAllLessonByCrsID(id));
        }
        [HttpPost]
        public IActionResult Create(lessonViewModel lessonViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                lessonAppService.SaveNewlesson(lessonViewModel);
                return Created("Create Lesson", lessonViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, lessonViewModel lessonViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                lessonAppService.Updatelesson(lessonViewModel);
                return Ok(lessonViewModel);
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
                lessonAppService.Deletelesson(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
