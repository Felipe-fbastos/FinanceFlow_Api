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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.

            base.OnModelCreating(modelBuilder);
        }
    }
}
