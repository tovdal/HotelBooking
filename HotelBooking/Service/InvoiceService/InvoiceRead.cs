using HotelBooking.Data;
using HotelBooking.Models;

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
                .Where(i => i.IsPaid == false)
                .OrderBy(i => i.Id)
                .ToList();
        }
        public IEnumerable<Invoice> GetAllPayedInvoices()
        {
            return _dbContext.Invoices
                .Where(i => i.IsPaid == true)
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
