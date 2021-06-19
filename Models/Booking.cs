using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Rent> rents { get; set; }

    }
}
