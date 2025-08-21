using Microsoft.EntityFrameworkCore;
using ODAPI.Models;

namespace ODAPI.Database
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities here
        // public DbSet<YourEntity> YourEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entity mappings here
            // modelBuilder.Entity<YourEntity>().ToTable("YourTableName");
        }
        public DbSet<ODAPI.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<ODAPI.Models.Tecnico> Tecnico { get; set; } = default!;
        public DbSet<ODAPI.Models.OD> OD { get; set; } = default!;
    }
}
