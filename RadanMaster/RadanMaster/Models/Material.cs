using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadanMaster.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Thickness { get; set; }
        public string StructuralCode { get; set; }
    }
}
