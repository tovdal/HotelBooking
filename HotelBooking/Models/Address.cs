using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; } 
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}