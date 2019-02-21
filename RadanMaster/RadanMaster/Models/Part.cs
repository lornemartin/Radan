using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadanMaster.Models
{
    public class Part
    {
        [Key]
        public int ID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public double Thickness { get; set; }
        public byte[] Thumbnail { get; set; }
        public bool HasBends { get; set; }
        public string Title { get; set; }
        public string ParentPartNumber { get; set; }
        public string CategoryName { get; set; }
        public string StructuralCode { get; set; }
        public string PlantID { get; set; }
        public bool IsStock { get; set; }
        public bool RequiresPDF { get; set; }
        public string Comment { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string State { get; set; }
        public string Keywords { get; set; }
        public string Notes { get; set; }
        public string Revision { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
