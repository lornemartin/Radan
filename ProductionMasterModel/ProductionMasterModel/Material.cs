namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Material
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public float Thickness { get; set; }

        public string StructuralCode { get; set; }
    }
}
