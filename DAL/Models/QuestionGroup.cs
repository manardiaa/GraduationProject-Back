using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class QuestionGroup
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int QGroupID { get; set; }
        public int LectureId { get; set; }
        public int CourseId { get; set; }
        public int LessonId   { get; set; }
       
        [ForeignKey("LectureId")]
        public virtual lecture Lecture { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("LessonId")]
        public virtual lesson Lesson { get; set; }               

    }
}
