using TestApplication.Core.Models;

namespace TestApplication.Core.Repository
{
  public interface IUserRepository
  {
    User CreateUser(User user);
    User DeleteUser(int id);
    User EditUser(User user);
    IEnumerable<User> GetAll();
    User GetSingleUser(int id);
  }
}