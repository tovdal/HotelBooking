

namespace HotelBooking.Models
{
    public class Room
    {
        public int RoomNumberId { get; set; }
        public byte RoomSize { get; set; }
        public TypeOfRoom TypeOfRooms { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
    public enum TypeOfRoom
    {
        Singel,
        Double

    }
}
