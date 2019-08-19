namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderItem()
        {
            NestedParts = new List<NestedPart>();
            OrderItemOperations = new List<OrderItemOperation>();
            AssociatedNests = new List<Nest>();
        }

        public int ID { get; set; }

        public int OrderID { get; set; }

        public bool IsComplete { get; set; }

        public int QtyRequired { get; set; }

        public int QtyNested { get; set; }

        public bool IsInProject { get; set; }

        public string Notes { get; set; }

        public int PartID { get; set; }

        public int RadanIDNumber { get; set; }

        public string ProductName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NestedPart> NestedParts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItemOperation> OrderItemOperations { get; set; }

        public virtual Order Order { get; set; }

        public virtual Part Part { get; set; }

        public virtual RadanID RadanID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nest> AssociatedNests { get; set; }
    }
}
