using Microsoft.AspNetCore.Mvc;
using MyPlace.Data;
using MyPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Services
{
    public class RoomService: IRoomService
    {
        public ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Room> GetAllRoomsByMaxSize(int maxSize)
        {
            return _context.Rooms.Where(r => r.RoomSize <= maxSize).ToList();
        }
    }
}
