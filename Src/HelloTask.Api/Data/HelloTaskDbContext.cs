using HelloTask.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace HelloTask.Data
{
    public class HelloTaskDbContext : DbContext
    {
        public HelloTaskDbContext(DbContextOptions<HelloTaskDbContext> options) : base(options)
        {

        }

        public DbSet<Tab> Tabs { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}
