using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Core.Models;

namespace TestApplication.Core.Data
{
  public class TestAppDbContext : DbContext
  {

    public TestAppDbContext(DbContextOptions<TestAppDbContext> options)
       : base(options)
    {




    }

    public DbSet<User> Users { get; set; }

    public DbSet<Account> Accounts { get; set; }
  }
}
