using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalThirteen.Data.Models
{
    //For Task-01
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1800-01-01", "2022-12-31", ErrorMessage = "Please select valid Joining (1800/01/01 - 2022/12/31)")]
        public DateTime JoiningDate { get; set; } = new DateTime(2000, 01, 01);

        [DisplayFormat(NullDisplayText = "0")]
        public int? Age { get; set; }
    }

    //For Task-02
    public class EmployeeWithSalary
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        [Display(Name = "Middle Name")]
        [DisplayFormat(NullDisplayText = "-")]
        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "Date")]
        [Display(Name = "Birth date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateOnly), "1800-01-01", "2022-12-31", ErrorMessage = "Please select valid Birthdate (1800/01/01 - 2022/12/31)")]
        public DateTime DOB { get; set; } = new DateTime(2002, 01, 01).Date;

        [Required]
        [MaxLength(10), MinLength(10)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter Valid Mobile Number")]
        public string MobileNumber { get; set; } = null!;

        [MaxLength(100)]
        public string? Address { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [ForeignKey("FK_Employees_Designation")]
        public int DesignationId { get; set; }

        public Designation Designation { get; set; } = null!;
    }
}
