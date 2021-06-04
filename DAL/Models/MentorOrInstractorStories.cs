using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{

    [Table("MentorOrInstractorStories")]

    public class MentorOrInstractorStories
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Specialzation { get; set; }
        public string Story { get; set; }
        public int CountryID { get; set; }
        public string MemberType { get; set; }
        public int ShowOrNot { get; set; } = 0;

        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
}
