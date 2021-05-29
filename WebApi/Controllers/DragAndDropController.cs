using BL.AppServices;
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
    public class DragAndDropController : ControllerBase
    {
        DragAndDropAppService _dragAndDropAppService;

        public DragAndDropController(DragAndDropAppService dragAndDropAppService)
        {
            this._dragAndDropAppService = dragAndDropAppService;
        }

        [HttpGet]
        public IActionResult GetAllDragAndDrop()
        {
            return Ok(_dragAndDropAppService.GetAllDragAndDrop());
        }
        [HttpGet("{id}")]
        public IActionResult GetDragAndDropById(int id)
        {
            return Ok(_dragAndDropAppService.GetDragAndDrop(id));
        }

        [HttpPost]
        public IActionResult Create(DragAndDropViewModel dragAndDropViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dragAndDropAppService.SaveNewDragAndDrop(dragAndDropViewModel);
                return Created("CreateDragAndDrop", dragAndDropViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, DragAndDropViewModel dragAndDropViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dragAndDropAppService.UpdateDragAndDrop(dragAndDropViewModel);
                return Ok(dragAndDropViewModel);
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
                _dragAndDropAppService.DeleteDragAndDrop(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
