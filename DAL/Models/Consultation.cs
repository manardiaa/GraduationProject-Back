using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Consultation")]
    public class Consultation
    {
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string WorkEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationSize { get; set; }
    }
}
