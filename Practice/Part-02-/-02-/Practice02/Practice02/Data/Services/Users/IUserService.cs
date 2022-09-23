using Practice02.Data.Base;
using Practice02.Data.ModelViews.User;
using Practice02.Models;

namespace Practice02.Data.Services.Users
{
    public interface IUserService : IEntityBaseRepository<User>
    {
        public RegisterUserResponseDTO RegisterUser(RegisterUserDTO registerUserDTO);
        public LoginUserResponseDTO LoginUser(LoginUserDTO loginUserDTO);
        public GetUsersDTO GetUsers();
    }
}
