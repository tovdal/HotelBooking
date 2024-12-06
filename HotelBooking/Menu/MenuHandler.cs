using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Menu
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

        public void ExecuteMenuAction(List<string> menuItems, Action<int> actionOnSelect)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                _menuDisplay.PrintMenuText();
                _menuNavigator.Navigate(menuItems, selectedIndex =>
                {
                    if (selectedIndex == menuItems.Count - 1)  // Exit option (last item in menu)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ReadKey();
                        exit = true;  // Exit flag to break the loop
                        return;
                    }

                    Console.Clear();
                    actionOnSelect(selectedIndex);
                });
            }
        }
    }
}
