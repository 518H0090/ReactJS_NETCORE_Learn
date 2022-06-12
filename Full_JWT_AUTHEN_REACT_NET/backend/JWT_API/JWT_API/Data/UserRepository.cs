using JWT_API.Models;

namespace JWT_API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
           _context = context;
        }

        public User Create(User user)
        {
            _context.users.Add(user);
            user.Id = _context.SaveChanges();

            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.users.FirstOrDefault(u => u.Id == id);
        }
    }
}
