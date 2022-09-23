using AutoMapper;
using Practice02.Data.Base;
using Practice02.Models;
namespace Practice02.Data.Services.Users
{
    public class UserService : EntityBaseRepository<User>, IUserService
    {
        public UserService(Practice02DBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

    }
}
