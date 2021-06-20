using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
        public int ContentNumber { get; set; }
        public float Duration { get; set; }
        public int LectureId { get; set; }
        public int CrsId { get; set; }

        [ForeignKey("LectureId")]
        public virtual lecture Lecture { get; set; }

        [ForeignKey("CrsId")]
        public virtual Course Course { get; set; }
        public List<lessonContent> lessonesContent { get; set; } = new List<lessonContent>();

    }
}
