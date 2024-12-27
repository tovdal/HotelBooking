using HotelBooking.Data;

namespace HotelBooking.Service.BookingService
{
    public class BookingUpdate
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingUpdate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
