using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadanMaster.Models
{
    public class Batch
    {
        [Key]
        public int ID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsComplete { get; set; }

        public virtual ICollection<BatchItem> BatchItems { get; set; }
    }
}
