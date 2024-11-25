using Autofac;
using HotelBooking.Menu;
using HotelBooking.Menu.MenuBookings;
using HotelBooking.Menu.MenuGuests;
using HotelBooking.Menu.MenuRooms;
using HotelBooking.Menu.MenuStartHotelApp;

namespace HotelBooking.Config
{
    public class ContainerConfig
    {
        public static IContainer BuilderContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<App>();

            builder.RegisterType<MainHotelMenu>().AsSelf();

            builder.RegisterType<RoomsMenu>().As<IMainMenuAction>();
            builder.RegisterType<GuestsMenu>().As<IMainMenuAction>();
            builder.RegisterType<BookingsMenu>().As<IMainMenuAction>();


            builder.RegisterType<MenuDisplay>().AsSelf();

            return builder.Build();
        }
    }
}
