using wompsmash.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace wompsmash.DAL
{
    public class WompSmashContext : DbContext
    {
        public WompSmashContext() : base("WompSmashContext")
        {
            //this line disables initializer
            //Database.SetInitializer<WompSmashContext>(null);
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<wompsmash.Models.Contact> Contacts { get; set; }
    }
}