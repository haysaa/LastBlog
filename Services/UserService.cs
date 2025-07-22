using Blogb.Models;
using Microsoft.EntityFrameworkCore;
using Blogb.Data;

namespace Blogb.Services
{
    public class UserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

        public async Task<LoggedInUser?> LoginAsync(LoginModel model)
        {
            var dbUser = await _context.Users
                            .AsNoTracking()
                            .FirstOrDefaultAsync(u => u.Email == model.Username);
            if (dbUser is not null)
            {
                // Login success
                return new LoggedInUser(dbUser.Id, $"{dbUser.FirstName} {dbUser.LastName}".Trim());
            }
            else
            {
                // Login failed
                return null;
            }
        }
    }
}