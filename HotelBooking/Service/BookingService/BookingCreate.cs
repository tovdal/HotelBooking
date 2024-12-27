using HotelBooking.Data;
using HotelBooking.Models;
using Spectre.Console;

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
            newBooking.Rooms = _roomsToBook;
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

        public bool IsRoomBooked(int roomNumber)
        {
            var room = _dbContext.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
            {
                return false;
            }
            return !room.IsAvailable;
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
    }
}