using System;

namespace PracticeProject.DTOs.User
{
    public class UserRegistrationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
    }
}
