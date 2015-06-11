using wompsmash.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace wompsmash.DAL
{
    public class WompSmashContext : DbContext
    {
        public WompSmashContext() : base("WompSmashContext")
        {

        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}