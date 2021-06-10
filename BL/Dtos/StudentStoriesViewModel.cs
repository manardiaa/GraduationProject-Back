using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class StudentStoriesViewModel
    {
        public int Id { get; set; }
        public string Specialzation { get; set; }
        public string Story { get; set; }
        public string StudentId { get; set; }
        public int ShowOrNot { get; set; } = 0;
        public int CategoryId { get; set; }

    }
}
