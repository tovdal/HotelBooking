using HotelBooking.Render;

namespace HotelBooking.Menu
{
    public class MenuDisplay
    {
        public void PrintMenuText()
        {
            BorderRender.RenderBorder(8, 58, 45, 20);
            Console.SetCursorPosition(65, 10);
            Console.Write("Make a choice in the menu:");
        }
    }
}
