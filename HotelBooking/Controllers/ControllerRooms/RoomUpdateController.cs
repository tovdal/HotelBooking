using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Controllers.ControllerRooms.RoomUpdateFolder.Interface;

namespace HotelBooking.Controllers.ControllerRooms
{
    public class RoomUpdateController : IRoomUpdateController
    {
        private readonly IRoomUpdateRoom _roomUpdateRoom;
        private readonly IRoomUpdateRestore _roomUpdateRestore;


        public RoomUpdateController(IRoomUpdateRoom roomUpdateRoom,
            IRoomUpdateRestore roomUpdateRestore)
        {
            _roomUpdateRoom = roomUpdateRoom;
            _roomUpdateRestore = roomUpdateRestore;
        }

        public void UpdateARoomInformation()
        {
            _roomUpdateRoom.UpdateARoomInformation();
        }

        public void GetBackDeletedRoom()
        {
            _roomUpdateRestore.GetBackDeletedRoom();
        }
    }
}