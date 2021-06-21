using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.Dtos

{
    public class lessonViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
        public int ContentNumber { get; set; }
        public float Duration { get; set; }
        public int LectureId { get; set; }
        public int CrsId { get; set; }


    }
}
