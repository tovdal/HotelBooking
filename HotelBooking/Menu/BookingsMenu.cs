using HotelBooking.Controllers.Interfaces;
using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu
{
    public class BookingsMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly MenuHandler _menuHandler;
        private readonly IBookingController _bookingController;

        public BookingsMenu(MenuDisplay menuDisplay, IBookingController bookingController)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _bookingController = bookingController;

        }

        public void ExecuteMainMenuAction()
        {
            List<string> menuItems = new List<string>()
            {
                "Create a new Booking",
                "Show all Bookings",
                "Show all deleted Bookings",
                "Show a Booking detailes",
                "Update a Booking",
                "Delete a Booking",
                "Take back a deleted Booking",
                "Back to main menu"
            };

            _menuHandler.ShowMenu(menuItems, selectedIndex =>
            {
                switch (selectedIndex)
                {
                    case 0:
                        _bookingController.CreateBooking();
                        break;
                    case 1:
                        _bookingController.ReadABooking();
                        //_customerController.ReadAllCustomers();
                        break;
                    case 2:
                        _bookingController.ReadAllDeleted();
                        //_customerController.ReadAllDeleted();
                        break;
                    case 3:
                        //_customerController.ReadACustomer();
                        _bookingController.ReadABooking();
                        break;
                    case 4:
                        //_customerController.UpdateACustomer();
                        _bookingController.UpdateABooking();
                        break;
                    case 5:
                        //_customerController.DeleteACustomer();
                        _bookingController.DeleteABooking();
                        break;
                    case 6:
                        //_customerController.TakeBackDeletedCustomer();
                        _bookingController.TakeBackDeletedBooking();
                        break;
                    case 7:
                        break;
                }
            });
        }
    }
}