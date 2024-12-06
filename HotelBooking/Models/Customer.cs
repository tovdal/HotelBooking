namespace HotelBooking.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } // Maybe what this??
        public string Adress { get; set; }

        public CustomerStatus Status { get; set; } = CustomerStatus.Active;
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
    public enum CustomerStatus
    {
        Active,
        Inactive,
        Deleted
    }
}
