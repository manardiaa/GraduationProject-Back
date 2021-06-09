using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Dtos
{​​​​​​​
    public class OrderDetailsViewModel
    {​​​​​​​
        public int ID {​​​​​​​ get; set; }​​​​​​​
        [Display(Name = "Total Price")]
        public double TotalCourse {​​​​​​​ get; set; }​​​​​​​
   
        [Display(Name = "Discount")]
        public double CourseDiscount {​​​​​​​ get; set; }​​​​​​​
        [Display(Name = "Net Price")]
        public double CourseNetPrice {​​​​​​​ get; set; }​​​​​​​
      
    
        public int CourseID {​​​​​​​ get; set; }​​​​​​​
        public int orderID {​​​​​​​ get; set; }​​​​​​​

       public string CourseName {​​​​​​​ get; set; }​​​​​​​
    }​​​​​​​
   
}​​​​​​​
 
