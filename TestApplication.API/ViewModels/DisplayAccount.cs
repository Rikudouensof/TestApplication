using TestApplication.Core.Models;

namespace TestApplication.API.ViewModels
{
  public class DisplayAccount
  {
    public Account Account { get; set; }

    public IEnumerable<User> Users { get; set; }
  }
}
