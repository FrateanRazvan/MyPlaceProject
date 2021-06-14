using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.ViewModels
{
    public class RoomWithCommentsViewModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomSize { get; set; }
        public bool IsOcupied { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
