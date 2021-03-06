using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("EnrollCourse")]
    public class EnrollCourse
    {
        public int Id { get; set; }
        public string EnrollDate { get; set; }
        public string EndEnrollDate { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("StudentId")]
        public ApplicationStudentIdentity ApplicationStudentIdentity { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
