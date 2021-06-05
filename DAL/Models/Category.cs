using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string CatName { get; set; }
        public string CatImage { get; set; }
        public string CatDescription{ get; set; }        
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
