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
  public class AccountRepository : IAccountRepository
  {

    private TestAppDbContext _db;
   
    public AccountRepository(TestAppDbContext db)
    {
      _db = db;
    }

    public Account GetSingleAccount(int id)
    {
      var account = _db.Accounts.Single(u => u.Id == id);
      _db.Entry<Account>(account).State = EntityState.Detached;
      return account;
    }

    public Account EditAccount(Account account)
    {
      _db.Accounts.Update(account);
      _db.SaveChanges();
      return account;
    }

    public Account CreateAccount(Account account)
    {
      _db.Accounts.Add(account);
      _db.SaveChanges();
      return account;
    }

    public Account DeleteAccount(int id)
    {
      var account = GetSingleAccount(id);
      _db.Accounts.Remove(account);
      _db.SaveChanges();
      return account;

    }

    public IEnumerable<Account> GetAll()
    {
      var account = _db.Accounts.OrderBy(u => u.CompanyName);
      return account;
    }
  }
}
