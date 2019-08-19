namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItemOperation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderItemOperation()
        {
            OperationPerformeds = new List<OperationPerformed>();
        }

        public int ID { get; set; }

        public int qtyRequired { get; set; }

        public int qtyDone { get; set; }

        public int? operationID { get; set; }

        public int? orderItemID { get; set; }

        public virtual Operation Operation { get; set; }

        public virtual OrderItem OrderItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OperationPerformed> OperationPerformeds { get; set; }
    }
}
