using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadanMaster.Models
{
    public class OrderItemOperationPerformed
    {
        public int ID { get; set; }
        public int qtyDone { get; set; }

        public OrderItemOperation orderItemOperation { get; set; }
        public int? orderItemOpID { get; set; }

        public OperationPerformed opPerformed { get; set; }
        public int ? opPerformedID { get; set; }
    }
}
