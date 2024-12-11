using HotelBooking.Display.Menu;
using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;

namespace HotelBooking.Menu.Startup
{
    public class MainHotelMenu
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IMainMenuAction[] _actionsMainMenu;
        private readonly MenuHandler _mainMenuHandler;
        private readonly MenuNavigator _menuNavigator;

        public MainHotelMenu(MenuDisplay menuDisplay)
        {
            _menuDisplay = menuDisplay;
            _menuNavigator = new MenuNavigator();
            _actionsMainMenu = InitializeMainMenuActions(menuDisplay);
        }
        public void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                _menuDisplay.PrintMenuText();

                List<string> menuItems = new List<string>()
                {
                    "Bookings",
                    "Guests",
                    "Rooms",
                    "Invoices",
                    "Exit program"
                };
                _menuNavigator.Navigate(menuItems, selectedIndex =>
                {
                    if (selectedIndex == 4)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Closing down system...");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        exit = true;
                        return;
                    }
                    else
                    {
                        _actionsMainMenu[selectedIndex].ExecuteMainMenuAction();
                    }
                });
            }
        }
        private IMainMenuAction[] InitializeMainMenuActions(MenuDisplay menuDisplay)
        {
            return new IMainMenuAction[]
            {
                new BookingsMenu(menuDisplay), //0
                new GuestsMenu(menuDisplay),// 1
                new RoomsMenu(menuDisplay), // 2
                new InvoiceMenu(menuDisplay)//3
            };
        }
    }
}
