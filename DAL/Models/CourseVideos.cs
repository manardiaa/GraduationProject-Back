using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("CourseVideos")]
    public class CourseVideos
    {
      
        public int Id { get; set; }
        public int LessonId { get; set; }  
        public int CourseId { get; set; }
        public string VideoURL { get; set; }
        public string VideoName { get; set; }

        [ForeignKey("CourseId")]  
        public virtual Course Course { get; set; }
        [ForeignKey("LessonId")]  
        public virtual lesson Lesson{ get; set; }
        
    }
}
