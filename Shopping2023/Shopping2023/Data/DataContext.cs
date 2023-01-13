using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Shopping2023.Data.Entities;

namespace Shopping2023.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
