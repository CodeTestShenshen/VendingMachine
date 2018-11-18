using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq; 
using VendingMachineApp.Models;

namespace VendingMachineApp.Database
{
    public class VendingMachineContext:DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Flaviour> Flaviours { get; set; }

        public VendingMachineContext() : base()
        {

        }

        public VendingMachineContext(string connName) : base(connName)
        {
             
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<VendingMachineContext>(null); 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Transactions)
                .WithRequired(t => t.Machine)
                .HasForeignKey(t => t.MachineId);

            modelBuilder.Entity<Flaviour>()
                .HasMany(f => f.Transactions)
                .WithRequired(t => t.Flaviour)
                .HasForeignKey(t => t.FlaviourId);

            // soft deletion
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var stateManager = ((IObjectContextAdapter) this).ObjectContext.ObjectStateManager;

            // soft deletion: get all entities to be deleted implemented IActive 
            var deleteEntities = stateManager
                .GetObjectStateEntries(EntityState.Deleted)
                .Select(a => a.Entity)
                .OfType<IActive>()
                .ToArray();

            foreach (var entity in deleteEntities)
            {
                if (entity == null)
                    continue;

                // Updating entity in db by changing state from deleted to modifed
                stateManager.ChangeObjectState(entity, EntityState.Modified);
                entity.IsActive = false;
            }
    
            return base.SaveChanges();
        }




    }
}