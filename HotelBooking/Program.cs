using HotelBooking.Config;
using Autofac;
using Microsoft.Extensions.Configuration;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);


            var container = ContainerConfig.BuilderContainer();

            var app = container.Resolve<Application>();
            app.Run();
        }
    }
}
