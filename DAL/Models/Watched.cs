using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Watched
    {
        public int id { get; set; }
        public int whatchedOrNot { get; set; }
        public int lessonContentID { get; set; }
        public string stID { get; set; }
        public int CrsID { get; set; }

        [ForeignKey("lessonContentID")]
        public virtual lessonContent LessonContent { get; set; }
        
        [ForeignKey("stID")]
        public virtual ApplicationStudentIdentity StudentIdentity { get; set; }

        [ForeignKey("CrsID")]
        public virtual Course Course { get; set; }
    }
}
