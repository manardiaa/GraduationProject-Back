using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.AppServices;
using BL.StaticClasses;
using BL.Dtos;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorOrInstractorStoriesController : ControllerBase
    {
        MentorOrInstractorStoriesAppService mentorOrInstractorStoriesApp;

        public MentorOrInstractorStoriesController(MentorOrInstractorStoriesAppService mentorOrInstractorStoriesApp)
        {
            this.mentorOrInstractorStoriesApp = mentorOrInstractorStoriesApp;
        }

        [HttpGet]
        public IActionResult GetAllmentorOrInstractor()
        {
            return Ok(mentorOrInstractorStoriesApp.GetAllMentorOrInstractorStoriess());
        } 
        [HttpGet("TopFourInstStories")]
        public IActionResult TopFourInstStories()
        {
            return Ok(mentorOrInstractorStoriesApp.GetFourInstractors());
        }

        [HttpGet("InstractorsStories")]
        public IActionResult AllInstractors()
        {
            return Ok(mentorOrInstractorStoriesApp.GetAllInstractor());
        }
        [HttpGet("MentorStories")]
        public IActionResult AllMentor()
        {
            return Ok(mentorOrInstractorStoriesApp.GetAllMentors());
        }

        [HttpGet("TopFourMentors")]
        public IActionResult TopFourMentorStories()
        {
            return Ok(mentorOrInstractorStoriesApp.GetFourMentors());
        }

        [HttpGet("{id}")]
        public IActionResult GetmentorOrInstractorById(int id)
        {
            return Ok(mentorOrInstractorStoriesApp.GetMentorOrInstractorStories(id));
        }

        [HttpPost]
        public IActionResult Create(MentorOrInstractorStoriesViewModel mentorOrInstractorStoriesViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                mentorOrInstractorStoriesApp.SaveNewMentorOrInstractorStories(mentorOrInstractorStoriesViewModel);
                return Created("Create mentorOrInstractor", mentorOrInstractorStoriesViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, MentorOrInstractorStoriesViewModel mentorOrInstractorStoriesViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                mentorOrInstractorStoriesApp.UpdateMentorOrInstractorStories(mentorOrInstractorStoriesViewModel);
                return Ok(mentorOrInstractorStoriesViewModel);
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
                mentorOrInstractorStoriesApp.DeleteMentorOrInstractorStories(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
