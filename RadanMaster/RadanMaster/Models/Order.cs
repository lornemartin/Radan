using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadanMaster.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        public DateTime OrderEntryDate { get; set; }
        public DateTime OrderDueDate { get; set; }
        public bool IsComplete { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
