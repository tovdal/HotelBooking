using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.InvoiceService
{
    public class InvoiceRead
    {
        private readonly ApplicationDbContext _dbContext;
        public InvoiceRead(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Invoice> GetAllInvoices()
        {
            return _dbContext.Invoices
                .OrderBy(i => i.Id)
                .ToList();
        }
        public IEnumerable<Invoice> GetAllActiveInvoices()
        {
            return _dbContext.Invoices
                .Include(i => i.Booking)
                .Include(i => i.Booking.Rooms)
                .Include(i => i.Booking.Customer)
                .Where(i => !i.IsPaid)
                .OrderBy(i => i.Id)
                .ToList();
        }
        public IEnumerable<Invoice> GetAllPaidInvoices()
        {
            return _dbContext.Invoices
                .Where(i => i.IsPaid == true)
                .Include(i => i.Booking)
                .Include(i => i.Booking.Rooms)
                .Include(i => i.Booking.Customer)
                .OrderBy(i => i.Id)
                .ToList();
        }
        public IEnumerable<Invoice> GetAllNotPaidInvoices()
        {
            return _dbContext.Invoices
                .Where(i => i.IsPaid == false)
                .Include(i => i.Booking)
                .Include(i => i.Booking.Rooms)
                .Include(i => i.Booking.Customer)
                .OrderBy(i => i.Id)
                .ToList();
        }
        public IQueryable<Invoice> GetInvoiceDetails(int id)
        {
            return _dbContext.Invoices
                .Where(i => i.Id == id);
        }

    }
}
