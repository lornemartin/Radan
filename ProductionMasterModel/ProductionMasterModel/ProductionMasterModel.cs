namespace ProductionMasterModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductionMasterModel : DbContext
    {
        public ProductionMasterModel()
            : base("name=ProductionMasterModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<NestedPart> NestedParts { get; set; }
        public virtual DbSet<Nest> Nests { get; set; }
        public virtual DbSet<OperationPerformed> OperationPerformeds { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<OrderItemOperation> OrderItemOperations { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<RadanID> RadanIDs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nest>()
                .HasMany(e => e.NestedParts)
                .WithOptional(e => e.Nest)
                .HasForeignKey(e => e.Nest_ID);

            modelBuilder.Entity<Nest>()
                .HasMany(e => e.OrderItems)
                .WithMany(e => e.AssociatedNests)
                .Map(m => m.ToTable("NestOrderItems"));

            modelBuilder.Entity<OperationPerformed>()
                .HasMany(e => e.OrderItemOperations)
                .WithMany(e => e.OperationPerformeds)
                .Map(m => m.ToTable("OperationPerformedOrderItemOperations"));

            modelBuilder.Entity<OrderItem>()
                .HasMany(e => e.NestedParts)
                .WithOptional(e => e.OrderItem)
                .HasForeignKey(e => e.OrderItem_ID);

            modelBuilder.Entity<OrderItem>()
                .HasOptional(e => e.RadanID)
                .WithRequired(e => e.OrderItem);

            modelBuilder.Entity<Part>()
                .HasMany(e => e.Files)
                .WithOptional(e => e.Part)
                .HasForeignKey(e => e.Part_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.OperationPerformeds)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.usr_UserID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Privileges)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_UserID);
        }
    }
}
