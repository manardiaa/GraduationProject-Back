using BL.Bases;
using BL.Interfaces;
using BL.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;



namespace BL.AppServices
{
    public class OrderDetailsAppService : AppServiceBase
    {
        public OrderDetailsAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {



        }
        #region CURD



        public List<OrderDetailsViewModel> GetAllOrderProduct()
        {



            return Mapper.Map<List<OrderDetailsViewModel>>(TheUnitOfWork.OrderDetails.GetAllOrderDetails());
        }
   
        public bool SaveNewOrderProduct(OrderDetailsViewModel orderDetailsViewModel)
        {



            bool result = false;
            var orderDetails = Mapper.Map<OrderDetails>(orderDetailsViewModel);
            if (TheUnitOfWork.OrderDetails.Insert(orderDetails))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }




      
        #endregion
    }
}
