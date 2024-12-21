using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.Interfaces
{
    public interface IRoomController
    {
        void CreateRoom();
        void ReadAllRooms();
        void ReadAllDeletedRooms();
        void ReadARoomDetailes();
        void UpdateARoom();
        void DeleteARoom();
        void TakeBackDeletedRoom();
    }
}
