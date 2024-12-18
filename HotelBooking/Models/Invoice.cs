namespace HotelBooking.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal CostAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDateOnInvoice { get; set; }
        public bool IsPaid { get; set; }

        public Invoice()
        {
            InvoiceDate = new DateTime();
            InvoiceDate = DateTime.Now;

            DueDateOnInvoice = new DateTime();
            DueDateOnInvoice = DateTime.Now.AddDays(31);
        }
    }
}
