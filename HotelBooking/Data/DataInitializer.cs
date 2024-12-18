using HotelBooking.Data.Seeders;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Data
{
    public class DataInitializer
    {
        private ApplicationDbContext _dbContext;
        private readonly RoomSeeder _roomSeeder;
        private readonly CustomerSeeder _customerSeeder;

        public DataInitializer(ApplicationDbContext dbContext, RoomSeeder roomSeeder, CustomerSeeder customerSeeder)
        {
            _dbContext = dbContext;
            _roomSeeder = roomSeeder;
            _customerSeeder = customerSeeder;
        }

        public ApplicationDbContext MigrateAndSeedData()
        {
            _dbContext = new ApplicationDbContext();
            _dbContext.Database.Migrate();

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
