namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part()
        {
            Files = new List<File>();
            Operations = new List<Operation>();
            OrderItems = new List<OrderItem>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<File> Files { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
