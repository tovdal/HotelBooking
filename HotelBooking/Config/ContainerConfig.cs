using Autofac;
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

            builder.RegisterType<MenuDisplay>().AsSelf();

            return builder.Build();
        }
    }
}
