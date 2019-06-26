using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RadanMaster.Models
{
    public partial class User
    {
        [Key]
        public int UserID {get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Privilege> Privileges { get; set; }
        public virtual ICollection<OperationPerformed> opsPerformed { get; set; }

        public bool HasPermission(string btnText)
        {
            Models.Privilege privilege = Privileges.Where(p => p.buttonName == btnText).
                                                    Where(p => p.HasAccess == true).FirstOrDefault();
            if (privilege != null)
                return true;
            else
                return false;
        }
    }
}
