namespace HotelBooking.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Adress { get; set; }
        public bool IsCustomerStatusActive { get; set; }
        public bool IsCustomerDeleted { get; set; } = false;

        // En kund behöver inte ha en bokning för att vara gäst.
        public List<Booking>? Bookings { get; set; } = new List<Booking>();
    }
}
