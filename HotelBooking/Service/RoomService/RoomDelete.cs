using HotelBooking.Data;

namespace HotelBooking.Service.RoomService
{
    public class RoomDelete : IRoomDelete
    {
        private readonly ApplicationDbContext _dbContext;
        public RoomDelete(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool HasRoomBooking(int roomId)
        {
            return _dbContext.Rooms
                .Any(r => r.Id == roomId && r.Bookings.Any());
        }
    }
}
