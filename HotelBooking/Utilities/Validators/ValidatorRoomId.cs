namespace HotelBooking.Utilities.Validators
{
    public class ValidatorRoomId
    {
        public static bool TryGetRoomId(out int roomId)
        {
            Console.WriteLine("Enter the ID of the room: ");
            var stringID = Console.ReadLine();

            if (!int.TryParse(stringID, out roomId))
            {
                Console.WriteLine("Please enter a valid number ID.");
                Console.ReadKey();
                return false;
            }

            return true;
        }
    }
}
