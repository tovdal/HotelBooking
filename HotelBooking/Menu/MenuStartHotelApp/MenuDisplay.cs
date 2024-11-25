using HotelBooking.Render;

namespace HotelBooking.Menu.MenuStartHotelApp
{
    public class MenuDisplay
    {
        public void PrintMenuText()
        {
            BorderRender.RenderBorder(16, 28, 35, 15);
            Console.SetCursorPosition(35, 18);
            Console.Write("Make a choice in the menu:");
        }
    }
}
