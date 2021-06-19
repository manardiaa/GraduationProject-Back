using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }     
        public string Type { get; set; }
        public int LessonContentId { get; set; }
        [ForeignKey("LessonContentId")]
        public virtual lessonContent LessonContent { get; set; }
        public int QuestionGroupId { get; set; }
        [ForeignKey("QuestionGroupId")]
        public virtual QuestionGroup QustionGroup { get; set; }


    }
}
