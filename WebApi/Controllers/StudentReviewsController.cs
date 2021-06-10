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
    public class StudentReviewsController : ControllerBase
    {
        StudentReviewsAppService studentReviewsAppService;

        public StudentReviewsController(StudentReviewsAppService studentReviewsAppService)
        {
            this.studentReviewsAppService = studentReviewsAppService;
        }

        [HttpGet]
        public IActionResult GetAllstudentReviews()
        {
            return Ok(studentReviewsAppService.GetAllStudentReviews());
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentReviewsById(int id)
        {
            return Ok(studentReviewsAppService.GetStudentReviews(id));
        } 
        [HttpGet("topFourReviews")]
        public IActionResult GetTopFourStdReviews()
        {
            return Ok(studentReviewsAppService.TopFourStdReviews());
        }

        [HttpPost]
        public IActionResult Create(StudentReviewsViewModel studentReviewsViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                studentReviewsAppService.SaveNewStudentReviews(studentReviewsViewModel);
                return Created("Create StudentReviews", studentReviewsViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, StudentReviewsViewModel studentReviewsViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                studentReviewsAppService.UpdateStudentReviews(studentReviewsViewModel);
                return Ok(studentReviewsViewModel);
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
                studentReviewsAppService.DeleteStudentReviews(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
