using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Service.MenuService
{
    public class MenuHandler
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly MenuNavigator _menuNavigator;

        public MenuHandler(MenuDisplay menuDisplay, MenuNavigator menuNavigator)
        {
            _menuDisplay = menuDisplay;
            _menuNavigator = menuNavigator;
        }

        public void ShowMenu(List<string> menuItems, Action<int> onSelect)
        {
            _menuNavigator.Navigate(menuItems, selectedIndex =>
            {

                if (selectedIndex == menuItems.Count - 1)  // Exit option (last item in menu)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
                }

                Console.Clear();
                onSelect(selectedIndex);
            });
        }
    }
}
