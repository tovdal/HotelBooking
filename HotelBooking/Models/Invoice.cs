using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal CostAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public BookingDetails BookingDetails { get; set; } = null!;
    }
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Cancelled
    }
}
