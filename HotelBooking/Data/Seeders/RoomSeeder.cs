using HotelBooking.Models;

namespace HotelBooking.Data.Seeders
{
    public class RoomSeeder
    {
        public void RoomSeeding(ApplicationDbContext dbContext)
        {
            var rooms = new List<Room>
            {
                new Room
                {
                    RoomNumber = 101,
                    RoomSize = 30,
                    TypeOfRooms = TypeOfRoom.Double,
                    PricePerNight = 850,
                    IsAvailable = true,
                    IsExtraBedAvailable = true

                },
                new Room
                {
                    RoomNumber = 102,
                    RoomSize = 20,
                    TypeOfRooms = TypeOfRoom.Singel,
                    PricePerNight = 600,
                    IsAvailable = true,
                    IsExtraBedAvailable = false
                },
                new Room
                {
                    RoomNumber = 201,
                    RoomSize = 25,
                    TypeOfRooms = TypeOfRoom.Singel,
                    PricePerNight = 700,
                    IsAvailable = true,
                    IsExtraBedAvailable = false
                },
                new Room
                {
                    RoomNumber = 202,
                    RoomSize = 22,
                    TypeOfRooms = TypeOfRoom.Double,
                    PricePerNight = 950,
                    IsAvailable = true,
                    IsExtraBedAvailable = true
                },
                 new Room
                {
                    RoomNumber = 301,
                    RoomSize = 35,
                    TypeOfRooms = TypeOfRoom.Double,
                    PricePerNight = 1200,
                    IsAvailable = true,
                    IsExtraBedAvailable = true
                }
            };
            dbContext.Rooms.AddRange(rooms);
            dbContext.SaveChanges();
        }
    }
}
