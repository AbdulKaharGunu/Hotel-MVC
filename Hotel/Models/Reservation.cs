using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; } // Primary Key
        [Required]
        public int CustomerID { get; set; } // Foreign Key
        [Key]
        public int RoomId { get; set; } // Foreign Key
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // Pending, Confirmed, Cancelled, CheckedOut
        public int StaffId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation Properties
       
        public Room Room { get; set; }
        public Staff Staff { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
