
using HotelBooking.Models;

namespace HotelBooking.DTOs
{
    public class RoomInformationDTO
    {
        public int RoomNumber { get; set; }
        public byte RoomSize { get; set; }
        public TypeOfRoom TypeOfRooms { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsExtraBedAvailable { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
