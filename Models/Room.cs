using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public double RoomSize { get; set; }
        public bool IsOcupied { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rent> Rents { get; set; }
    }
}
