using HotelBooking.Display.Menu;
using HotelBooking.Menu.Actions;
using HotelBooking.Service;
using HotelBooking.Service.MenuService;

namespace HotelBooking.Menu
{
    public class CustomersMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly ICustomersMenuAction[] _actionsCustomersMenu;
        private readonly MenuHandler _menuHandler;

        public CustomersMenu(MenuDisplay menuDisplay)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _actionsCustomersMenu = InitializeCustomerActions();
        }
        public void ExecuteMainMenuAction()
        {
            List<string> menuItems = new List<string>()
            {
                "Create a new Customer",
                "Show all active customers",
                "Show all inactive customers",
                "Show all deleted customers",
                "Show all Customer detailes",
                "Show a Customer detailes",
                "Update a Customer",
                "Delete a Customer",
                "Take back a deleted Customer",
                "Back to main menu"
            };

            // Use the MenuHandler to handle navigation
            _menuHandler.ShowMenu(menuItems, selectedIndex =>
            {
                if (selectedIndex < _actionsCustomersMenu.Length)
                {
                    _actionsCustomersMenu[selectedIndex].ExecuteCustomerAction();
                }
            });
        }
        private ICustomersMenuAction[] InitializeCustomerActions()
        {
            return new ICustomersMenuAction[]
            {
            //new CreateGuestAction(),
            //new ShowActiveGuestsAction(),
            //new ShowAllGuestsAction(),
            //new ShowDeletedGuestsAction(),
            //new UpdateGuestAction(),
            //new DeleteGuestAction(),
            //new RestoreDeletedGuestAction()
            };
        }
    }
}
