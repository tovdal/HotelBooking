using Autofac;
using HotelBooking.Data;
using HotelBooking.Display.Menu;
using HotelBooking.Menu;
using HotelBooking.Menu.Actions;
using HotelBooking.Menu.Startup;

namespace HotelBooking.Config
{
    public class ContainerConfig
    {
        public static IContainer BuilderContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<App>();

            builder.RegisterType<DataInitializer>().AsSelf().SingleInstance();
            // SingelTon

            builder.RegisterType<MainHotelMenu>().AsSelf();

            builder.RegisterType<RoomsMenu>().As<IMainMenuAction>();
            builder.RegisterType<CustomersMenu>().As<IMainMenuAction>();
            builder.RegisterType<BookingsMenu>().As<IMainMenuAction>();
            builder.RegisterType<InvoiceMenu>().As<IMainMenuAction>();


            builder.RegisterType<MenuDisplay>().AsSelf();

            return builder.Build();
        }
    }
}
