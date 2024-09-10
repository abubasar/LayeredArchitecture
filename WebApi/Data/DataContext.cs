using Microsoft.EntityFrameworkCore;
using WebApi.Data.Configurations;
using WebApi.Entities;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
