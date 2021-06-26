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
    public class lessonContentController : ControllerBase
    {
        LessonContentAppService _lessonContentAppService;

        public lessonContentController(LessonContentAppService lessonContentAppService)
        {
            this._lessonContentAppService = lessonContentAppService;
        }


        [HttpGet("CrsLessonContentCount/{crsId}")]
        public IActionResult lessonContentCount(int crsId)
        {
            return Ok(_lessonContentAppService.lessonContentCount(crsId));
        }

        [HttpGet("LessonContentByCrsID/{crsId}")]
        public IActionResult GetAllLessonContentByCrsID(int crsId)
        {
            return Ok(_lessonContentAppService.GetAllLessonContentByCrsID(crsId));
        }


        [HttpGet]
        public IActionResult GetAllLessonContent()
        {
            return Ok(_lessonContentAppService.AllLessonContent());
        }

        [HttpGet("FirstLessonContent/{lessonId}")]
        public IActionResult  GetFirstLessonContentByLessonId(int lessonId)
        {
            return Ok(_lessonContentAppService.GetFirstLessonContentByLessonId(lessonId));
        }


        [HttpGet("{id}")]
        public IActionResult GetLessonContentById(int id)
        {
            return Ok(_lessonContentAppService.GetlessonContent(id));
        }
        [HttpGet]
        [Route("LessonContentByLes/{id}")]
        public IActionResult GetLessonContentByLessonId(int id)
        {
            return Ok(_lessonContentAppService.GetLessonContentByLesson(id));
        }

        [HttpPost]
        public IActionResult Create(lessonContentViewModel LessonContentViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _lessonContentAppService.SaveNewlessonContent(LessonContentViewModel);
                return Created("CreateLessonContent", LessonContentViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, lessonContentViewModel LessonContentViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _lessonContentAppService.UpdatelessonContent(LessonContentViewModel);
                return Ok(LessonContentViewModel);
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
                _lessonContentAppService.DeletelessonContent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}