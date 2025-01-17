using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class StaffLogin
    {

        [Key]
        public int StaffLoginId { get; set; } // Primary Key

        [Required]
        public int StaffId { get; set; } // Foreign Key to Staff

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } // Unique Username for Login

        [Required]
        public string Password { get; set; } // Hashed Password

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Navigation Property
        public Staff Staff { get; set; }

    }
}
