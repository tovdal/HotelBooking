using HotelBooking.Menu.MenuStartHotelApp;
using HotelBooking.Service;
using HotelBooking.Service.MenuService;

namespace HotelBooking.Menu.MenuGuests
{
    public class GuestsMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IGuestsMenuAction[] _actionsGuestsMenu;
        private readonly MenuHandler _menuHandler;

        public GuestsMenu(MenuDisplay menuDisplay)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _actionsGuestsMenu = InitializeGuestActions();
        }
        public void ExecuteMainMenuAction()
        {
            List<string> menuItems = new List<string>()
            {
                "Create a new guest",
                "Show all active guests",
                "Show all guests that have stayed at the hotel",
                "Show all deleted guests",
                "Update a guest",
                "Delete a guest",
                "Take back a deleted guest",
                "Back to main menu"
            };

            // Use the MenuHandler to handle navigation
            _menuHandler.ShowMenu(menuItems, selectedIndex =>
            {
                if (selectedIndex < _actionsGuestsMenu.Length)
                {
                    _actionsGuestsMenu[selectedIndex].ExecuteGuestAction();
                }
            });
        }
        private IGuestsMenuAction[] InitializeGuestActions()
        {
            return new IGuestsMenuAction[]
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
