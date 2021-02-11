using Microsoft.AspNet.Identity.EntityFramework; 
using System.Data.Entity;
using System.Data.Entity.Migrations.History; 
using BaggageTransfer.Factories;
using BaggageTransfer.Models.EntityModels;

namespace BaggageTransfer.Models
{

    public class ApplicationDbContext : AppDbContext
    {  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().Property(m => m.Email).HasMaxLength(127);

            modelBuilder.Entity<ApplicationUser>().Property(m => m.PhoneNumber).HasMaxLength(127);

            modelBuilder.Entity<ApplicationUser>().Property(m => m.UserName).HasMaxLength(127);

            modelBuilder.Entity<ApplicationUser>().Property(m => m.UserName).HasMaxLength(127);

            modelBuilder.Entity<ApplicationUser>().Property(m => m.DeviceId).HasMaxLength(127);

            modelBuilder.Entity<IdentityRole>().Property(m => m.Name).HasMaxLength(127); 

            modelBuilder.Entity<HistoryRow>().HasKey(t => t.MigrationId);

            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(127).IsRequired();

            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(127).IsRequired(); 

        }

        public DbSet<BaggageRequest> BaggageRequests { get; set; }

        public DbSet<RequestsPayment> RequestsPayments { get; set; }
         
        public DbSet<UserEnquiry> UserEnquireis { get; set; }
    }
}