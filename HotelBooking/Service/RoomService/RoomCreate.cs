﻿using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Service.RoomService
{
    public class RoomCreate
    {
        private readonly ApplicationDbContext _dbContext;
        public RoomCreate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRoom(Room newRoom)
        {
            _dbContext.Add(newRoom);
            _dbContext.SaveChanges();
        }
        public bool RoomExists(int roomNumber)
        {
            return _dbContext.Rooms
                .Any(room => room.RoomNumber == roomNumber);
        }
    }
}