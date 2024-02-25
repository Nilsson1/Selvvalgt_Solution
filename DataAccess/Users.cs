using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Users
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
