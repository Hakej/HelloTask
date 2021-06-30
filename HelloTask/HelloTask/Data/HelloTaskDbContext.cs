using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTask.Core.Models;
using Board = HelloTask.Models.Board;
using Tab = HelloTask.Models.Tab;

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
