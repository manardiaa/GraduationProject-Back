using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos

{
    public class QuestionGroupViewModel
    { 
        
        public int Id { get; set; }
        public string title { get; set; }
        public int QGroupID { get; set; }
        public int LectureId { get; set; }
        public int CourseId { get; set; }
        public int LessonId   { get; set; }        
       

    }
}
