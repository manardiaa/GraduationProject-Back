using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("DragAndDrop")]
    public class DragAndDrop
    {
        public int id { get; set; }
        public string RightAnswer { get; set; }
        public int QustionId { get; set; }
        [ForeignKey("QustionId")]
        public virtual Question Qustion { get; set; }
    }
}
