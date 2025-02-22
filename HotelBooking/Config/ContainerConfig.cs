﻿using Autofac;
using HotelBooking.Controllers;
using HotelBooking.Controllers.ControllerBooking;
using HotelBooking.Controllers.ControllerBooking.Interface;
using HotelBooking.Controllers.ControllerCustomers;
using HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder;
using HotelBooking.Controllers.ControllerCustomers.CustomerUpdateFolder.Interface;
using HotelBooking.Controllers.ControllerCustomers.Interface;
using HotelBooking.Controllers.ControllerInvoice;
using HotelBooking.Controllers.ControllerInvoice.Interfaces;
using HotelBooking.Controllers.ControllerRooms;
using HotelBooking.Controllers.ControllerRooms.Interface;
using HotelBooking.Controllers.ControllerRooms.RoomUpdateFolder;
using HotelBooking.Controllers.ControllerRooms.RoomUpdateFolder.Interface;
using HotelBooking.Controllers.Interfaces;
using HotelBooking.Data;
using HotelBooking.Data.Seeders;
using HotelBooking.Menu.Actions;
using HotelBooking.Menu.StartupMainmenu;
using HotelBooking.Menu.Submenus;
using HotelBooking.Service.BookingService;
using HotelBooking.Service.BookingService.Interfaces;
using HotelBooking.Service.CustomerService;
using HotelBooking.Service.CustomerService.Interfaces;
using HotelBooking.Service.InvoiceService;
using HotelBooking.Service.InvoiceService.Interfaces;
using HotelBooking.Service.RoomService;
using HotelBooking.Service.RoomService.Interfaces;
using HotelBooking.Utilities.Display.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelBooking.Config
{
    public class ContainerConfig
    {
        public static IContainer BuilderContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(context =>
            {
                var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
                return configBuilder.Build();
            }).As<IConfiguration>().SingleInstance();

            builder.Register(context =>
            {
                var config = context.Resolve<IConfiguration>();
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
                return new ApplicationDbContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();

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

            builder.RegisterType<CustomerUpdateCustomer>().As<ICustomerUpdateCustomer>();
            builder.RegisterType<CustomerUpdateRestore>().As<ICustomerUpdateRestore>();

            builder.RegisterType<RoomController>().As<IRoomController>();
            builder.RegisterType<RoomCreateController>().As<IRoomCreateController>();
            builder.RegisterType<RoomReadController>().As<IRoomReadController>();
            builder.RegisterType<RoomUpdateController>().As<IRoomUpdateController>();
            builder.RegisterType<RoomDeleteController>().As<IRoomDeleteController>();

            builder.RegisterType<RoomUpdateRoom>().As<IRoomUpdateRoom>();
            builder.RegisterType<RoomUpdateRestore>().As<IRoomUpdateRestore>();

            builder.RegisterType<BookingController>().As<IBookingController>();
            builder.RegisterType<BookingCreateController>().As<IBookingCreateController>();
            builder.RegisterType<BookingReadController>().As<IBookingReadController>();
            builder.RegisterType<BookingUpdateController>().As<IBookingUpdateController>();
            builder.RegisterType<BookingDeleteController>().As<IBookingDeleteController>();

            builder.RegisterType<InvoiceController>().As<IInvoiceController>();
            builder.RegisterType<InvoiceReadController>().As<IInvoiceReadController>();
            builder.RegisterType<InvoiceUpdateController>().As<IInvoiceUpdateController>();

            builder.RegisterType<BookingCreate>().As<IBookingCreate>();
            builder.RegisterType<BookingRead>().As<IBookingRead>();
            builder.RegisterType<BookingUpdate>().As<IBookingUpdate>();
            builder.RegisterType<BookingDelete>().As<IBookingDelete>();

            builder.RegisterType<RoomCreate>().As<IRoomCreate>();
            builder.RegisterType<RoomRead>().As<IRoomRead>();
            builder.RegisterType<RoomUpdate>().As<IRoomUpdate>();
            builder.RegisterType<RoomDelete>().As<IRoomDelete>();

            builder.RegisterType<CustomerCreate>().As<ICustomerCreate>();
            builder.RegisterType<CustomerRead>().As<ICustomerRead>();
            builder.RegisterType<CustomerUpdate>().As<ICustomerUpdate>();
            builder.RegisterType<CustomerDelete>().As<ICustomerDelete>();

            builder.RegisterType<InvoiceRead>().As<IInvoiceRead>();
            builder.RegisterType<InvoiceUpdate>().As<IInvoiceUpdate>();

            builder.RegisterType<MenuDisplay>().AsSelf();

            return builder.Build();
        }
    }
}
