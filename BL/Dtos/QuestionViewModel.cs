using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.Dtos

{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }     
        public string Type { get; set; }
        public int QuestionGroupId { get; set; }
        public int LessonContentId { get; set; }


    }
}
