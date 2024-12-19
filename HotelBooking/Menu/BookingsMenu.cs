using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu
{
    public class BookingsMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IBookingsMenuAction[] _actionsBookingsMenu;
        private readonly MenuHandler _menuHandler;

        public BookingsMenu(MenuDisplay menuDisplay)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _actionsBookingsMenu = InitializeBookingAction();

        }

        public void ExecuteMainMenuAction()
        {
            _menuDisplay.PrintMenuText();
            List<string> menuItems = new List<string>()
            {
                "Create a new Booking",
                "Show all registerd Bookings",
                "Update a booking",
                "All deleted bookings",
                "Take back a deleted booking",
                "Back to main menu"
            };

            _menuHandler.ShowMenu(menuItems, selectedIndex =>
            {
                if (selectedIndex < _actionsBookingsMenu.Length)
                {
                    _actionsBookingsMenu[selectedIndex].ExecuteBookingAction();
                }
            });
        }
        private IBookingsMenuAction[] InitializeBookingAction()
        {
            return new IBookingsMenuAction[]
            {
                //
            };
        }
    }
}