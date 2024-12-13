using HotelBooking.Data.Seeders;
using HotelBooking.Models;
namespace HotelBooking.Data
{
    public class DataInitializer
    {
        private HotelBookingDbContext _dbContext;
        private readonly RoomSeeder _roomSeeder;
        private readonly GuestSeeder _guestSeeder;

        public HotelBookingDbContext MigrateAndSeedData()
        {
            _dbContext = new HotelBookingDbContext();
            //_dbContext.Rooms = new List<Room>();
            if(!_dbContext.Rooms.Any())
            {
                _roomSeeder.RoomSeeding();
            }

            if(!_dbContext.Guests.Any())
            {
                _guestSeeder.GuestSeeding();
            }

            return _dbContext;
        }
    }
}
