using TestApplication.Core.Models;

namespace TestApplication.Core.Repository
{
  public interface IAccountRepository
  {
    Account CreateAccount(Account account);
    Account DeleteAccount(int id);
    Account EditAccount(Account account);
    IEnumerable<Account> GetAll();
    Account GetSingleAccount(int id);
  }
}