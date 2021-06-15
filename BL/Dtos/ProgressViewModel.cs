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
    public class ProgressViewModel
    {
        public int Id { get; set; }
        public int NumOfLesson { get; set; }
        public int NumOfLessonFinshed { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }





    }
}

