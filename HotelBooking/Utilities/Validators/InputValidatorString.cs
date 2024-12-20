namespace HotelBooking.Utilities.Validators
{
    public class InputValidatorString
    {
        public static string GetValidUserInput(string inputFromUser)
        {
            string? input;

            while (true)
            {
                Console.WriteLine(inputFromUser);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Answer cannot be empty. Please try again.");
                }
                else
                {
                    break;
                }
            }
            return input;
        }
    }
}
