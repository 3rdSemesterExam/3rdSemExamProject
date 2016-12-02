using System.Data.Entity;

namespace dsr_webservice
{
    public class dsr_betalling : DbContext
    {
        public dsr_betalling()
            : base("name=connectionString")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<Chip> Chips { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.ActivityLogs)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.FK_Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Chips)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.FK_Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Purchases)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.FK_Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ActivityLogs)
                .WithRequired(e => e.Activity)
                .HasForeignKey(e => e.FK_Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityLog>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Rebate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PurchaseItems)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.FK_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Purchase>()
                .HasMany(e => e.PurchaseItems)
                .WithRequired(e => e.Purchase)
                .HasForeignKey(e => e.FK_Purchase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseItem>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ActivityLogs)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Purchases)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_User)
                .WillCascadeOnDelete(false);
        }
    }
}