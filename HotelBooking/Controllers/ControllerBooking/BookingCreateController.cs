using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Service.BookingService;
using Spectre.Console;

namespace HotelBooking.Controllers.ControllerBooking
{
    public class BookingCreateController : IBookingCreateController
    {
        private readonly BookingCreate _bookingCreate;
        public BookingCreateController(BookingCreate bookingCreate)
        {
            _bookingCreate = bookingCreate;
        }
        public void CreateBooking()
        {
            bool IsRunning = true;
            while (IsRunning)
            {
                AnsiConsole.MarkupLine("[bold green]1.Registrat a new booking[/]");

                bool confirmCustomer = AnsiConsole.Confirm("\nIs it a new customer that wishes to make a booking?");
                if (confirmCustomer)
                {
                    AnsiConsole.MarkupLine("[bold green]Customer needs to be registerd first![/]");
                    Console.ReadKey();
                    break;
                }

                bool confirm = AnsiConsole.Confirm("\n[bold yellow]Are all details correct?[/]");
                if (confirm)
                {
                    //_bookingCreate.AddBooking(newBooking);
                    AnsiConsole.MarkupLine("[bold green]Booking successfully registered![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Registration canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("\nDo you want to add another booking?");
                if (!addAnother)
                {
                    IsRunning = false;
                }
            }
        }
    }
}