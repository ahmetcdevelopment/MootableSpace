using AutoMapper;
using mootableProject.Shared.Entities.Concrete;
using mootableProject.Shared.Entities.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MootableSpace.Web.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
