using HotelBooking.Models;

namespace HotelBooking.Utilities.Helpers.RoomHelper
{
    public static class RoomAvailabilityHelper
    {
        public static bool IsAvailableDuring
            (Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            return room.Bookings
                .All(b => b.CheckOutDate <= checkInDate || b.CheckInDate >= checkOutDate);
        }
    }
}

