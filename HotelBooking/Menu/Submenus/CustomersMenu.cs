﻿using HotelBooking.Controllers.Interfaces;
using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu.Submenus
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
                "Show all deleted customers",
                "Show a Customer details",
                "Update a Customer",
                "Delete a Customer",
                "Take back a deleted Customer",
                "Back to main menu"
            };

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
                        _customerController.ReadAllDeleted();
                        break;
                    case 3:
                        _customerController.ReadACustomer();
                        break;
                    case 4:
                        _customerController.UpdateACustomer();
                        break;
                    case 5:
                        _customerController.DeleteACustomer();
                        break;
                    case 6:
                        _customerController.TakeBackDeletedCustomer();
                        break;
                    case 7:
                        break;
                }
            });
        }
    }
}