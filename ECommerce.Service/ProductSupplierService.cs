using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace ECommerce.Service
{
    public class ProductSupplierService : IProductSupplierService
    {

        static DatabaseFactory dbfactory = new DatabaseFactory();
        UnitOfWork utow = new UnitOfWork(dbfactory);
        private ecommerceContext db = new ecommerceContext();
        public FileContentResult Transfer(int idPicture)
        {

           // picture picture = utow.PictureRepository.Get(x => x.idPicture == idPicture);
            //picture picture = utow.PictureRepository.getPictureByID(idPicture);
            picture picture = utow.PictureRepository.GetById(idPicture);
          
            


            byte[] imgbyte = picture.picture1;

            return new FileContentResult(imgbyte, "image/jpg");

        }


        public void addProduct(product p)
        {
            utow.ProductRepository.Add(p);
            utow.Commit();
        }


        public List<product> getAllProducts()
        {
            return utow.ProductRepository.GetAll().ToList();
        }
        public void DeleteProduct(product p)
        {
            utow.ProductRepository.Delete(p);
            utow.Commit();

        }
        public product getProductById(int id)
        {
           return utow.ProductRepository.GetById(id);


        }
        public product getProduct(int id)
        {
            return utow.ProductRepository.Get(x=>x.idProduct==id);

        }
        public void EditProduct(product p)
        {
            utow.ProductRepository.Update(p);
            utow.Commit();

        }


        public void updateProduct(product p)
        {
            utow.ProductRepository.updateProduct(p);
            utow.Commit();

        }
        public product getProductReposotoryById(int idProduct) {

            return utow.ProductRepository.getProductByID(idProduct);

        
        }
        public List<product> getManyProduct(int idUser)
        {
            return utow.ProductRepository.GetMany(p => p.supplier_idUser == idUser).ToList();



        }

        
    }

    public interface IProductSupplierService
    {
        void addProduct(product p);
        FileContentResult Transfer(int idPicture);

        List<product> getAllProducts();
        product getProductById(int id);
        void DeleteProduct(product p);
        void EditProduct(product p);
        product getProduct(int id);
        void updateProduct(product product);
        product getProductReposotoryById(int idProduct);
        List<product> getManyProduct(int idUser);
    }

}
