using HotelBooking.Controllers.Interfaces;
using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu.Submenus
{
    public class RoomsMenu : IMainMenuAction
    {
        private readonly MenuDisplay _menuDisplay;
        private readonly MenuHandler _menuHandler;
        private readonly IRoomController _roomController;

        public RoomsMenu(MenuDisplay menuDisplay, IRoomController roomController)
        {
            _menuDisplay = menuDisplay;
            _menuHandler = new MenuHandler(_menuDisplay, new MenuNavigator());
            _roomController = roomController;
        }

        public void ExecuteMainMenuAction()
        {
            List<string> menuItems = new List<string>()
            {
                "Create a new Room",
                "Show all Rooms",
                "Show all deleted Rooms",
                "Show a Room's details",
                "Update a Room",
                "Delete a Room",
                "Take back a deleted Room",
                "Back to main menu"
            };

            _menuHandler.ShowMenu(menuItems, selectedIndex =>
            {
                switch (selectedIndex)
                {
                    case 0:
                        _roomController.CreateRoom();
                        break;
                    case 1:
                        _roomController.ReadAllRooms();
                        break;
                    case 2:
                        _roomController.ReadAllDeletedRooms();
                        break;
                    case 3:
                        _roomController.ReadARoomDetailes();
                        break;
                    case 4:
                        _roomController.UpdateARoom();
                        break;
                    case 5:
                        _roomController.DeleteARoom();
                        break;
                    case 6:
                        _roomController.TakeBackDeletedRoom();
                        break;
                    case 7:
                        break;
                }
            });
        }
    }
}