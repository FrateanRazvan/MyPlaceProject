using MyPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.ViewModels.Rents
{
    public class RentsForUserResponse
    {
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public List<RoomViewModel> Rooms { get; set; }
        public string Name { get; set; }
        public int Max_participants { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
    }
}
