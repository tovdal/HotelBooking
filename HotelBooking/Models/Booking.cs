using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public BookingStatus Status { get; set; }

        [Required]
        public Customer Customer { get; set; } = null!;

        [Required]
        public List<Room> Rooms { get; set; } = new List<Room>();

        [Required]
        public Invoice Invoice { get; set; } = null!;
    }

    public enum BookingStatus
    {
        Active,
        Deleted
    }
}