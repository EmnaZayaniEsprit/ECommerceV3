using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
   public class ReclamationRepository :RepositoryBase<reclamation>,IReclamationRepository

    {
               public ReclamationRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
   public interface IReclamationRepository : IRepository<reclamation> { }
}
