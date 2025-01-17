using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; } // Primary Key
        [Required]
        public string TypeName { get; set; }
        public decimal? BasePrice { get; set; }
        public string? Description { get; set; }

        // Navigation Properties
        public ICollection<Room> Rooms { get; set; }

    }
}
