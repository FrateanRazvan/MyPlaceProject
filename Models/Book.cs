using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int? RentId { get; set; }
        public Rent Rent { get; set; }
    }
}
