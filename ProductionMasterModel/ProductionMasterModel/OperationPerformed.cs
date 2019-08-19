namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OperationPerformed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OperationPerformed()
        {
            OrderItemOperations = new HashSet<OrderItemOperation>();
        }

        public int ID { get; set; }

        public int qtyDone { get; set; }

        public DateTime timePerformed { get; set; }

        public string Notes { get; set; }

        public int? usr_UserID { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItemOperation> OrderItemOperations { get; set; }
    }
}
