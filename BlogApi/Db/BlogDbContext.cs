using BlogApi.Db.Models;
using System.Data.Entity;

namespace BlogApi.Db
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext(): base("name=BlogDBConnectionString") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Migrations.Configuration>());
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }
    }
}