namespace HotelBooking.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Adress { get; set; }
        public bool IsGuestStatusActive { get; set; } 

        // En kund behöver inte ha en bokning för att vara gäst.
        public List<Booking>? Bookings { get; set; } = new List<Booking>();
    }
}
