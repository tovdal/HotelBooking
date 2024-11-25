namespace HotelBooking.Message
{
    public class ConsoleMessagePrinter
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
        }

        public static void SetCursorMessage(string message, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(message);
        }
    }
}
