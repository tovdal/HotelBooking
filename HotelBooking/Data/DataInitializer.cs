using HotelBooking.Data.Seeders;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Data
{
    public class DataInitializer
    {

        private readonly RoomSeeder _roomSeeder;
        private readonly CustomerSeeder _customerSeeder;
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(RoomSeeder roomSeeder, CustomerSeeder customerSeeder, ApplicationDbContext dbContext)
        {

            _roomSeeder = roomSeeder;
            _customerSeeder = customerSeeder;
            _dbContext = dbContext;
        }

        public void MigrateAndSeedData()
        {
            _dbContext.Database.Migrate();

            if (!_dbContext.Rooms.Any())
            {
                _roomSeeder.RoomSeeding(_dbContext);
            }

            if (!_dbContext.Customers.Any())
            {
                _customerSeeder.CustomerSeeding(_dbContext);
            }
        }
    }
}