namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NestedPart
    {
        public int ID { get; set; }

        public int Qty { get; set; }

        public int? OrderItem_ID { get; set; }

        public int? Nest_ID { get; set; }

        public virtual Nest Nest { get; set; }

        public virtual OrderItem OrderItem { get; set; }
    }
}
