using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class lessonContent
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

        [ForeignKey("QuestionGroupId")]
        public virtual QuestionGroup QustionGroup { get; set; }

        [ForeignKey("crsID")]
        public virtual Course Course { get; set; }

        [ForeignKey("LectureID")]
        public virtual lecture Lecture { get; set; }

        [ForeignKey("VideoLinkId")]
        public virtual CourseVideos VideoLink { get; set; }

        [ForeignKey("LessonId")]
        public virtual lesson Lesson { get; set; }

    }
}
