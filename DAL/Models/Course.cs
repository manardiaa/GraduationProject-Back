using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Course")]
    public class Course
    {
        public int id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float duration { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int LectureNumber { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; } = 1;     
        public string PartLogo { get; set; }
        public string PreRequest { get; set; }
        public string CrsLogo { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public List<ApplicationStudentIdentity> Studentes { get; set; } = new List<ApplicationStudentIdentity>();




    }
}
