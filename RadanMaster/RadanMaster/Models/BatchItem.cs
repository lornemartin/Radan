using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadanMaster.Models
{
    public class BatchItem
    {
        [Key]
        public int ID { get; set; }
        public int BatchID { get; set; }
        public bool IsComplete { get; set; }
        public int Qty { get; set; }

        public Part Part { get; set; }

    }
}
