using HotelBooking.Controllers;
using HotelBooking.Controllers.Interfaces;
using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu.Startup
{
    public class MainHotelMenu
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IMainMenuAction[] _actionsMainMenu;
        private readonly MenuNavigator _menuNavigator;

        public MainHotelMenu(
            MenuDisplay menuDisplay,
            ICustomerController customerController,
            IRoomController roomController,
            IBookingController bookingController,
            IInvoiceController invoiceController)
        {
            _menuDisplay = menuDisplay;
            _menuNavigator = new MenuNavigator();
            _actionsMainMenu = InitializeMainMenuActions
                (menuDisplay, customerController, 
                roomController, bookingController,
                invoiceController);
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
                    "Customers",
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
        private IMainMenuAction[] InitializeMainMenuActions(
            MenuDisplay menuDisplay,
            ICustomerController customerController,
            IRoomController roomController,
            IBookingController bookingController,
            IInvoiceController invoiceController)
        {
            return new IMainMenuAction[]
            {
                new BookingsMenu(menuDisplay, bookingController),
                new CustomersMenu(menuDisplay, customerController),
                new RoomsMenu(menuDisplay, roomController),
                new InvoiceMenu(menuDisplay, invoiceController)
            };
        }
    }
}