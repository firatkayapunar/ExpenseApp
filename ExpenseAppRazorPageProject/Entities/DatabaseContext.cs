using Microsoft.EntityFrameworkCore;

namespace ExpenseAppRazorPageProject.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ExpenseAppDb;Trusted_Connection=true");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
    }
}
