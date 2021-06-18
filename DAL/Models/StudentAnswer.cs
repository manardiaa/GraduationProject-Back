using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StudentAnswer
    {
        public int id { get; set; }
        public string Studentanswer { get; set; }
        public int QuestionId { get; set; }
        public int lessonContentId { get; set; }
        public string StudentId { get; set; }

        [ForeignKey("lessonContentId")]
        public virtual lessonContent lessonContent { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        [ForeignKey("StudentId")]
        public virtual ApplicationStudentIdentity Student { get; set; }



    }
}
