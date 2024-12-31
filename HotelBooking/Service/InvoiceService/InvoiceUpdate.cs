using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Service.InvoiceService.Interfaces;

namespace HotelBooking.Service.InvoiceService
{
    public class InvoiceUpdate : IInvoiceUpdate
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceUpdate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Invoice ReturnInvoiceWithId(int id)
        {
            return _dbContext.Invoices.FirstOrDefault(i => i.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
