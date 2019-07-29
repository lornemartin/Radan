using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadanMaster.Models
{
    public class OrderItemOperation
    {
        public OrderItemOperation()
        {
            this.operationsPerformed = new List<OperationPerformed>();
        }

        public int ID { get; set; }
        public int qtyRequired { get; set; }
        public int qtyDone { get; set; }

        public Operation operation { get; set; }
        public int? operationID { get; set; }

        public OrderItem orderItem { get; set; }
        public int? orderItemID { get; set; }

        public virtual ICollection<OperationPerformed> operationsPerformed { get; set; }
    }
}
