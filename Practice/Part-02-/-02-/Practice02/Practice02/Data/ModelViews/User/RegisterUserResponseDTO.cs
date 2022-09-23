using System.ComponentModel.DataAnnotations;

namespace Practice02.Data.ModelViews.User
{
    public class RegisterUserResponseDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ImageUrl { get; set; } = "avatar.jpg";
        [Required]
        public string Email { get; set; }
    }
}
