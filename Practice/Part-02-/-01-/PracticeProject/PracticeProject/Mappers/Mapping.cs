using AutoMapper;
using PracticeProject.DTOs.User;
using PracticeProject.Models;

namespace PracticeProject.Mappers
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<UserRegistrationDTO, User>().ReverseMap();
        }
    }
}
