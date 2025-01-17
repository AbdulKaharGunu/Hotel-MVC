using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } // Primary Key
        [Required]
        public int ReservationId { get; set; } // Foreign Key
        public string? PaymentMethod { get; set; } // e.g., Credit Card, PayPal
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionStatus { get; set; } // Success, Failed, Pending

        // Navigation Properties
        public Reservation Reservation { get; set; }


    }
}
