
using BL.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

 

using DAL.Models;
using Microsoft.EntityFrameworkCore;

 

namespace BL.Repositories
    {
        public class OrderRepository : BaseRepository<Order>
        {
            private DbContext U_DbContext;



            public OrderRepository(DbContext U_DbContext) : base(U_DbContext)
            {
                this.U_DbContext = U_DbContext;
            }
            #region CRUB



            public List<Order> GetAllOrder()
            {
                return GetAll().Include(order => order.appUser).ToList();
            }



            public bool InsertOrder(Order order)
            {
                return Insert(order);
            }
            public void UpdateOrder(Order order)
            {
                Update(order);
            }
            public void DeleteOrder(int id)
            {
                Delete(id);
            }



            public bool CheckOrderExists(Order order)
            {
                return GetAny(l => l.Id == order.Id);
            }
            public Order GetOrderById(int id)
            {
                return GetFirstOrDefault(l => l.Id == id);
            }



            #endregion
           

          
          

            



        }
    }

