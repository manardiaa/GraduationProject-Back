using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{

    public class CourseViewModel
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


    }
}
