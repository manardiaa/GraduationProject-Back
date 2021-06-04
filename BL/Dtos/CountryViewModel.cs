using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class CountryViewModel
    {
        public int id { get; set; }
        [Required]
        public string Country_Name { get; set; }

    }
}
