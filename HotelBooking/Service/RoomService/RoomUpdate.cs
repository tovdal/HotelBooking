using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace HotelBooking.Service.RoomService
{
    public class RoomUpdate : IRoomUpdate
    {
        private readonly ApplicationDbContext _dbContext;
        public RoomUpdate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room ReturnCustomerWithId(int id)
        {
            return _dbContext.Rooms.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateRoomAndBookingAvailability()
        {
            var rooms = _dbContext.Rooms.Include(r => r.Bookings)
                        .ThenInclude(b => b.Invoice).ToList();

            foreach (var room in rooms)
            {
                foreach (var booking in room.Bookings)
                {
                    if (booking.Status == BookingStatus.Active)
                    {
                        var daysSinceInvoice = (DateTime.Now - booking.Invoice.InvoiceDate).TotalDays;

                        if (daysSinceInvoice > 10 && !booking.Invoice.IsPaid)
                        {
                            booking.Status = BookingStatus.Deleted;
                            AnsiConsole.MarkupLine($"[red]Booking ID: {booking.Id} has more than 10 days since invoice[/]");
                            AnsiConsole.MarkupLine($"[red]Booking ID: {booking.Id} has been marked as Deleted.[/]");
                            Console.ReadKey();
                        }
                    }
                }

                room.IsAvailable = room.Bookings
                    .All(b => b.Status == BookingStatus.Deleted
                    || b.CheckOutDate <= DateTime.Now
                    || b.CheckInDate >= DateTime.Now);
            }

            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
