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
    public class StudentAnswerController : ControllerBase
    {
        StudentAnswerAppService studentAnswerAppService;

        public StudentAnswerController(StudentAnswerAppService studentAnswerAppService)
        {
            this.studentAnswerAppService = studentAnswerAppService;
        }

        [HttpGet]
        public IActionResult GetAllStudentAnswers()
        {
            return Ok(studentAnswerAppService.AllStudentAnswer());
        }
        [HttpGet]
        [Route("GetAllStudentAnswersByLessonContent/{id}/{stId}")]
        public IActionResult GetAllStudentAnswersByLessonContent(int id,string stId)
        {
            return Ok(studentAnswerAppService.GetStudentAnswersByLessonContentId(id,stId));
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentAnswersById(int id)
        {
            return Ok(studentAnswerAppService.GetStudentAnswer(id));
        }

        [HttpPost]
        public IActionResult Create(StudentAnswerViewModel studentAnswerViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if(!studentAnswerAppService.CheckIfAnswerExist(studentAnswerViewModel))
                studentAnswerAppService.SaveNewStudentAnswer(studentAnswerViewModel);
                return Created("Student Answer Added", studentAnswerViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, StudentAnswerViewModel studentAnswerViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                studentAnswerAppService.UpdateStudentAnswer(studentAnswerViewModel);
                return Ok(studentAnswerViewModel);
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
                studentAnswerAppService.DeleteStudentAnswer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

