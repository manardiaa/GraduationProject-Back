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
    public class EnrollCourseController : ControllerBase
    {
        EnrollCourseAppService _enrollcourseAppService;

        public EnrollCourseController(EnrollCourseAppService enrollcourseAppService)
        {
            this._enrollcourseAppService = enrollcourseAppService;
        }

        [HttpGet]
        public IActionResult GetAllEnrollCourses()
        {
            return Ok(_enrollcourseAppService.GetAllEnrollCourses());
        }
        [HttpGet("{id}")]
        public IActionResult GetEnrollCourseById(int id)
        {
            return Ok(_enrollcourseAppService.GetEnrollCourse(id));
        }

        [HttpPost]
        public IActionResult Create(EnrollCourseViewModel enrollcourseViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _enrollcourseAppService.SaveNewEnrollCourse(enrollcourseViewModel);
                return Created("CreateEnrollCourse", enrollcourseViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, EnrollCourseViewModel enrollcourseViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _enrollcourseAppService.UpdateEnrollCourse(enrollcourseViewModel);
                return Ok(enrollcourseViewModel);
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
                _enrollcourseAppService.DeleteEnrollCourse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
