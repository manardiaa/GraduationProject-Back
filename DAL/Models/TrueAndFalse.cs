using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public  class TrueAndFalse
    {

        public int id { get; set; }
        public string right { get; set; }
        public int QustionId { get; set; }
        [ForeignKey("QustionId")]
        public virtual Question Qustion { get; set; }
    }
}
