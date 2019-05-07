using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadanMaster.Models
{
    public class OperationPerformed
    {
        public int ID { get; set; }
        public int qtyDone { get; set; }
        public User usr { get; set; }
        public DateTime timePerformed { get; set; }
        public string Notes { get; set; }

        public Operation Operation { get; set; }
        public int OperationID { get; set; }
    }
}
