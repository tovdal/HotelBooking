﻿using HotelBooking.Controllers.Interfaces;
using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu
{
    public class InvoiceMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly MenuHandler _menuHandler;
        private readonly IInvoiceController _invoiceController;

        public InvoiceMenu(MenuDisplay menuDisplay, IInvoiceController invoiceController)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _invoiceController = invoiceController;

        }
        public void ExecuteMainMenuAction()
        {
            _menuDisplay.PrintMenuText();
            List<string> menuItems = new List<string>()
            {
                "Show all invoices",
                "Show a invoice's details",
                "Update a invoice",
                "Pay a invoice",
                "Back to main menu"
            };

            _menuHandler.ShowMenu(menuItems, selectedIndex =>
            {
                switch (selectedIndex)
                {
                    case 0:
                        _invoiceController.ShowAllInvoices();
                        break;
                    case 1:
                        _invoiceController.ShowAInvoiceDetails();
                        break;
                    case 2:
                        _invoiceController.UpdateAInvoice();
                        break;
                    case 3:
                        _invoiceController.PayAInvoice();
                        break;
                    case 4:
                        break;
                }
            });
        }
    }
}