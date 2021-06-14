using AutoMapper;
using MyPlace.Models;
using MyPlace.ViewModels;

namespace MyPlace
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<Room, RoomViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Room, RoomWithCommentsViewModel>();
            
        }
    }
}
