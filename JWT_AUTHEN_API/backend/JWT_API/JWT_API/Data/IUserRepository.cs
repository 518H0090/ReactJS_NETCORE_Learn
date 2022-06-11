using JWT_API.Models;

namespace JWT_API.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
    }
}
