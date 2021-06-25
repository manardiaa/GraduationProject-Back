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
    public class QuestionGroupController : ControllerBase
    {        
        QuestionGroupAppService questionGroupAppService;

        public QuestionGroupController(QuestionGroupAppService questionGroupAppService)
        {
            this.questionGroupAppService = questionGroupAppService;
        }

        [HttpGet]
        public IActionResult GetAllQuestionGroup()
        {
            return Ok(questionGroupAppService.AllQuestionsGroup());
        }

        [HttpGet("QuestionGroupsByIds/{crsId}/{lectID}/{lessonID}")]
        public IActionResult GetQuestionGroupsByIds(int crsId, int lectID, int lessonID)
        {
            return Ok(questionGroupAppService.GetQuestionGroupsByIds(crsId,lectID,lessonID));
        }
        [HttpGet("QuestionGroupsBylessonIds/{lessonID}")]
        public IActionResult GetAllQuestionGroupBylessontId(int lessonID)
        {
            return Ok(questionGroupAppService.GetAllQuestionGroupBylessontId(lessonID));
        }
        [HttpGet("QuestionGroupByCrsID/{CrsID}")]
        public IActionResult GetAllQuestionGroupByCrsID(int CrsID)
        {
            return Ok(questionGroupAppService.GetAllQuestionGroupByCrsID(CrsID));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetQuestionGroupById(int id)
        {
            return Ok(questionGroupAppService.GetQuestionGroup(id));
        }

        [HttpPost]
        public IActionResult Create(QuestionGroupViewModel questionGroupViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                questionGroupAppService.SaveNewQuestionGroup(questionGroupViewModel);
                return Created("Create Lesson", questionGroupViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, QuestionGroupViewModel questionGroupViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                questionGroupAppService.UpdateQuestionGroup(questionGroupViewModel);
                return Ok(questionGroupViewModel);
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
                questionGroupAppService.DeleteQuestionGroup(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

