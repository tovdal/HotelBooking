using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal CostAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public int CustomerId {  get; set; } // Foreign key
        public Customer Customer { get; set; }

        public int BookingId { get; set; }// Foreign key
        public Booking Booking { get; set; }
    }
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Cancelled
    }
}
