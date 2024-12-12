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
        public int RoomNumberId { get; set; } // Key to room - F-key
        public Room Room { get; set; } = null!;

        // Invoice
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;


    }
}