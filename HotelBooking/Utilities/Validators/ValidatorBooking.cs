using HotelBooking.Models;
using HotelBooking.Service.BookingService;
using HotelBooking.Service.RoomService;
using Spectre.Console;

namespace HotelBooking.Utilities.Validators
{
    public class ValidatorBooking
    {
        public static bool TryGetBookingId(out int bookingId)
        {
            Console.Write("Enter the ID of the Booking: ");
            var stringCustomerID = Console.ReadLine();

            if (!int.TryParse(stringCustomerID, out bookingId))
            {
                Console.WriteLine("Please enter a valid number ID.");
                return false;
            }

            return true;
        }

        public static bool ValidateBookingForUpdate(Booking bookingToUpdate,
               int bookingId)
        {
            if (bookingToUpdate == null)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]No customer found with ID number: {bookingId}.[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static bool ValidateBookingsList(List<Booking> bookings)
        {
            if (bookings == null || bookings.Count == 0)
            {
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public static bool AreRoomsAvailable
            (IRoomRead roomRead, DateTime checkInDate, DateTime checkOutDate,
            List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                if (roomRead.IsRoomBooked(room.RoomNumber, checkInDate, checkOutDate))
                {
                    AnsiConsole.MarkupLine
                        ($"[bold red]Room {room.RoomNumber} is already booked " +
                        $"for the selected dates.[/]");
                   
                    Console.ReadKey();
                    return false;
                }
            }
            return true;
        }
        public static bool IsBookingDeleted(Booking booking, int bookingId)
        {
            if (booking.Status == BookingStatus.Deleted)
            {
                AnsiConsole.MarkupLine
                    ($"[bold red]Booking with ID number: {bookingId} is deleted.[/]");
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}