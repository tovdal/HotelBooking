namespace HotelBooking.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate {  get; set; }

        // Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Room
        public int RoomNumberId { get; set; } // Key to room - F-key
        public Room Room { get; set; } 
        //


    }
}