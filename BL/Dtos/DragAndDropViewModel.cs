using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class DragAndDropViewModel
    {
        public int id { get; set; }
        public string RightAnswer { get; set; }
        public int QustionId { get; set; }


    }
}
