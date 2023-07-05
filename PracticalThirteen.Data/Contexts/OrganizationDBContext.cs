using Microsoft.EntityFrameworkCore;
using PracticalThirteen.Data.Models;

namespace PracticalThirteen.Data.Contexts
{
    public class OrganizationDBContext : DbContext
    {
        public OrganizationDBContext(DbContextOptions<OrganizationDBContext> options) : base(options) {}
        public DbSet<EmployeeWithSalary> EmployeesWithSalary { get; set; }
        public DbSet<Designation> Designations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedOrganization();
        }
    }
}
