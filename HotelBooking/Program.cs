using HotelBooking.Config;
using Autofac;

namespace HotelBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.BuilderContainer();

            var app = container.Resolve<Application>();
            app.Run();
        }
    }
}
