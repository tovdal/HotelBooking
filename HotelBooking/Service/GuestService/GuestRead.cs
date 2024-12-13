using HotelBooking.Data;
using HotelBooking.Models;
namespace HotelBooking.Service.GuestService

{
    public class GuestRead
    {
        private readonly HotelBookingDbContext _dbContext;

        public GuestRead(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Read
        public List<Guest> GetAllGuestsInDatabase()
        {
            return _dbContext.Guests.ToList();
        }
        public List<Guest> GetAllActiveGuestsInDatabase()
        {
            return _dbContext.Guests.Where(g => g.IsGuestStatusActive).ToList();
        }

        public List<Guest> GetAllInactiveGuestsInDatabase()
        {
            return _dbContext.Guests.Where(g => !g.IsGuestStatusActive).ToList();
        }

        public List<Guest> GetAllDeletedGuestsInDatabase()
        {
            return _dbContext.Guests.Where(g => g.IsGuestDeleted).ToList();
        }
        public List<Guest> GetGuestDetailes(int id) 
        {
            return _dbContext.Guests.Where(g => g.GuestId == id).ToList();
        }
    }
}
