using WordWhisper.Core.Models;

namespace WordWhisper.Web.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
