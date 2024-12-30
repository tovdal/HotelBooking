namespace HotelBooking.Service.MenuService
{
    public class MenuNavigator
    {
        private int _currentSelect = 0;

        public void Navigate(List<string> menuItems, Action<int> onSelect)
        {
            _currentSelect = 0;
            while (true)
            {
                for (int i = 0; i < menuItems.Count; i++)
                {
                    Console.SetCursorPosition(62, 22 + i);
                    if (i == _currentSelect)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"-> {menuItems[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"- {menuItems[i]} -");
                    }
                    Console.ResetColor();
                }

                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _currentSelect = _currentSelect > 0 ? _currentSelect - 1 : menuItems.Count - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _currentSelect = _currentSelect < menuItems.Count - 1 ? _currentSelect + 1 : 0;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    onSelect(_currentSelect);
                    break;
                }
            }
        }
    }
}
