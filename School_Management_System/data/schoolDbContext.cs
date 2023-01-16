using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;

namespace School_Management_System.data
{
    public class schoolDbContext:DbContext
    {
        public schoolDbContext(DbContextOptions <schoolDbContext> options) : base(options)
        {

        }
        public DbSet<student> StudentTable { get; set; }
        public DbSet<faculty> FacultiesTable { get; set; }
    }
}
