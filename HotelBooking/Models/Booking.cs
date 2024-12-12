using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate {  get; set; }

        // Guest
        public int GuestId { get; set; }
        public Guest Guest { get; set; } = null!;

        // Room
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;

        public BookingDetails BookingDetails { get; set; } = null!;

    }
}