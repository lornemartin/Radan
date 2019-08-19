namespace ProductionMasterModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            OperationPerformeds = new List<OperationPerformed>();
            Privileges = new List<Privilege>();
        }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OperationPerformed> OperationPerformeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Privilege> Privileges { get; set; }

        public bool HasPermission(string btnText)
        {
            Privilege privilege = Privileges.Where(p => p.buttonName == btnText).
                                                    Where(p => p.HasAccess == true).FirstOrDefault();
            if (privilege != null)
                return true;
            else
                return false;
        }
    }
}
