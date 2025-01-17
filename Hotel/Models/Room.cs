using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Room
    {

        [Key]
        public int RoomId { get; set; } // Primary Key
        [Required]
        public int RoomTypeId { get; set; } // Foreign Key
        [Required]
        public string RoomNumber { get; set; }
        public decimal? PricePerNight { get; set; }
        public int? MaxOccupancy { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation Properties
        public RoomType RoomType { get; set; }
        public ICollection<Reservation> Reservations { get; set; }


    }
}
