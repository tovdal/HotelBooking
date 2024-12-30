using HotelBooking.Data;
using HotelBooking.Menu.StartupMainmenu;
using HotelBooking.Utilities.Display;
using HotelBooking.Utilities.Helpers;

namespace HotelBooking
{
    public class Application
    {
        private readonly MainHotelMenu _mainHotelMenu;
        private readonly DataInitializer _dataInitializer;
        private readonly UpdateRooms _updateRooms;

        public Application(MainHotelMenu mainHotelMenu, DataInitializer dataInitializer, UpdateRooms updateRooms)
        {
            _mainHotelMenu = mainHotelMenu;
            _dataInitializer = dataInitializer;
            _updateRooms = updateRooms;
        }

        public void Run()
        {
            _dataInitializer.MigrateAndSeedData();
            _updateRooms.UpdateRoomAvailability();
            ConsoleScreenManager.ScreenSize();
            _mainHotelMenu.ShowMenu();
        }
    }
}