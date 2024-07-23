using System.Data;

namespace FrondCrud.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? RoleId { get; set; }

    }
}
