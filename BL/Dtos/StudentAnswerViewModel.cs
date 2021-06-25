using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos

{
    public class StudentAnswerViewModel
    {
        public int id { get; set; }
        public string Studentanswer { get; set; }
        public int QuestionId { get; set; }     
        public string StudentId { get; set; }
        public int lessonContentId { get; set; }



    }
}
