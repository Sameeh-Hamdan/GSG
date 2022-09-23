using AutoMapper;
using Practice02.Data.ModelViews.User;
using Practice02.Models;

namespace Practice02.Data.Mappers
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<RegisterUserDTO,User>().ReverseMap();
            CreateMap<RegisterUserResponseDTO,User>().ReverseMap();
            CreateMap<LoginUserDTO,User>().ReverseMap();
            CreateMap<LoginUserResponseDTO,User>().ReverseMap();
            CreateMap<GetUsersDTO,User>().ReverseMap();
        }
    }
}
