using ApplicationCore.Entities.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MenuContext : DbContext
    {
        public DbSet<MenuItem> MenuItem { get; set; }

        public MenuContext()
        {
        }

        public MenuContext(DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
        }
    }
}
