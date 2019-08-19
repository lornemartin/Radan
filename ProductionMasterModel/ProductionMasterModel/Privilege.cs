namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Privilege
    {
        public int ID { get; set; }

        public string buttonName { get; set; }

        public bool HasAccess { get; set; }

        public int? User_UserID { get; set; }

        public virtual User User { get; set; }
    }
}
