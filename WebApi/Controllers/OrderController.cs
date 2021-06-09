using BL.AppServices;
using BL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderAppService _orderAppService;
        CourseAppService _courseAppService;
        OrderDetailsAppService _orderDetailsAppService;
        IHttpContextAccessor _httpContextAccessor;
        public OrderController(OrderAppService orderAppService,
            CourseAppService courseAppService,
            OrderDetailsAppService orderDetailsAppService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._orderAppService = orderAppService;
            this._courseAppService = courseAppService;
            this._orderDetailsAppService = orderDetailsAppService;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(_orderAppService.GetAllOrder());
        }


        [HttpPost]
        public IActionResult makeOrder(OrderDetailsViewModel orderDetailsViewModel)//, double totalOrderPrice)
        {

            //get cart id of current logged user

            var userID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            OrderViewModel orderViewModel = new OrderViewModel
            {
                date = DateTime.Now.ToString(),

                totalPrice = orderDetailsViewModel.totalOrderPrice,
                ApplicationStudentIdentity_Id = userID

            };
            _orderAppService.SaveNewOrder(orderViewModel);
           
            return Ok();
        }



        //[HttpGet]
        //Route[("api/[controller]/{id}")]
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {

            var orderProductViewModels = _orderDetailsAppService.GetAllOrderProduct().Where(op => op.orderID == id).ToList();

            return Ok(_orderDetailsAppService.GetAllOrderProduct().Where(op => op.orderID == id).ToList());
        }
       
       
    }
}
