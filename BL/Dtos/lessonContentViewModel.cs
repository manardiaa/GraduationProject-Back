using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos

{
    public class lessonContentViewModel
    {
        [Key]
        public int Id { get; set; }
        public int VideoLinkId { get; set; }
        public int QuestionGroupId { get; set; }
        public int LessonId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public int crsID { get; set; }
        public int LectureID { get; set; }


    }
}
