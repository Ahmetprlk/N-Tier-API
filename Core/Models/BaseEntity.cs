using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool Status { get; set; }

    }
}
