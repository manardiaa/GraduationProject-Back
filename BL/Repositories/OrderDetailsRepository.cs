using BL.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;



using Microsoft.EntityFrameworkCore;



namespace BL.Repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>
    {
        private DbContext U_DbContext;



        public OrderDetailsRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }







        public List<OrderDetails> GetAllOrderDetails()
        {
            return GetAll().Include(op => op.Course).ToList();
        }



        public bool InsertOrderDetails(OrderDetails orderDetails)
        {
            return Insert(orderDetails);
        }
        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            Update(orderDetails);
        }
       



    }
}

