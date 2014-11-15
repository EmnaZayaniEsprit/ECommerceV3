using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

      public void updateUser(user user)
      {
          user existing = this.DataContext.users.Find(user.idUser);
          ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
          this.DataContext.Entry(user).State = EntityState.Modified;
      }

    }
  public interface IUserRepository : IRepository<user> { void updateUser(user user);}
}
