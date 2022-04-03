using Crud.Core;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class CrudDbContext : DbContext
    {
        public DbSet<PluginDao> Plugins { get; set; }
        public DbSet<ProjectDao> Projects { get; set; }

        public CrudDbContext(DbContextOptions<CrudDbContext> options):base(options)
        {

        }
        protected override void  OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new PluginConfiguration());

            builder
                .ApplyConfiguration(new ProjectConfiguration());
        }
    }
}
