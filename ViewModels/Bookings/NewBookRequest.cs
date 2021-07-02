using MyPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.ViewModels.Bookings
{
    public class NewBookRequest
    {
        public string Name { get; set; }
        public Rent Rents { get; set; }
    }
}
