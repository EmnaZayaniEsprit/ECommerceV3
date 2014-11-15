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
    public class ProductRepository : RepositoryBase <product> ,IProductRepository
    {
                public ProductRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
                public void updateProduct(product product)
                {

                    product exiting = this.DataContext.products.Find(product.idProduct);
                    ((IObjectContextAdapter)DataContext).ObjectContext.Detach(exiting);
                    this.DataContext.Entry(product).State = EntityState.Modified;


                }

                public product getProductByID(int idProduct)
                {
                    //DataContext.Dispose();
                   // product exiting = this.DataContext.products.Find(idProduct);
                   // ((IObjectContextAdapter)DataContext).ObjectContext.Detach(exiting);
                    return this.DataContext.products.Find(idProduct);
                }
    }
    public interface IProductRepository : IRepository<product> {

        void updateProduct(product product);
        product getProductByID(int idProduct);
    
    }
}
