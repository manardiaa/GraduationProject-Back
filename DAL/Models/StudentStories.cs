using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("StudentStories")]
    public class StudentStories
    {
        public int Id { get; set; }
        public string Specialzation { get; set; }
        public string Story { get; set; }
        public string StudentId { get; set; }
        public int ShowOrNot { get; set; } = 0;

        [ForeignKey("StudentId")]
        public ApplicationStudentIdentity ApplicationStudentIdentity { get; set; }

    }
}
