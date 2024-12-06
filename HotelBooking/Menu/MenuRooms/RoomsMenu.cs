
using HotelBooking.Menu.MenuStartHotelApp;

namespace HotelBooking.Menu.MenuRooms
{
    public class RoomsMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IRoomsMenuAction[] _actionsRoomsMenu;
        private readonly MenuNavigator _menuNavigator;

        public RoomsMenu(MenuDisplay menuDisplay, IRoomsMenuAction[] actions)
        {
            _menuDisplay = menuDisplay;
            _menuNavigator = new MenuNavigator();  // Reusable menu navigator
            _actionsRoomsMenu = new IRoomsMenuAction[]
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
                    "Create a new room",
                    "Show all available rooms", 
                    "Show all take rooms",
                    "Show deleted rooms",
                    "Update a room",
                    "Delete a room",
                    "Take back a deleted room", 
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
                    _actionsRoomsMenu[selectedIndex].ExecuteRoomAction();
                });
            }
        }
    }
}
