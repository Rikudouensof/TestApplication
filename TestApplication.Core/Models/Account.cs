using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Core.Models
{
  public class Account
  {
    [Key]
    public int Id { get; set; }

    [MaxLength(128)]
    public string CompanyName { get; set; }

    [Url]
    public string Website { get; set; }
  }
}
