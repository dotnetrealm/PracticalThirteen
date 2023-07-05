using System.ComponentModel.DataAnnotations;

namespace PracticalThirteen.Data.Models
{
    public class Designation
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DesignationName { get; set; } = null!;

        public ICollection<Employee>? Employees { get; set; }
    }
}
