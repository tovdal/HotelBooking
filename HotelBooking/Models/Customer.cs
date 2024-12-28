namespace HotelBooking.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public bool IsCustomerDeleted { get; set; } = false;

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}