

using HotelBooking.Menu.MenuStartHotelApp;

namespace HotelBooking
{
    internal class App
    {
        private readonly MainHotelMenu _mainHotelMenu;

        public App(MainHotelMenu mainHotelMenu)
        {
            _mainHotelMenu = mainHotelMenu;
        }

        public void Run()
        {
            _mainHotelMenu.ShowMenu();
        }
    }
}
