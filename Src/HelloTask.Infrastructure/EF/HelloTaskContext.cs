using HelloTask.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace HelloTask.Infrastructure.EF
{
    public class HelloTaskContext : DbContext
    {
        private readonly SqlSettings _sqlSettings;
        
        public DbSet<User> Users { get; set; }
        
        public HelloTaskContext(DbContextOptions<HelloTaskContext> options, SqlSettings sqlSettings) 
            : base(options)
        {
            _sqlSettings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_sqlSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("HelloTask");
                
                return;
            }

            optionsBuilder.UseSqlServer(_sqlSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey(x => x.Id);
        }
    }
}