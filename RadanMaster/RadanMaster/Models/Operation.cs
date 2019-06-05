using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadanMaster.Models
{
    public class Operation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Part Part { get; set; }
        public int PartID { get; set; }
        
        public bool isFinalOp { get; set; }

        public virtual ICollection<OrderItemOperation> OrderItemOperations { get; set; }
    }
}
