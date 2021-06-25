using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class SubCategoryViewModel
    {
        public int ID { get; set; }
        public string SubCategoryTitle { get; set; } = "Test";
        public int CategoryID { get; set; } = 1;
        public string SubCategoryDescribtion { get; set; }

    }

}
