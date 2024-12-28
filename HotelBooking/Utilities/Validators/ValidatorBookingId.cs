namespace HotelBooking.Utilities.Validators
{
    public class ValidatorBookingId
    {
        public static bool TryGetBookingId(out int bookingId)
        {
            Console.WriteLine("Enter the ID of the Booking: ");
            var stringCustomerID = Console.ReadLine();

            if (!int.TryParse(stringCustomerID, out bookingId))
            {
                Console.WriteLine("Please enter a valid number ID.");
                return false;
            }

            return true;
        }
    }
}
