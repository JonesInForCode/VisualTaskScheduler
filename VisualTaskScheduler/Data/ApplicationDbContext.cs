using Microsoft.EntityFrameworkCore;
using VisualTaskScheduler.Data;

namespace VisualTaskScheduler.Data
{
    public class ApplicationDbContext : ApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet
    }
}