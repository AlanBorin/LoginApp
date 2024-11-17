using LoginApp.Models;

namespace LoginApp.Interface
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUserByUsername( string username);
        List<User> GetAllUsers();
    }
}
