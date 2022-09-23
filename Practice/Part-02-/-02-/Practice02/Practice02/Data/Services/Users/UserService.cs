using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practice02.Data.Base;
using Practice02.Data.ModelViews.User;
using Practice02.Models;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Practice02.Data.Services.Users
{
    public class UserService : EntityBaseRepository<User>, IUserService
    {
        private readonly Practice02DBContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(Practice02DBContext dbContext,IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper =mapper;
        }

        public RegisterUserResponseDTO RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var user = FindByEmail(registerUserDTO.Email);
            if(user != null)
            {
                return null;
            }
            var hassedPassword =HashedPassword(registerUserDTO.Password);
            registerUserDTO.Password = hassedPassword;
            registerUserDTO.ConfirmPassword = hassedPassword;


            var newUser = _mapper.Map<User>(registerUserDTO);
            newUser = _dbContext.Users.Add(newUser).Entity;
            _dbContext.SaveChanges();
            return _mapper.Map<RegisterUserResponseDTO>(newUser);
        }

        public LoginUserResponseDTO LoginUser(LoginUserDTO loginUserDTO)
        {
            var user = FindByEmail(loginUserDTO.Email);
            if (user != null)
            {
                if (VerifyHashedPassword(loginUserDTO.Password, user.Password)){
                    var res = _mapper.Map<LoginUserResponseDTO >(user);
                    res.Token = $"Bearer {GenerateJWTToken(user)}";
                    return res;
                }
            }
            return null;
        }

       
        public GetUsersDTO GetUsers()
        {
            return _mapper.Map<GetUsersDTO>(_dbContext.Users);
        }

        #region Private
        private User FindByEmail(string email) 
            => _dbContext.Users.FirstOrDefault(usr => usr.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        private string HashedPassword(string pass)
            => BCrypt.Net.BCrypt.HashPassword(pass);

        private static bool VerifyHashedPassword(string pass, string hashedPass)
            => BCrypt.Net.BCrypt.Verify(pass, hashedPass);

        private static string GenerateJWTToken(User user)
        {
            var jwtKey = "*(^*&(5&%This Is The Story Of How I Died";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

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
            var token = new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion Private
    }
}
