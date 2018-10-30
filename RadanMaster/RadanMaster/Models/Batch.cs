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
        public int ID { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public bool IsComplete { get; set; }

        public virtual ICollection<BatchItem> BatchItems { get; set; }
    }
}
