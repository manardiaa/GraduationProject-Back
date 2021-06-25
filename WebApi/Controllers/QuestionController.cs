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
    public class QuestionController : ControllerBase
    {
        QuestionAppService questionAppService;

        public QuestionController(QuestionAppService questionAppService)
        {
            this.questionAppService = questionAppService;
        }

        [HttpGet]
        public IActionResult GetAllQuestion()
        {
            return Ok(questionAppService.AllQuestions());
        }  
        [HttpGet("GetAllQuestionbyIds/{lessonContentId}/{questionGroupId}")]
        public IActionResult GetAllQuestionbyIds(int lessonContentId, int questionGroupId)
        {
            return Ok(questionAppService.GetAllQuestionbyIds(lessonContentId, questionGroupId));
        }
        [HttpGet("QstTypeList/{type}")]
        public IActionResult GetAllQuestionType(string type)
        {
            return Ok(questionAppService.GetAllQuestionByType(type));
        }
        [HttpGet("{id}")]
        public IActionResult GetQuestionById(int id)
        {
            return Ok(questionAppService.GetQuestions(id));
        }
        [HttpGet]
        [Route("QuestionByLessonContent/{id}")]
        public IActionResult QuestionByLessonContent(int id)
        {
            return Ok(questionAppService.GetAllQuestionByLessonContent(id));
        }

        [HttpPost]
        public IActionResult Create(QuestionViewModel questionViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                questionAppService.SaveNewQuestions(questionViewModel);
                return Created("Create Question", questionViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, QuestionViewModel questionViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                questionAppService.UpdateQuestions(questionViewModel);
                return Ok(questionViewModel);
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
                questionAppService.DeleteQuestions(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
