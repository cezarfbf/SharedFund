using Microsoft.EntityFrameworkCore;
using SharedFund.Models;

namespace SharedFund.Persistence
{
    public class SharedFundContext : DbContext
    {
        public SharedFundContext(DbContextOptions<SharedFundContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FundAccount> FundAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.InitData();
        }
    }
}