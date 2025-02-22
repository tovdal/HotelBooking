﻿namespace HotelBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public BookingStatus Status { get; set; }

        public Customer Customer { get; set; } = null!;
        public List<Room> Rooms { get; set; } = new List<Room>();
        public Invoice Invoice { get; set; } = null!;
    }

    public enum BookingStatus
    {
        Active,
        Deleted
    }
}