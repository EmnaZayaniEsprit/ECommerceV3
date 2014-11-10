using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class ProductService : IProductService
    {
        static DatabaseFactory dbfactory = new DatabaseFactory();
        UnitOfWork utow = new UnitOfWork(dbfactory);
        public void addProduct(product p)
        {
            utow.ProductRepository.Add(p);
            utow.Commit();
        }


        public List<product> getAllProduct()
        {
            return utow.ProductRepository.GetAll().ToList();
        }
    }
    public interface IProductService
    {
        void addProduct(product p);

         List<product> getAllProduct();
    }
    
}
