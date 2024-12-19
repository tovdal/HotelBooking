namespace HotelBooking.Utilities.Display.Message
{
    public class ConsoleMessagePrinter
    {
        public static void DisplayMessage()
        {
            Console.WriteLine("`\nPress any key to continue.");
            Console.ReadKey();
        }

        public static void SetCursorMessage(string message, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(message);
        }
    }
}
