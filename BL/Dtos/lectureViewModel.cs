using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class lectureViewModel
    {
        public int Id { get; set; }
        public string Tilte { get; set; }
        public int CourseId { get; set;}
        public int lessoneNumber { get; set; }
        public string LectureDescription { get; set; }

    }
}
