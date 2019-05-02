using RadanMaster.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace RadanMaster.DAL
{
    public class RadanMasterContext : DbContext
    {
        public RadanMasterContext() : base("RadanMasterContext")
        {
            Database.SetInitializer<RadanMasterContext>(null);
        }

        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Nest> Nests { get; set; }
        public DbSet<NestedParts> NestedParts { get; set; }
        public DbSet<RadanID> RadanIDs { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<OperationPerformed> OperationPerformeds { get; set; }
    }
}
        
        

        

    
        
