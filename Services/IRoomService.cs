using MyPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Services
{
    public interface IRoomService
    {
        public List<Room> GetAllRoomsByMaxSize(int maxSize);
    }
}
