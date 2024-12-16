using HotelBooking.Data.Seeders;
using HotelBooking.Models;
namespace HotelBooking.Data
{
    public class DataInitializer
    {
        private HotelBookingDbContext _dbContext;
        private readonly RoomSeeder _roomSeeder;
        private readonly CustomerSeeder _customerSeeder;

        public HotelBookingDbContext MigrateAndSeedData()
        {
            _dbContext = new HotelBookingDbContext();
            //_dbContext.Rooms = new List<Room>();
            if(!_dbContext.Rooms.Any())
            {
                _roomSeeder.RoomSeeding();
            }

            if(!_dbContext.Customers.Any())
            {
                _customerSeeder.CustomerSeeding();
            }

            return _dbContext;
        }
    }
}
