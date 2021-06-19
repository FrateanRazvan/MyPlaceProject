using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Models
{
    public class Rent
    {
        public int ID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public string Name { get; set; }
        public int Max_participants { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }

        public List<Booking> bookings { get; set; }

    }
}
