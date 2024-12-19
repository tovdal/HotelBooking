using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelBooking.Config
{
    public class DBPathConfigurator
    {
        public static DbContextOptions<ApplicationDbContext> GetDbContextOptionsFromConfigJson()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
            return options.Options;
        }
    }
}
