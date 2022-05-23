using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.API.Task;
using TestApplication.API.ViewModels;
using TestApplication.Core.Models;
using TestApplication.Core.Repository;

namespace TestApplication.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountsController : ControllerBase
  {
    private IAccountRepository _accRepo;
    private IUserRepository _userRepo;

    public AccountsController(IAccountRepository accountService, IUserRepository userService)
    {
      _accRepo = accountService;
      _userRepo = userService;
    }

    [HttpGet("{id}")]
    public ActionResult<DisplayAccount> GetSingle(int id)
    {
      var account = _accRepo.GetSingleAccount(id);
      var users = _userRepo.GetAll();
      var contextUsers = users.Where(m => m.AccountId == id);
      MakeViewModel makeViewModel = new MakeViewModel();


      var viewmodel = makeViewModel.MakeAccountUserViewModel(account, contextUsers);

      return viewmodel;
    }

    [HttpGet]
    public IEnumerable<Account> GetAll()
    {
      IEnumerable<Account> allAccounts = _accRepo.GetAll();

      return allAccounts;


    }

    [HttpPost]
    public ActionResult<Account> AddSingle([FromBody] Account account)
    {
      if (ModelState.IsValid)
      {
        var contextData = _accRepo.CreateAccount(account);
        return 
        Ok(contextData);
      }
      else
      {
        return UnprocessableEntity(ModelState);
      }

    }

    [HttpPut("{id}")]
    public ActionResult<Account> EditAccount(int id, [FromBody] Account account)
    {
      if (id != account.Id)
      {
        return BadRequest();
      }
      var dbaccount = _accRepo.GetSingleAccount(id);
      if (dbaccount is null)
      {
        return NotFound();
      }


      if (ModelState.IsValid)
      {
        
        var editAccount = _accRepo.EditAccount(account);
        return Ok(editAccount);
      }
      else
      {
        return UnprocessableEntity(ModelState);
      }




    }

    [HttpPost("{id}")]
    public ActionResult<Account> DeleteAccount(int id)
    {
      var deleteAccount = _accRepo.GetSingleAccount(id);
      var users = _userRepo.GetAll();
      var contextUser = users.Where(m => m.AccountId == id);
      foreach (var item in contextUser)
      {
        try
        {
          _userRepo.DeleteUser(item.Id);
        }
        catch
        {

        }
      }

      var deletedAccount = _accRepo.DeleteAccount(deleteAccount.Id);

      return Ok(deletedAccount);

    }
























    [HttpGet]
    [Route("{id}/users")]
    public IEnumerable<User> GetAllUser(int id)
    {

      IEnumerable<User> allAccounts = _userRepo.GetAll();
      var users = allAccounts.Where(m => m.AccountId == id);

      return users;


    }



    [HttpGet]
    [Route("{accountid}/users/{id}")]
    public ActionResult<User> GetSingleUser(int accountid,int id)
    {
      var allUsers = _userRepo.GetAll();
      var contextUser = allUsers.Where(m => m.Id == id && m.AccountId == accountid).FirstOrDefault();
      return contextUser;




    }



    [HttpPost]
    [Route("{id}/users")]
    public ActionResult<User> AddSingleUser(int id,  User user)
    {

      var account = _accRepo.GetSingleAccount(id);
      if (account is null)
      {
        return NotFound();
      }

      user.AccountId = id;
      user.Account = account;

      if (ModelState.IsValid)
      {
        var contextData = _userRepo.CreateUser(user);
        return Ok(contextData);

      }
      else
      {
        return UnprocessableEntity(ModelState);
      }

    }




    [HttpDelete]
    [Route("{accountid}/users/{id}")]
    public ActionResult<User> DeleteAccounst(int accountid, int id)
    {
    
      var users = _userRepo.GetAll();
      var contextUser = users.Where(m => m.AccountId == id && m.Id == id).FirstOrDefault();
     
      var deletedAccount = _userRepo.DeleteUser(contextUser.Id);

      return Ok(deletedAccount);

    }




    [HttpPut]
    [Route("{accountid}/users/{id}")]
    public ActionResult<Account> EditUser(int accountid, int id, [FromBody] User user)
    {

      if (id != user.Id || accountid != user.AccountId)
      {
        return BadRequest();
      }
      var dbaccount = _accRepo.GetSingleAccount(accountid);
      var dbuser = _userRepo.GetSingleUser(id);
      if (dbaccount is null || dbuser is null)
      {
        return NotFound();
      }


      if (ModelState.IsValid)
      {
        var editeduser = _userRepo.EditUser(user);
        return Ok(editeduser);
      }
      else
      {
        return UnprocessableEntity(ModelState);
      }




    }

    

  }
}
