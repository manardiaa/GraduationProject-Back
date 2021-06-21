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
    public class QuestionOptionsController : ControllerBase
    {

        QuestionOptionsAppService questionOptionsAppService;

        public QuestionOptionsController(QuestionOptionsAppService questionOptionsAppService)
        {
            this.questionOptionsAppService = questionOptionsAppService;
        }

        [HttpGet]
        public IActionResult GetAllQuestionOptions()
        {
            return Ok(questionOptionsAppService.AllQuestionOptions());
        }


        [HttpGet("GetQuestionOptByQuestionID/{QID}")]
        public IActionResult GetQuestionOptByQuestionID(int QID)
        {
            return Ok(questionOptionsAppService.GetQuestionOptByQuestionID(QID));
        }


        [HttpGet("{id}")]
        public IActionResult GetQuestionOptionsById(int id)
        {
            return Ok(questionOptionsAppService.GetQuestionOptions(id));
        }

        [HttpPost]
        public IActionResult Create(QuestionOptionsViewModel questionOptionsViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                questionOptionsAppService.SaveNewQuestionOptions(questionOptionsViewModel);
                return Created("Create Question Options", questionOptionsViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, QuestionOptionsViewModel questionOptionsViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                questionOptionsAppService.UpdateQuestionOptions(questionOptionsViewModel);
                return Ok(questionOptionsViewModel);
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
                questionOptionsAppService.DeleteQuestionOptions(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
