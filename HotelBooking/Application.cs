using HotelBooking.Config;
using HotelBooking.Data;
using HotelBooking.Menu.Startup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelBooking
{
    public class Application
    {
        private readonly MainHotelMenu _mainHotelMenu;
        private readonly DataInitializer _dataInitializer;
        private readonly ApplicationDbContext _dbContext;

        public Application(MainHotelMenu mainHotelMenu, DataInitializer dataInitializer, ApplicationDbContext dbContext)
        {
            _mainHotelMenu = mainHotelMenu;
            _dataInitializer = dataInitializer;
            _dbContext = dbContext;
        }

        public void Run()
        {

                _dataInitializer.MigrateAndSeedData();
                _mainHotelMenu.ShowMenu();
            
        }
    }
}
