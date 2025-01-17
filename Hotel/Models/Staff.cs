using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; } 

        public string Role { get; set; }

    }
}
