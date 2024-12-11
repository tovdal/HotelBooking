using HotelBooking.Models;

namespace HotelBooking.Data
{
    public class ApplicationDbContext_FAKE
    {
        public List<Guest> Guests { get; set; }
        public List<Room> Rooms { get; set; }
        public Booking Booking { get; set; }
        public Invoice Invoices { get; set; }
    }
}
