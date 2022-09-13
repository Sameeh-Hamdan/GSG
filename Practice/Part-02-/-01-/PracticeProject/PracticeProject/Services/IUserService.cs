using PracticeProject.DTOs.User;
using PracticeProject.Models;
using System.Collections.Generic;

namespace PracticeProject.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User FindByEmail(string email);
        public User AddUser(UserRegistrationDTO userRegistrationDTO);
    }
}
