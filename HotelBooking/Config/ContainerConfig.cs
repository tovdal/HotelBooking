using Autofac;
using HotelBooking.Controllers;
using HotelBooking.Controllers.ControllerCustomers;
using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Controllers.ControllerRooms;
using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Controllers.Interfaces;
using HotelBooking.Data;
using HotelBooking.Data.Seeders;
using HotelBooking.Menu;
using HotelBooking.Menu.Actions;
using HotelBooking.Menu.Startup;
using HotelBooking.Service.CustomerService;
using HotelBooking.Service.RoomService;
using HotelBooking.Utilities.Display.Menu;

namespace HotelBooking.Config
{
    public class ContainerConfig
    {
        public static IContainer BuilderContainer()
        {
            var builder = new ContainerBuilder();

            var dbContextOptions = DBPathConfigurator.GetDbContextOptionsFromConfigJson();
            builder.RegisterInstance(new ApplicationDbContext(dbContextOptions)).As<ApplicationDbContext>();
            //Singelton

            builder.RegisterType<Application>();

            builder.RegisterType<DataInitializer>().AsSelf();
            builder.RegisterType<RoomSeeder>().AsSelf();
            builder.RegisterType<CustomerSeeder>().AsSelf();

            builder.RegisterType<MainHotelMenu>().AsSelf();
            builder.RegisterType<RoomsMenu>().As<IMainMenuAction>();
            builder.RegisterType<CustomersMenu>().As<IMainMenuAction>();
            builder.RegisterType<BookingsMenu>().As<IMainMenuAction>();
            builder.RegisterType<InvoiceMenu>().As<IMainMenuAction>();

            builder.RegisterType<CustomerController>().As<ICustomerController>();
            builder.RegisterType<CustomerCreateController>().As<ICustomerCreaterController>();
            builder.RegisterType<CustomerReadController>().As<ICustomerReadController>();
            builder.RegisterType<CustomerUpdateController>().As<ICustomerUpdateController>();
            builder.RegisterType<CustomerDeleteController>().As<ICustomerDeleteController>();

            builder.RegisterType<RoomController>().As<IRoomController>();
            builder.RegisterType<RoomCreateController>().As<IRoomCreateController>();
            builder.RegisterType<RoomReadController>().As<IRoomReadController>();


            builder.RegisterType<RoomCreate>().AsSelf();
            builder.RegisterType<RoomRead>().AsSelf();

            builder.RegisterType<CustomerCreate>().AsSelf();
            builder.RegisterType<CustomerRead>().AsSelf();
            builder.RegisterType<CustomerUpdate>().AsSelf();
            builder.RegisterType<CustomerDelete>().AsSelf();

            builder.RegisterType<MenuDisplay>().AsSelf();

            return builder.Build();
        }
    }
}
