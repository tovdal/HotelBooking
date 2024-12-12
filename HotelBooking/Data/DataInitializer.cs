using HotelBooking.Models;
namespace HotelBooking.Data
{
    public class DataInitializer
    {
        private ApplicationDbContext_FAKE _dbContext;

        public ApplicationDbContext_FAKE MigrateAndSeedData()
        {
            _dbContext = new ApplicationDbContext_FAKE();
            _dbContext.Rooms = new List<Room>();
            RoomSeeder();
            GuestSeeder();

            return _dbContext;
        }

        private ApplicationDbContext_FAKE RoomSeeder()
        {
            var room1 = new Room
            {
                RoomId = 1,
                RoomNumber = 101,
                RoomSize = 30,
                TypeOfRooms = TypeOfRoom.Double,
                PricePerNight = 850,
                IsAvailable = true,
                IsExtraBedAvailable = true

            };
            _dbContext.Rooms.Add(room1);

            var room2 = new Room
            {
                RoomId = 2,
                RoomNumber = 102,
                RoomSize = 20,
                TypeOfRooms = TypeOfRoom.Singel,
                PricePerNight = 600,
                IsAvailable = true,
                IsExtraBedAvailable = false
            };
            _dbContext.Rooms.Add(room2);


            var room3 = new Room
            {
                RoomId = 3,
                RoomNumber = 201,
                RoomSize = 25,
                TypeOfRooms = TypeOfRoom.Singel,
                PricePerNight = 700,
                IsAvailable = true,
                IsExtraBedAvailable = false
            };
            _dbContext.Rooms.Add(room3);

            var room4 = new Room
            {
                RoomId = 4,
                RoomNumber = 202,
                RoomSize = 22,
                TypeOfRooms = TypeOfRoom.Double,
                PricePerNight = 950,
                IsAvailable = true,
                IsExtraBedAvailable = true
            };
            _dbContext.Rooms.Add(room4);

            var room5 = new Room
            {
                RoomId = 5,
                RoomNumber = 301,
                RoomSize = 35,
                TypeOfRooms = TypeOfRoom.Double,
                PricePerNight = 1200,
                IsAvailable = true,
                IsExtraBedAvailable = true
            };
            _dbContext.Rooms.Add(room5);
            return _dbContext;
        }

        private ApplicationDbContext_FAKE GuestSeeder()
        {
            return _dbContext;
        }
    }
}
