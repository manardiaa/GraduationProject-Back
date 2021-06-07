using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("lecture")]
    public class lecture
    {
        public int Id { get; set; }
        public string Tilte { get; set; }
        public int CourseId { get; set;}
        public int lessoneNumber { get; set; }
        public string LectureDescription { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public List<lesson> lessones { get; set; } = new List<lesson>();

    }
}
