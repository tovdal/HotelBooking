using HotelBooking.Menu.MenuStartHotelApp;

namespace HotelBooking.Menu.MenuGuests
{
    public class GuestsMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IGuestsMenuAction[] _actionsGuestsMenu;
        private readonly MenuNavigator _menuNavigator;

        public GuestsMenu(MenuDisplay menuDisplay, IGuestsMenuAction[] actions)
        {
            _menuDisplay = menuDisplay;
            _menuNavigator = new MenuNavigator();  // Reusable menu navigator
            _actionsGuestsMenu = new IGuestsMenuAction[]
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
                    "Create a new guest", 
                    "Show all active guests",
                    "Show all guests that have stayed at the hotel",
                    "Show all deleted guests",
                    "Update a guest", 
                    "Delete a guest",
                    "Take back a deleted guest", 
                    "Back to main menu"
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
                    _actionsGuestsMenu[selectedIndex].ExecuteGuestAction();
                });
            }
        }
    }
}
