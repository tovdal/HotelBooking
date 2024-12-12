namespace HotelBooking.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;// Maybe want this??
        public string? Adress { get; set; }

        public GuestStatus Status { get; set; } = GuestStatus.Active;
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
    public enum GuestStatus
    {
        Active,
        Inactive
    }
}
