using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Controllers.Interfaces;

namespace HotelBooking.Controllers;

public class RoomController : IRoomController
{
    private readonly IRoomCreateController _roomCreateController;
    private readonly IRoomReadController _roomReadController;
    private readonly IRoomUpdateController _roomUpdateController;
    private readonly IRoomDeleteController _roomDeleteController;

    public RoomController(
        IRoomCreateController roomCreateController,
        IRoomReadController roomReadController,
        IRoomUpdateController roomUpdateController,
        IRoomDeleteController roomDeleteController)
    {
        _roomCreateController = roomCreateController;
        _roomReadController = roomReadController;
        _roomUpdateController = roomUpdateController;
        _roomDeleteController = roomDeleteController;
    }
    public void CreateRoom()
    {
        _roomCreateController.CreateANewRoom();
    }
    public void ReadAllRooms()
    {
        _roomReadController.ShowAllRooms();
    }

    public void ReadAllDeletedRooms()
    {
        _roomReadController.ShowAllDeletedRooms();
    }

    public void ReadARoomDetailes()
    {
        _roomReadController.ShowARoomDetailes();
    }

    public void UpdateARoom()
    {
        _roomUpdateController.UpdateARoomInformation();
    }

    public void DeleteARoom()
    {
        _roomDeleteController.DeleteRoom();
    }

    public void TakeBackDeletedRoom()
    {
        _roomUpdateController.GetBackDeletedRoom();
    }
}