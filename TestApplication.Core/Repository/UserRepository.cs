using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Core.Data;
using TestApplication.Core.Models;

namespace TestApplication.Core.Repository
{
  public class UserRepository : IUserRepository
  {

    private TestAppDbContext _db;
    public UserRepository(TestAppDbContext db)
    {
      _db = db;
    }
    public User GetSingleUser(int id)
    {
      var user = _db.Users.Single(u => u.Id == id);
      _db.Entry<User>(user).State = EntityState.Detached;
      return user;
    }

    public User EditUser(User user)
    {
     
      _db.Users.Update(user);
      _db.SaveChanges();
      return user;
    }

    public User CreateUser(User user)
    {
      _db.Users.Add(user);
      _db.SaveChanges();
      return user;
    }

    public User DeleteUser(int id)
    {
      var user = GetSingleUser(id);
      _db.Users.Remove(user);
      _db.SaveChanges();
      return user;

    }

    public IEnumerable<User> GetAll()
    {
      var users = _db.Users.OrderBy(u => u.FirstName);
      foreach (var user in users)
      {
        _db.Entry<User>(user).State = EntityState.Detached;
      }
     
      return users;
    }


  }
}
