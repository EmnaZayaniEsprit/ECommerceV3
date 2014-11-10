using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
   public class AddressRepository : RepositoryBase<address>, IAddressRepository
    {	
        public AddressRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
       
    }
    public interface IAddressRepository : IRepository<address> { }
}
