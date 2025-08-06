using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Education> Educations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
