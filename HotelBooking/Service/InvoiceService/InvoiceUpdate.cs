using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.InvoiceService
{
    public class InvoiceUpdate
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceUpdate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Booking ReturnInvoiceWithId(int id)
        {
            return _dbContext.Bookings.FirstOrDefault(i => i.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
