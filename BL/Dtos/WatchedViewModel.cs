using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class WatchedViewModel
    {
        public int id { get; set; }
        public int whatchedOrNot { get; set; }
        public int lessonContentID { get; set; }
        public string stID { get; set; }
        public int CrsID { get; set; }
    }
}
