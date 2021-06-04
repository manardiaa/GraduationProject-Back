using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class MentorOrInstractorStoriesViewModel
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Specialzation { get; set; }
        public string Story { get; set; }
        public int CountryID { get; set; }
        public string MemberType { get; set; }
        public int ShowOrNot { get; set; } = 0;
    }
}
