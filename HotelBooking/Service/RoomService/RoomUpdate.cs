using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.RoomService
{
    public class RoomUpdate
    {
        private readonly ApplicationDbContext _dbContext;
        public RoomUpdate(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Room ReturnCustomerWithId(int id)
        {
            return _dbContext.Rooms.First(c => c.Id == id);
        }
    }
}
