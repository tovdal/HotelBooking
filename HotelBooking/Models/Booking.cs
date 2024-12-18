﻿namespace HotelBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public decimal TotalCostOfTheBooking { get; set; }
        public StatusOnBooking Status { get; set; }

        // Man behöver en eller flera rum för en bokning.
        public List<Room> Rooms { get; set; } = new List<Room>();

        // Men bra en faktura för allt.
        public Invoice Invoice { get; set; } = null!;
    }
    public enum StatusOnBooking
    {
        Active,
        Inactive
    }
}