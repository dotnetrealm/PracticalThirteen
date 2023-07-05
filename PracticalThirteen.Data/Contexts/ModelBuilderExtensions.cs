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
        public static void SeedOrganization(this ModelBuilder modelBuilder)
        {
            IList<Designation> designations = new List<Designation>() {
                new Designation() { Id=1, DesignationName = "Team Manager" },
                new Designation() { Id=2, DesignationName = "Lead Engineer" },
                new Designation() { Id=3, DesignationName = "Senior Developer" },
                new Designation() { Id=4, DesignationName = "Junior Developer" },
                new Designation() { Id=5, DesignationName = "Trainee Engineer" }
            };

            IList<EmployeeWithSalary> employees = new List<EmployeeWithSalary>()
            {
                new EmployeeWithSalary() { Id=1, FirstName = "Bhavin", LastName = "Kareliya", MobileNumber = "1231231231", Salary = 999999, DOB = Convert.ToDateTime("09/02/2002").Date, Address = "Rajkot", DesignationId = 1 },
                new EmployeeWithSalary() { Id=2, FirstName = "Jil", LastName = "Patel", MobileNumber = "9898989898", Salary = 999999, DOB = Convert.ToDateTime("12/04/2001").Date, Address = "Anand", DesignationId = 2 },
                new EmployeeWithSalary() { Id=3, FirstName = "Vipul", LastName = "Kumar", MobileNumber = "1231231231", Salary = 999999, DOB = Convert.ToDateTime("07/07/1999").Date, Address = "Ahemedabad", DesignationId = 3 },
                new EmployeeWithSalary() { Id=4, FirstName = "Abhi", LastName = "Dasadiya", MobileNumber = "9898989898", Salary = 999999, DOB = Convert.ToDateTime("04/03/2002").Date, Address = "Morbi", DesignationId = 3 },
                new EmployeeWithSalary() { Id=5, FirstName = "Jay", LastName = "Gohel", MobileNumber = "1231231231", Salary = 999999, DOB = Convert.ToDateTime("12/12/2001").Date, Address = "Rajkot", DesignationId = 3 },
            };

            modelBuilder.Entity<Designation>().HasData(designations);
            modelBuilder.Entity<EmployeeWithSalary>().HasData(employees);
        }
    }
}
