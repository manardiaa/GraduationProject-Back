using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos

{
    public class EnrollCourseViewModel
    { 
        public int Id { get; set; }
        public string EnrollDate { get; set; }
        public string EndEnrollDate { get; set; }
       public string StudentId { get; set; }
        public int CourseId { get; set; }
     




    }
}
