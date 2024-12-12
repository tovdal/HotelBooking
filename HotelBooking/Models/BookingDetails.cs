
namespace HotelBooking.Models
{
    public  class BookingDetails
    {
        public int BookingDetailsId { get; set; } 
        public int BookingId { get; set; } // Foreign key 
        public int InvoiceId { get; set; } // Foreign key

        public Booking Booking { get; set; } = null!;
        public Invoice Invoice { get; set; } = null!;
    }
}