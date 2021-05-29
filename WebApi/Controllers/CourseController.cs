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
    public class CourseController : ControllerBase
    {
        CourseAppService _courseAppService;

        public CourseController(CourseAppService courseAppService)
        {
            this._courseAppService = courseAppService;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Ok(_courseAppService.GetAllCourses());
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            return Ok(_courseAppService.GetCourse(id));
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
                _courseAppService.SaveNewCourse(courseViewModel);
                return Created("CreateCourse", courseViewModel);
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