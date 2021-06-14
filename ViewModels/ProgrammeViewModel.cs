using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.ViewModels
{
    public class ProgrammeViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string room { get; set; }
        public int max_participants { get; set; }
        public double price { get; set; }
        public DateTime start_programme { get; set; }
        public DateTime end_programme { get; set; }
    }
}
