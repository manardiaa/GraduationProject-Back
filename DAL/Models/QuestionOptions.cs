using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class QuestionOptions
    {

        public int id { get; set; }
        public string right { get; set; }
        public int QustionId { get; set; }
        [ForeignKey("QustionId")]
        public Question Qustion { get; set; }
    }
}
