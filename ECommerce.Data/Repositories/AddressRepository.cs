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
   public class AddressRepository : RepositoryBase<address>, IAddressRepository
    {	
        public AddressRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
        public void updateAddress(address address) {
            address existing = this.DataContext.addresses.Find(address.idAddress);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(address).State = EntityState.Modified;
        }
       
    }
   public interface IAddressRepository : IRepository<address> { void updateAddress(address address); }
}
