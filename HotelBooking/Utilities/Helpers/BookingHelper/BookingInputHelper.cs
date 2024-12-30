using HotelBooking.Models;
using HotelBooking.Service.BookingService;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers.BookingHelper
{
    public static class BookingInputHelper
    {
        public static int PromptBookingId()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>("Enter booking ID: ")
                    .ValidationErrorMessage("[red]Please enter a valid booking " +
                    "ID![/]")
                    .Validate(id => id > 0)
            );
        }

        public static Booking PromptBookingDetails()
        {
            var checkInDate = PromptCheckInDate();
            var checkOutDate = PromptCheckOutDate(checkInDate);

            return new Booking
            {
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                Status = BookingStatus.Active,
            };
        }

        public static DateTime PromptCheckInDate()
        {
            AnsiConsole.MarkupLine("[bold green]Pick check-in date[/]");
            return BookingInputCalenderHelper.HandleUserInput(DateTime.Now);
        }

        public static DateTime PromptCheckOutDate(DateTime checkInDate)
        {
            AnsiConsole.MarkupLine("[bold green]Pick check-out date[/]");
            return BookingInputCalenderHelper.HandleUserInput
            (checkInDate, checkInDate);
        }

        public static DateTime PromptInvoiceDate(DateTime selectedCheckInDate)
        {
            DateTime dueDateOnInvoice;
            if (selectedCheckInDate.Date == DateTime.Now.Date)
            {
                dueDateOnInvoice = DateTime.Now.Date.AddHours(23).AddMinutes(59);
            }
            else if ((selectedCheckInDate - DateTime.Now).Days <= 10)
            {
                dueDateOnInvoice = DateTime.Now;
            }
            else
            {
                dueDateOnInvoice = selectedCheckInDate.AddDays(-10);
            }
            return dueDateOnInvoice;
        }

        public static Booking PromptCustomerDetails(int customerId,
            DateTime selectedCheckInDate, DateTime selectedCheckOutDate,
            BookingCreate bookingCreate, decimal totalBookingPrice)
        {
            return new Booking
            {
                CustomerId = customerId,
                CheckInDate = selectedCheckInDate,
                CheckOutDate = selectedCheckOutDate,
                Status = BookingStatus.Active,
                Rooms = bookingCreate.GetRoomsToBook(),
                Invoice = PromptInvoice(totalBookingPrice, selectedCheckInDate)
            };
        }

        public static Invoice PromptInvoice(decimal totalBookingPrice,
            DateTime selectedCheckInDate)
        {
            return new Invoice
            {
                CostAmount = totalBookingPrice,
                InvoiceDate = DateTime.Now,
                DueDateOnInvoice = PromptInvoiceDate(selectedCheckInDate),
                IsPaid = false
            };
        }
    }
}