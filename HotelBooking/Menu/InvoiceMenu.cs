using HotelBooking.Display.Menu;
using HotelBooking.Menu.Actions;
using HotelBooking.Service;
using HotelBooking.Service.MenuService;

namespace HotelBooking.Menu
{
    public class InvoiceMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IInvoiceMenuAction[] _actionsInvoiceMenu;
        private readonly MenuHandler _menuHandler;

        public InvoiceMenu(MenuDisplay menuDisplay)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _actionsInvoiceMenu = InitializeInvoiceAction();

        }
        public void ExecuteMainMenuAction()
        {
            _menuDisplay.PrintMenuText();
            List<string> menuItems = new List<string>()
            {
                "Create a new invoice",
                "Show all invoices",
                "Show all deleted invoices",
                "Update a invoice",
                "Delete a invoice",
                "Take back a deleted booking",
                "Back to main menu"
            };

            _menuHandler.ShowMenu(menuItems, selectedIndex =>
            {
                if (selectedIndex < _actionsInvoiceMenu.Length)
                {
                    _actionsInvoiceMenu[selectedIndex].ExecuteInvoiceAction();
                }
            });
        }
        private IInvoiceMenuAction[] InitializeInvoiceAction()
        {
            return new IInvoiceMenuAction[]
            {
                //
            };
        }
    }
}