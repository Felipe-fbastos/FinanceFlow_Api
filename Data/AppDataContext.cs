using FinanceFlowAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceFlowAPI.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<BankAccount>()
                .HasOne(U => U.User)
                .WithMany(U => U.BankAccounts)
                .HasForeignKey(U => U.UserId)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .HasOne(B => B.BankAccount)
                .WithMany(T => T.Transactions)
                .HasForeignKey(B => B.BankAccountId)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .HasOne(C => C.Category)
                .WithMany(T => T.Transactions)
                .HasForeignKey(C => C.CategoryId)
                .IsRequired();

            // Index Unique

            modelBuilder.Entity<User>()
                .HasIndex(U => U.Email)
                .IsUnique();
            
               

            base.OnModelCreating(modelBuilder);
        }
    }
}
