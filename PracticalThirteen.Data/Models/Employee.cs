using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalThirteen.Data.Models
{
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
}
