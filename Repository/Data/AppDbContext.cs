using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Education> Educations { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Group> Groups { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
