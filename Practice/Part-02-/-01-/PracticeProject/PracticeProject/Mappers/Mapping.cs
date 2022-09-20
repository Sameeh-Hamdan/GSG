using AutoMapper;
using PracticeProject.DTOs.Item;
using PracticeProject.DTOs.User;
using PracticeProject.Models;

namespace PracticeProject.Mappers
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<UserRegistrationDTO, User>().ReverseMap();
            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<LoginUserResponseDTO, User>().ReverseMap();
            CreateMap<GetUsersDTO, User>().ReverseMap();
            CreateMap<DetailsOfItemDTO, DetailsOfItem>().ReverseMap();
            
        }
    }
}
