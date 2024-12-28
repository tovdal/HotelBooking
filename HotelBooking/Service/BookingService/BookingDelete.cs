using HotelBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.BookingService
{
    internal class BookingDelete
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingDelete(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool HasBooking(int customerId)
        {
            return _dbContext.Customers
                .Any(c => c.Id == customerId && c.Bookings.Any());
        }

    }
}
