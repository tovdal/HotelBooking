namespace HotelBooking.Utilities.Display.Render
{
    public class BorderRender
    {
        public static void RenderBorder(int y, int x, int width, int height)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write("╔" + new string('═', width - 2) + "╗"); // Top border

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("║" + new string(' ', width - 2) + "║"); // Side borders
            }

            Console.SetCursorPosition(x, y + height - 1);
            Console.Write("╚" + new string('═', width - 2) + "╝"); // Bottom border
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
