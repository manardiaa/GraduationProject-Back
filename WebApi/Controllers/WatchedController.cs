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
    public class WatchedController : ControllerBase
    {
        WatchedAppService watchedAppService;

        public WatchedController(WatchedAppService watchedAppService)
        {
            this.watchedAppService = watchedAppService;
        }

        [HttpGet]
        public IActionResult GetAllWatched()
        {
            return Ok(watchedAppService.GetAllWatched());
        }



        [HttpGet("{id}")]
        public IActionResult GetWatchedById(int id)
        {
            return Ok(watchedAppService.GetWatched(id));
        }
        [HttpGet("/CheckIfExist/{stId}/{crsID}/{lessonContentID}")]
        public bool CheckWatchedExistsByData(string stId,int crsID,int lessonContentID)
        {
            WatchedViewModel watch = watchedAppService.GetWatchedObj(stId, crsID, lessonContentID);
            return watchedAppService.CheckWatchedExistsByData(watch);
        }

        [HttpPost]
        public IActionResult Create(WatchedViewModel watchedViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!watchedAppService.CheckWatchedExistsByData(watchedViewModel))
                {
                    watchedAppService.SaveNewWatched(watchedViewModel);
                    return Created("CreateWatched", watchedViewModel);
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
        public IActionResult Edit(int id, WatchedViewModel watchedViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                watchedAppService.UpdateWatched(watchedViewModel);
                return Ok(watchedViewModel);
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
                watchedAppService.DeleteWatched(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
