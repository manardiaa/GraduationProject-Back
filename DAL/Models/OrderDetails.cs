using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }



        public double CourseTotal { get; set; }
        public double CourseDiscount { get; set; }
        public double CourseNetPrice { get; set; }
   



        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public Course Course { get; set; }



        [ForeignKey("Order")]
        public int orderID { get; set; }

        public Order Order { get; set; }



    }
}
