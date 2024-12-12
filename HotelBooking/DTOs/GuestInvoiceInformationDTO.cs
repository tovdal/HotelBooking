using HotelBooking.Models;

namespace HotelBooking.DTOs
{
    public class GuestInvoiceInformationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal CostAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    }
}
