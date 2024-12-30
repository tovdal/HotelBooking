using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Utilities.Helpers;
using HotelBooking.Utilities.Helpers.RoomHelper;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.BookingService
{
    public class BookingCreate
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly List<Room> _roomsToBook = new List<Room>();

        public BookingCreate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBooking(Booking newBooking)
        {
            newBooking.Rooms = new List<Room>(_roomsToBook);
            foreach (var room in _roomsToBook)
            {
                room.IsAvailable = false;
            }
            _dbContext.Add(newBooking);
            _dbContext.SaveChanges();
        }

        public bool BookingExists(int bookingId)
        {
            return _dbContext.Bookings.Any(booking => booking.Id == bookingId);
        }

        public List<Room> GetRoomsToBook()
        {
            return _roomsToBook;
        }

        public decimal TotalPriceOfBooking(DateTime checkInDate, DateTime checkOutDate)
        {
            int totalDays = (checkOutDate - checkInDate).Days;
            return _roomsToBook.Sum(r => r.PricePerNight * totalDays);
        }

        public bool IsRoomBooked(int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            var room = _dbContext.Rooms.Include(r => r.Bookings)
                                       .FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
            {
                return false;
            }

            return !RoomAvailabilityHelper.IsAvailableDuring(room, checkInDate, checkOutDate);
        }

        public void AddRoomToBooking(string roomNumber, bool extraBed = false)
        {
            var room = _dbContext.Rooms
                .First(r => r.RoomNumber == int.Parse(roomNumber));
            if (extraBed && room.ExtraBedsCount.HasValue)
            {
                if (room.RoomSize >= 25)
                {
                    room.ExtraBedsCount += 2;
                }
                else
                {
                    room.ExtraBedsCount += 1;
                }
            }
            _roomsToBook.Add(room);
        }

        public void ClearRoomsToBook()
        {
            _roomsToBook.Clear();
        }
    }
}