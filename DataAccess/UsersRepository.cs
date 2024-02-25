using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UsersRepository
    {
        private readonly DBContext _context;
        public UsersRepository(DBContext context)
        {
            _context = context;
            /*var user = new Users
            {
                Username = "test4",
                Password = "1234",
            };
            context.Users.Add(user);
            context.SaveChanges();*/
        }

        public List<Users> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }
    }
}
