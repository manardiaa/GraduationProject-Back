using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SubCategory
    {
        [Key]
        public int ID { get; set; }
        public string SubCategoryTitle { get; set; } = "Test";
        public string SubCategoryDescribtion { get; set; }
        public int CategoryID { get; set; } = 1;

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
