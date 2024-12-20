namespace HotelBooking.Utilities.Validators
{
    public class ValidatorCustomerId
    {
        public static bool TryGetCustomerId(out int customerId)
        {
            Console.WriteLine("Enter the ID of the Customer: ");
            var stringCustomerID = Console.ReadLine();

            if (!int.TryParse(stringCustomerID, out customerId))
            {
                Console.WriteLine("Please enter a valid number ID.");
                return false;
            }

            return true;
        }
    }
}
