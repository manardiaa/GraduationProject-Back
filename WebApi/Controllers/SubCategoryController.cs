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
    public class SubCategoryController : ControllerBase
    {
        SubCategoryAppService subCategoryAppService;

        public SubCategoryController(SubCategoryAppService subCategoryAppService)
        {
            this.subCategoryAppService = subCategoryAppService;
        }

        [HttpGet]
        public IActionResult GetAllSubCategories()
        {
            return Ok(subCategoryAppService.GetAllSubCateogries());
        }
        [HttpGet("{id}")]
        public IActionResult GetSubCategoryById(int id)
        {
            return Ok(subCategoryAppService.GetSubCategory(id));
        }

        [HttpPost]
        public IActionResult Create(SubCategoryViewModel subCategoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                subCategoryAppService.SaveNewSubCategory(subCategoryViewModel);

                //string urlDetails = Url.Link("DefaultApi", new { id = subCategoryViewModel.ID });
                //return Created(urlDetails, "Added Sucess");
                return Created("Create SubCategory", subCategoryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, SubCategoryViewModel subCategoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                subCategoryAppService.UpdateSubCategory(subCategoryViewModel);
                return Ok(subCategoryViewModel);
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
                subCategoryAppService.DeleteSubCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
