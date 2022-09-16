using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticeProject.DTOs.User;
using PracticeProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProject.Services
{
    public class UserService:IUserService
    {
        private readonly Practice_DBContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(Practice_DBContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User AddUser(UserRegistrationDTO userRegistrationDTO)
        {
            var hashedPass=HashedPassword(userRegistrationDTO.Password);
            userRegistrationDTO.Password=hashedPass;
            userRegistrationDTO.ConfirmPassword = hashedPass;

            var user = _mapper.Map<User>(userRegistrationDTO);
            user = _dbContext.Users.Add(user).Entity;
            _dbContext.SaveChanges();

            return user;
        }
        public User LoginUser(UserLoginDTO userLoginDTO)
        {
            //var user = _mapper.Map<User>(userRegistrationDTO);
            var user = FindByEmail(userLoginDTO.Email);
            if(user != null)
            {
                if (!VerifyHashedPassword(userLoginDTO.Password, user.Password))
                {
                    return null;
                }
                return user;
            }
            return null;
        }
        public User FindByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(usr => usr.Email.ToLower().Equals(email.ToLower()));
            return user;
        }
        private static string HashedPassword(string pass)
            =>  BCrypt.Net.BCrypt.HashPassword(pass);

        private static bool VerifyHashedPassword(string pass, string hashedPass)
            => BCrypt.Net.BCrypt.Verify(pass, hashedPass);

    }
}
