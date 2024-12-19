using HotelBooking.Controllers.Interfaces;
using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu
{
    public class CustomersMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly MenuHandler _menuHandler;
        private readonly ICustomerController _customerController;

        public CustomersMenu(MenuDisplay menuDisplay, ICustomerController customerController)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _customerController = customerController;
        }
        public void ExecuteMainMenuAction()
        {
            List<string> menuItems = new List<string>()
            {
                "Create a new Customer",
                "Show all customers",
                "Show all active customers",
                "Show all inactive customers",
                "Show all deleted customers",
                "Show a Customer detailes",
                "Update a Customer",
                "Delete a Customer",
                "Take back a deleted Customer",
                "Back to main menu"
            };

            // Use the MenuHandler to handle navigation
            _menuHandler.ShowMenu(menuItems, selectedIndex =>
            {
                switch (selectedIndex)
                {
                    case 0:
                        _customerController.CreateCustomer();
                        break;
                    case 1:
                        _customerController.ReadAllCustomers();
                        break;
                    case 2:
                        _customerController.ReadAllActive();
                        break;
                    case 3:
                        _customerController.ReadAllInactive();
                        break;
                    case 4:
                        _customerController.ReadAllDeleted();
                        break;
                    case 5:
                        _customerController.ReadACustomer();
                        break;
                    case 6:
                        _customerController.UpdateACustomer();
                        break;
                    case 7:
                        _customerController.DeleteACustomer();
                        break;
                    case 8:
                        _customerController.TakeBackDeletedCustomer();
                        break;
                    case 9:
                        break;
                }
            });
        }
    }
}
