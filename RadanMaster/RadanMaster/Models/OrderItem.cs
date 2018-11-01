using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadanMaster.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        public Order Order { get; set; }
        public int OrderID { get; set; }
        public bool IsComplete { get; set; }
        public int Qty { get; set; }

        public Part Part { get; set; }
        public int PartID { get; set; }
    }
}
