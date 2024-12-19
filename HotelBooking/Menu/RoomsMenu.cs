using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu
{
    public class RoomsMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly IRoomsMenuAction[] _actionsRoomsMenu;
        private readonly MenuHandler _menuHandler;

        public RoomsMenu(MenuDisplay menuDisplay)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _actionsRoomsMenu = InitializeRoomActions();
        }

        public void ExecuteMainMenuAction()
        {
            _menuDisplay.PrintMenuText();
            List<string> menuItems = new List<string>()
            {
                "Create a new room",
                "Show all available rooms",
                "Show all taken rooms",
                "Show deleted rooms",
                "Update a room",
                "Delete a room",
                "Take back a deleted room",
                "Back to main menu"
            };

            //MenuHandler
            _menuHandler
                .ShowMenu(menuItems, selectedIndex =>
            {
                if (selectedIndex < _actionsRoomsMenu.Length)
                {
                    _actionsRoomsMenu[selectedIndex].ExecuteRoomAction();
                }
            });
        }

        private IRoomsMenuAction[] InitializeRoomActions()
        {
            return new IRoomsMenuAction[]
            {
            //new CreateRoomAction(),
            //new ShowAvailableRoomsAction(),
            //new ShowTakenRoomsAction(),
            //new ShowDeletedRoomsAction(),
            //new UpdateRoomAction(),
            //new DeleteRoomAction(),
            //new TakeBackDeletedRoomAction()
            };
        }
    }
}