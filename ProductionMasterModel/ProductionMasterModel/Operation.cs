namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Operation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Operation()
        {
            OrderItemOperations = new List<OrderItemOperation>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int PartID { get; set; }

        public bool isFinalOp { get; set; }

        public virtual Part Part { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItemOperation> OrderItemOperations { get; set; }
    }
}
