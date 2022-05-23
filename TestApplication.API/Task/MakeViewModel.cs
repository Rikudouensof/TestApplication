using TestApplication.API.ViewModels;
using TestApplication.Core.Models;

namespace TestApplication.API.Task
{
  public class MakeViewModel
  {

    public DisplayAccount MakeAccountUserViewModel(Account account, IEnumerable<User> users)
    {
      DisplayAccount displayAccount = new DisplayAccount()
      {
        Account = account,
        Users = users
      };
      return displayAccount;
    }
  }
}
