using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Framework.Interfaces;

namespace Repositories.UserRepo
{
    public class UserMapper : Profile, IMapperProfile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, User>().ReverseMap();
        }
    }
}
