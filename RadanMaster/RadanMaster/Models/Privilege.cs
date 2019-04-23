using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RadanMaster.Models
{
    public class Privilege
    {
        [Key]
        public int ID { get; set; }
        public string buttonName { get; set; }
        public bool HasAccess { get; set; }
    }
}
