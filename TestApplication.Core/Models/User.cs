using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Core.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }


    [MaxLength(128),Required]
    public string FirstName { get; set; }

    [MaxLength(128)]
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }


    public Account Account { get; set; }

    public int AccountId { get; set; }
  }

  
}
