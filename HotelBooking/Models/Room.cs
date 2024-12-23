namespace HotelBooking.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public byte RoomSize { get; set; }
        public TypeOfRoom TypeOfRoom { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsRoomDeleted { get; set; }
        public int? ExtraBedsCount { get; set; }
        public bool IsExtraBedAvailable { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }

    public enum TypeOfRoom
    {
        Single,
        Double
    }
}