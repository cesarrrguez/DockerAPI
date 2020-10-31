using DockerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerApi.Data
{
    public class DataContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "data";

        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
