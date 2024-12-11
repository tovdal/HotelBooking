namespace HotelBooking.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } // Maybe want this??
        public string Adress { get; set; }

        public GuestStatus Status { get; set; } = GuestStatus.Active;
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
    public enum GuestStatus
    {
        Active,
        Inactive
    }
}
