using HotelBooking.Utilities.Display.Render;

namespace HotelBooking.Utilities.Display.Menu
{
    public class MenuDisplay
    {
        public void PrintMenuText()
        {
            HotelStartupScreenText.RenderStartUpScreenText();
            BorderRender.RenderBorder(15, 52, 45, 20);
            Console.SetCursorPosition(61, 20);
            Console.Write("Make a choice in the menu");
        }
    }
}
