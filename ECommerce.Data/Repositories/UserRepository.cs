using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
  public  class UserRepository :RepositoryBase<user>,IUserRepository
  {
      public UserRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
  public interface IUserRepository : IRepository<user> { }
}
