using Microsoft.EntityFrameworkCore;
using PracticalThirteen.Data.Models;

namespace PracticalThirteen.Data.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void SeedEmployee(this ModelBuilder modelBuilder)
        {
            IList<Employee> employees = new List<Employee>();

            employees.Add(new Employee() { Id = 1, Name = "Bhavin", JoiningDate = Convert.ToDateTime("09-02-2002").Date, Age = 20 });
            employees.Add(new Employee() { Id = 2, Name = "Vipul", JoiningDate = Convert.ToDateTime("07-07-1999").Date, Age = 23 });
            employees.Add(new Employee() { Id = 3, Name = "Jil", JoiningDate = Convert.ToDateTime("12-05-2000").Date, Age = 22 });
            employees.Add(new Employee() { Id = 4, Name = "Abhi", JoiningDate = Convert.ToDateTime("04-07-2000").Date, Age = 22 });
            employees.Add(new Employee() { Id = 5, Name = "Jay", JoiningDate = Convert.ToDateTime("01-09-2000").Date, Age = 22 });

            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}
