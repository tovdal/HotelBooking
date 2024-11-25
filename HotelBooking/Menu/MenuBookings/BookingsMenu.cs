using HotelBooking.Menu.MenuStartHotelApp;

namespace HotelBooking.Menu.MenuBookings
{
    public class BookingsMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IBookingsMenuAction[] _actionsBookingsMenu;
        private readonly MenuNavigator _menuNavigator;

        public BookingsMenu(MenuDisplay menuDisplay, IBookingsMenuAction[] actions)
        {
            _menuDisplay = menuDisplay;
            _menuNavigator = new MenuNavigator();  // Reusable menu navigator
            _actionsBookingsMenu = new IBookingsMenuAction[]
            {
                // Actions 
            };
        }

        public void ExecuteMainMenuAction()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                _menuDisplay.PrintMenuText();
                List<string> menuItems = new List<string>()
                {
                    "Create a new Booking", "Show all registerd Bookings",
                    "Update a booking", "All deleted bookings",
                    "Take back a deleted booking", "Back to main menu"
                };
                // Create ,Read, Update, "Soft" Delete

                _menuNavigator.Navigate(menuItems, selectedIndex =>
                {
                    if (selectedIndex == 5)  // Exit
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        exit = true;  // Set exit flag to true to break the loop
                        return;
                    }

                    Console.Clear();
                    _actionsBookingsMenu[selectedIndex].ExecuteBookingAction();
                });
            }
        }
    }
}