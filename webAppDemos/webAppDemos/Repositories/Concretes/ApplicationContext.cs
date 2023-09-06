using Microsoft.EntityFrameworkCore;
using webAppDemos.Entities.Concretes;

namespace webAppDemos.Repositories.Concretes
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<User> Users { get; set; }
    }
}
