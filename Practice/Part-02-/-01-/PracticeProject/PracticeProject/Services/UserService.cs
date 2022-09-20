using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticeProject.DTOs.User;
using PracticeProject.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

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
        public List<GetUsersDTO> GetUsers() =>
            _mapper.Map<List<GetUsersDTO>>(_dbContext.Users);

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
        public LoginUserResponseDTO LoginUser(UserLoginDTO userLoginDTO)
        {
            var user = FindByEmail(userLoginDTO.Email);
            if(user != null)
            {
                if (!VerifyHashedPassword(userLoginDTO.Password, user.Password))
                {
                    return null;
                }
                var res=_mapper.Map<LoginUserResponseDTO>(user);
                res.Token= $"Bearer {GenerateJWTToken(user)}";
                return res;
            }
            return null;
        }
        public User FindByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(usr => usr.Email.ToLower().Equals(email.ToLower()));
            return user;
        }

        #region private
        private static string HashedPassword(string pass)
            =>  BCrypt.Net.BCrypt.HashPassword(pass);

        private static bool VerifyHashedPassword(string pass, string hashedPass)
            => BCrypt.Net.BCrypt.Verify(pass, hashedPass);

        private static string GenerateJWTToken(User user)
        {
            var jwtKey = "*(^*&(5&%This Is The Story Of How I Died";
            var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials=new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,$"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("Id",user.Id.ToString()),
                new Claim("tech","Sameeh"),
                new Claim("DateOfJoining",user.CreatedAt.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var issuer = "admin.com";
            var token=new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires:DateTime.Now.AddSeconds(30),
                signingCredentials:credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion private
    }
}
