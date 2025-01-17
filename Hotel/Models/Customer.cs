using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; } // Primary Key
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
