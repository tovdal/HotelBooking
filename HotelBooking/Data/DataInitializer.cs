using HotelBooking.Data.Seeders;
using Microsoft.EntityFrameworkCore;
namespace HotelBooking.Data
{
    public class DataInitializer
    {

        private readonly RoomSeeder _roomSeeder;
        private readonly CustomerSeeder _customerSeeder;

        public DataInitializer(RoomSeeder roomSeeder, CustomerSeeder customerSeeder)
        {

            _roomSeeder = roomSeeder;
            _customerSeeder = customerSeeder;
        }

        public void MigrateAndSeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (!dbContext.Rooms.Any())
            {
                _roomSeeder.RoomSeeding(dbContext);
            }

            if (!dbContext.Customers.Any())
            {
                _customerSeeder.CustomerSeeding(dbContext);
            }
        }
    }
}