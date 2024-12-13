using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data.Seeders
{
    public class RoomSeeder
    {
        private readonly HotelBookingDbContext _dbContext;

        public RoomSeeder(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RoomSeeding()
        {
            var rooms = new List<Room>
            {
                new Room
                {
                    RoomId = 1,
                    RoomNumber = 101,
                    RoomSize = 30,
                    TypeOfRooms = TypeOfRoom.Double,
                    PricePerNight = 850,
                    IsAvailable = true,
                    IsExtraBedAvailable = true

                },
                new Room
                {
                    RoomId = 2,
                    RoomNumber = 102,
                    RoomSize = 20,
                    TypeOfRooms = TypeOfRoom.Singel,
                    PricePerNight = 600,
                    IsAvailable = true,
                    IsExtraBedAvailable = false
                },
                new Room
                {
                    RoomId = 3,
                    RoomNumber = 201,
                    RoomSize = 25,
                    TypeOfRooms = TypeOfRoom.Singel,
                    PricePerNight = 700,
                    IsAvailable = true,
                    IsExtraBedAvailable = false
                },
                new Room
                {
                    RoomId = 4,
                    RoomNumber = 202,
                    RoomSize = 22,
                    TypeOfRooms = TypeOfRoom.Double,
                    PricePerNight = 950,
                    IsAvailable = true,
                    IsExtraBedAvailable = true
                },
                 new Room
                {
                    RoomId = 5,
                    RoomNumber = 301,
                    RoomSize = 35,
                    TypeOfRooms = TypeOfRoom.Double,
                    PricePerNight = 1200,
                    IsAvailable = true,
                    IsExtraBedAvailable = true
                }
            };
            _dbContext.Rooms.AddRange(rooms);
            _dbContext.SaveChanges();
        }
    }
}
