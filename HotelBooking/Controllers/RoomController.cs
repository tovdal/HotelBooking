using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Controllers.Interfaces;
using HotelBooking.Service.RoomService;

namespace HotelBooking.Controllers
{
    public class RoomController : IRoomController
    {
        private readonly IRoomCreateController _roomCreateController;
        private readonly IRoomReadController _roomReadController;

        public RoomController(IRoomCreateController roomCreateController, IRoomReadController roomReadController)
        {
            _roomCreateController = roomCreateController;
            _roomReadController = roomReadController;
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
            throw new NotImplementedException();
        }

        public void DeleteARoom()
        {
            throw new NotImplementedException();
        }

        public void TakeBackDeletedRoom()
        {
            throw new NotImplementedException();
        }
    }
}
