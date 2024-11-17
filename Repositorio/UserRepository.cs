using NHibernate;
using LoginApp.Models;
using LoginApp.Persistence;
using LoginApp.Interface;

namespace LoginApp.Repositorio
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddUser(User user)
        {
            using (var session = NHibernateHelper.OpenSession(_configuration))
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }

        public User? GetUserByUsername(string username)
        {
            using (var session = NHibernateHelper.OpenSession(_configuration))
            {
                return session.Query<User>().FirstOrDefault(u => u.Username == username);
            }
        }

        public List<User> GetAllUsers()
        {
            using (var session = NHibernateHelper.OpenSession(_configuration))
            {
                return session.Query<User>().ToList();
            }
        }
    }
}
