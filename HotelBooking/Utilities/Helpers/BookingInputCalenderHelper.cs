using Spectre.Console;

namespace HotelBooking.Utilities.Helpers
{
    public class BookingInputCalenderHelper
    {
        public static string GetBookingDateCalendar(DateTime selectedDate)
        {
            var calendarContent = new StringWriter();

            calendarContent.WriteLine($"[red]{selectedDate:MMMM}[/]".ToUpper());
            calendarContent.WriteLine("Mon  Tue  Wed  Thu  Fri  Sat  Sun");
            calendarContent.WriteLine("─────────────────────────────────");

            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = (startDay == 0) ? 6 : startDay - 1;

            for (int i = 0; i < startDay; i++)
            {
                calendarContent.Write("     ");
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day == selectedDate.Day)
                {
                    calendarContent.Write($"[green]{day,2}[/]   ");
                }
                else
                {
                    calendarContent.Write($"{day,2}   ");
                }

                if ((startDay + day) % 7 == 0)
                {
                    calendarContent.WriteLine();
                }
            }

            return calendarContent.ToString();
        }

        public static void DisplayBookingDateCalendar(DateTime selectedDate)
        {
            string calendarContent = GetBookingDateCalendar(selectedDate);

            var panel = new Panel(calendarContent)
            {
                Border = BoxBorder.Double,
                Header = new PanelHeader($"[red]{selectedDate:yyyy}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            AnsiConsole.MarkupLine("\nUse arrow keys[blue]\u25C4 \u25B2 \u25BA \u25BC[/]to navigate and [green]Enter[/] to select.");
        }

        public static DateTime HandleUserInput(DateTime selectedDate, DateTime? checkInDate = null)
        {
            while (true)
            {
                Console.Clear();
                DisplayBookingDateCalendar(selectedDate);

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        selectedDate = selectedDate.AddDays(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        selectedDate = selectedDate.AddDays(-1);
                        break;
                    case ConsoleKey.UpArrow:
                        selectedDate = selectedDate.AddDays(-7);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedDate = selectedDate.AddDays(7);
                        break;
                    case ConsoleKey.Enter:
                        if (selectedDate < DateTime.Now.Date)
                        {
                            AnsiConsole.MarkupLine("[red]You cannot book a date in the past.[/]");
                            Console.ReadKey();
                        }
                        else if (checkInDate.HasValue && selectedDate <= checkInDate.Value)
                        {
                            AnsiConsole.MarkupLine("[red]The check-out date cannot be earlier than the check-in date.[/]");
                            Console.ReadKey();
                        }
                        else
                        {
                            AnsiConsole.MarkupLine($"\nYou selected: [green]{selectedDate:yyyy-MM-dd}[/]");
                            Console.ReadKey();
                            return selectedDate;
                        }
                        break;
                    case ConsoleKey.Escape:
                        return DateTime.MinValue;
                }
            }
        }
    }
}