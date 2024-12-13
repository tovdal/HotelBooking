using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.GuestService
{
    public class GuestCreate
    {
        private readonly HotelBookingDbContext _dbContext;

        public GuestCreate(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Create
        public void AddGuest(Guest newGuest)
        {
            _dbContext.Add(newGuest);
            //dbContext.SaveChanges(); // the dbContext not created yet
        }
    }
}
