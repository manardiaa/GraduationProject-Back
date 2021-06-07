using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Country")]

    public class Country
    {
        public int id { get; set; }
        public string Country_Name { get; set; }
    }
}
