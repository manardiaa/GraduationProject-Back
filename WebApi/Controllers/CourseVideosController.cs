﻿using BL.AppServices;
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
    public class CourseVideosController : ControllerBase
    {
        CourseVideosAppService _courseVideosAppService;

        public CourseVideosController(CourseVideosAppService courseVideosAppService)
        {
            this._courseVideosAppService = courseVideosAppService;
        }

        [HttpGet]
        public IActionResult GetAllCoursesVideos()
        {
            return Ok(_courseVideosAppService.GetAllCoursesVideos());
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseVideosById(int id)
        {
            return Ok(_courseVideosAppService.GetCourseVideos(id));
        }

        [HttpPost]
        public IActionResult Create(CourseVideosViewModel courseVideosViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _courseVideosAppService.SaveNewCourseVideos(courseVideosViewModel);
                return Created("CreateCourseVideos", courseVideosViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, CourseVideosViewModel courseVideosViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _courseVideosAppService.UpdateCourseVideos(courseVideosViewModel);
                return Ok(courseVideosViewModel);
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
                _courseVideosAppService.DeleteCourseVideos(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}