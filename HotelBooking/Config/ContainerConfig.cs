using Autofac;
using HotelBooking.Controllers;
using HotelBooking.Controllers.Interfaces;
using HotelBooking.Data;
using HotelBooking.Data.Seeders;
using HotelBooking.Display.Menu;
using HotelBooking.Menu;
using HotelBooking.Menu.Actions;
using HotelBooking.Menu.Startup;
using HotelBooking.Service.CustomerService;

namespace HotelBooking.Config
{
    public class ContainerConfig
    {
        public static IContainer BuilderContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>();

            builder.RegisterType<ApplicationDbContext>().SingleInstance();
            // SingelTon
            builder.RegisterType<DataInitializer>().AsSelf();
            builder.RegisterType<RoomSeeder>().AsSelf();
            builder.RegisterType<CustomerSeeder>().AsSelf();

            builder.RegisterType<MainHotelMenu>().AsSelf();
            builder.RegisterType<RoomsMenu>().As<IMainMenuAction>();
            builder.RegisterType<CustomersMenu>().As<IMainMenuAction>();
            builder.RegisterType<BookingsMenu>().As<IMainMenuAction>();
            builder.RegisterType<InvoiceMenu>().As<IMainMenuAction>();

            builder.RegisterType<CustomerController>().As<ICustomerController>();

            builder.RegisterType<CustomerCreate>().AsSelf();
            builder.RegisterType<CustomerRead>().AsSelf();
            builder.RegisterType<CustomerUpdate>().AsSelf();
            builder.RegisterType<CustomerDelete>().AsSelf();

            builder.RegisterType<MenuDisplay>().AsSelf();

            return builder.Build();
        }
    }
}
