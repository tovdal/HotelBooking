using HotelBooking.Data;
using HotelBooking.Menu.Startup;

namespace HotelBooking
{
    internal class App
    {
        private readonly MainHotelMenu _mainHotelMenu;
        private readonly DataInitializer _dataInitializer;

        public App(MainHotelMenu mainHotelMenu, DataInitializer dataInitializer)
        {
            _mainHotelMenu = mainHotelMenu;
            _dataInitializer = dataInitializer;
        }

        public void Run()
        {
            _dataInitializer.MigrateAndSeedData();
            _mainHotelMenu.ShowMenu();
        }
    }
}
