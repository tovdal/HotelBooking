using HotelBooking.Data;
using HotelBooking.Menu.Startup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelBooking
{
    internal class Application
    {
        private readonly MainHotelMenu _mainHotelMenu;
        private readonly DataInitializer _dataInitializer;

        public Application(MainHotelMenu mainHotelMenu, DataInitializer dataInitializer)
        {
            _mainHotelMenu = mainHotelMenu;
            _dataInitializer = dataInitializer;
        }

        public void Run()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                _dataInitializer.MigrateAndSeedData(dbContext);
                _mainHotelMenu.ShowMenu();
            }
        }
    }
}
