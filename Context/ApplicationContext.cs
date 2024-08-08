using Microsoft.EntityFrameworkCore;

using TestProject.Models;

namespace TestProject.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext()
        {
            
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<UserFile> Files { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Files)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "Server=localhost;Port=3308;Database=testProject;User=root;Password=test1234;";
            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
