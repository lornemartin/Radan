namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MfgOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        

        public int ID { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsComplete { get; set; }

        public DateTime? DateCompleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

    public partial class BatchOrder : MfgOrder
    {
        public BatchOrder()
        {
            OrderItems = new List<OrderItem>();
        }

        public string BatchName { get; set; }
    }

    public partial class ActualOrder : MfgOrder
    {
        public ActualOrder()
        {
            OrderItems = new List<OrderItem>();
        }
        public string OrderNumber { get; set; }

        public string ScheduleName { get; set; }
    }
}
