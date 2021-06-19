using AutoMapper;
using MyPlace.Models;
using MyPlace.ViewModels;
using MyPlace.ViewModels.Rents;

namespace MyPlace
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<Room, RoomViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Room, RoomWithCommentsViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
            CreateMap<Rent, RentsForUserResponse>().ReverseMap();
        }
    }
}
