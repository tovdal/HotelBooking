
namespace HotelBooking.Menu.MenuStartHotelApp
{
    public class MainHotelMenu
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IMenuAction[] _actions;
        private readonly MenuNavigator _menuNavigator;

        public MainHotelMenu(MenuDisplay menuDisplay, IMenuAction[] actions)
        {
            _menuDisplay = menuDisplay;
            _menuNavigator = new MenuNavigator();  // Reusable menu navigator
            _actions = new IMenuAction[]
            {
                // Actions 
            };
        }

        public void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                _menuDisplay.PrintMenuText();
                List<string> menuItems = new List<string>() { "Bookings", "Guests", "Invoices", "Rooms", "Exit" };

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
                    _actions[selectedIndex].Execute();
                });
            }
        }
    }
}
