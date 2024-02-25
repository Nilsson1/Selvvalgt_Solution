using System.ComponentModel.DataAnnotations;

namespace Selvvalgt
{
    public class Users
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
