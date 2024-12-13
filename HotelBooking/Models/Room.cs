namespace HotelBooking.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public byte RoomSize { get; set; }
        public TypeOfRoom TypeOfRooms { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsExtraBedAvailable { get; set; } 
    }
    public enum TypeOfRoom
    {
        Singel,
        Double
    }
}
