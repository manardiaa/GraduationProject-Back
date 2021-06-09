using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL.Models
{
    public class StudentReviews
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public int Rate { get; set; }
        public string StdReviews { get; set; }
        public string StudentID { get; set; }
        public int ShowOrNot { get; set; } = 0;

        [ForeignKey("StudentID")]
        public ApplicationStudentIdentity ApplicationStudentIdentity { get; set; }

    }
}
