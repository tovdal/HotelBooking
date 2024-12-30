using HotelBooking.Data;
using HotelBooking.Menu.StartupMainmenu;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display;

namespace HotelBooking
{
    public class Application
    {
        private readonly MainHotelMenu _mainHotelMenu;
        private readonly DataInitializer _dataInitializer;
        private readonly RoomUpdate _roomUpdate;

        public Application(MainHotelMenu mainHotelMenu, DataInitializer dataInitializer, RoomUpdate roomUpdate)
        {
            _mainHotelMenu = mainHotelMenu;
            _dataInitializer = dataInitializer;
            _roomUpdate = roomUpdate;
        }

        public void Run()
        {
            _dataInitializer.MigrateAndSeedData();
            _roomUpdate.UpdateRoomAvailability();
            ConsoleScreenManager.ScreenSize();
            _mainHotelMenu.ShowMenu();
        }
    }
}