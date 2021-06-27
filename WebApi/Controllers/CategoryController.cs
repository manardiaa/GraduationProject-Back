﻿using BL.AppServices;
using BL.StaticClasses;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/Category")]
    [ApiController]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        CategoryAppService _categoryAppService;

        public CategoryController(CategoryAppService categoryAppService)
        {
            this._categoryAppService = categoryAppService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryAppService.GetAllCateogries());
        }
        [Route("/school-of/{name}")]
        [HttpGet]
        public IActionResult GetCategoryByName(string name)
        {
            return Ok(_categoryAppService.GetIdCategoryByName(name));
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_categoryAppService.GetCategory(id));
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!_categoryAppService.CheckCategoryExistsByData(categoryViewModel))
                { 
                 _categoryAppService.SaveNewCategory(categoryViewModel);
                
                //string urlDetails = Url.Link("DefaultApi", new { id = categoryViewModel.ID });
                //return Created(urlDetails, "Added Sucess");
                return Created("CreateCategory" , categoryViewModel);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, CategoryViewModel categoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _categoryAppService.UpdateCategory(categoryViewModel);
                return Ok(categoryViewModel);
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
                _categoryAppService.DeleteCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
  
    }
}
