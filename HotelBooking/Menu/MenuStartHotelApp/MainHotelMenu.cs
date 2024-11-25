using HotelBooking.Menu.MenuBookings;
using HotelBooking.Menu.MenuGuests;
using HotelBooking.Menu.MenuRooms;

namespace HotelBooking.Menu.MenuStartHotelApp
{
    public class MainHotelMenu
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IMainMenuAction[] _actionsMainMenu;
        private readonly IRoomsMenuAction[] _actionRoomsMenu;
        private readonly IGuestsMenuAction[] _actionGuestsMenu;
        private readonly IBookingsMenuAction[] _actionBookingsMenu;
        private readonly MenuNavigator _menuNavigator;

        public MainHotelMenu(MenuDisplay menuDisplay, IMainMenuAction[] actions)
        {
            _menuDisplay = menuDisplay;
            _menuNavigator = new MenuNavigator();  // Reusable menu navigator
            _actionsMainMenu = new IMainMenuAction[]
            {
                // Actions 
                new BookingsMenu(_menuDisplay, _actionBookingsMenu), //0
                new GuestsMenu(_menuDisplay, _actionGuestsMenu),// 1
                new RoomsMenu(_menuDisplay, _actionRoomsMenu) // 2
                 // Invoices

            };
        }

        public void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                _menuDisplay.PrintMenuText();
                List<string> menuItems = new List<string>() { "Bookings", "Guests", "Rooms", "Invoices", "Exit" };

                _menuNavigator.Navigate(menuItems, selectedIndex =>
                {
                    if (selectedIndex == 4)  // Exit
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Closing down system...");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        exit = true;  // Set exit flag to true to break the loop
                        return;
                    }

                    Console.Clear();
                    _actionsMainMenu[selectedIndex].ExecuteMainMenuAction();
                });
            }
        }
    }
}
