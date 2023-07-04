using Microsoft.EntityFrameworkCore;
using PracticalThirteen.Data.Models;

namespace PracticalThirteen.Data.Contexts
{
    public class EmployeeCodeFirstDBContext : DbContext
    {
        public EmployeeCodeFirstDBContext(DbContextOptions<EmployeeCodeFirstDBContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEmployee();
        }
    }
}
