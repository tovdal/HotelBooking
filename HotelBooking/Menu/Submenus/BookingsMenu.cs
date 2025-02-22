﻿using HotelBooking.Controllers.Interfaces;
using HotelBooking.Menu.Actions;
using HotelBooking.Service.MenuService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Menu.Submenus;

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
            "Show a Booking details",
            "Update a Booking",
            "Delete a Booking",
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
                    _bookingController.ReadAllBookings();
                    break;
                case 2:
                    _bookingController.ReadAllDeleted();
                    break;
                case 3:
                    _bookingController.ReadABooking();
                    break;
                case 4:
                    _bookingController.UpdateABooking();
                    break;
                case 5:
                    _bookingController.DeleteABooking();
                    break;
                case 6:
                    break;
            }
        });
    }
}