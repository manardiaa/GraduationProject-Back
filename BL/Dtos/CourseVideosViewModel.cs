using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class CourseVideosViewModel
    {
      
        public int Id { get; set; }
        public int LessonId { get; set; }  
        public int CourseId { get; set; }  
        public string VideoURL { get; set; }
        public string VideoName { get; set; }


    }
}
