using HotelBooking.Service.RoomService;

namespace HotelBooking.Controllers
{
    public class RoomController
    {
        private readonly RoomRead _roomRead;

        public RoomController(RoomRead roomRead)
        {
            _roomRead = roomRead;
        }
        //public void CreateNewRoom()
        //{
        //    Guest.Add(newRoom);
        //    // Richard said that this was important or it wont save to database
        //    dbContext.SaveChanges(); // the dbContext not created yet
        //}

        ////Read
        public void ShowAllRooms()
        {
            var rooms = _roomRead.GetAllRoomsInDatabase();
            foreach (var room in rooms)
            {
                Console.WriteLine(room);
            }
        }

        //public List<Room> GetTakenRoomsInDatabase()
        //{
        //    return
        //}

        //public List<Room> GetDeteletRoomsInDatabase()
        //{
        //    return
        //}


        //Update
        public void UpdateRoomStatus()
        {

        }
        public void TakeBackSoftDeletedRoom()
        {

        }

        // Delete
        public void SoftDeleteRoom()
        {

        }
    }
}
