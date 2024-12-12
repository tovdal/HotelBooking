using HotelBooking.Models;

namespace HotelBooking.DTOs
{
    public class GuestInvoiceInformationDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal CostAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    }
}
