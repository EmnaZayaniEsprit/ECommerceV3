﻿using ECommerce.Data.Infrastructure;
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

        public FileContentResult Transfer(int idPicture)
        {
            //var products = getAllProducts().ToList();
            //product product = products.ToList().ElementAt(9);

           // picture picture = product.pictures.ElementAt(0);

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
        
    }

    public interface IProductSupplierService
    {
        void addProduct(product p);
        FileContentResult Transfer(int idPicture);

        List<product> getAllProducts();
        product getProductById(int id);
        void DeleteProduct(product p);
        product getProduct(int id);
    }

}
