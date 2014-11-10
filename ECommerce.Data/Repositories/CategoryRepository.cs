using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
    public class CategoryRepository : RepositoryBase<category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface ICategoryRepository : IRepository<category> { }

}
