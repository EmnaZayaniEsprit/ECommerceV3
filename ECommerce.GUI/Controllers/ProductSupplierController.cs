﻿
using ECommerce.Data.Models;
using ECommerce.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.GUI.Controllers
{
    public class ProductSupplierController : Controller
    {

        IProductSupplierService produitService;
        ICategorySupplierService categoryService;
        IPromotionSupplierService promotionService;
        IUserSupplierService userService;

        public ProductSupplierController(IProductSupplierService produitService, ICategorySupplierService categoryService, IPromotionSupplierService promotionService, IUserSupplierService userService)
        {
            this.produitService = produitService;
            this.categoryService = categoryService;
            this. userService=userService;
            this.promotionService = promotionService;
        }

        public FileContentResult Transfer(int idPicture)
        {
            return produitService.Transfer(idPicture);
        }


        //
        // GET: /ProductSupplier/
        public ActionResult Index()
        {
            var produits = produitService.getAllProducts().ToList();
            List<int> idImages =new List<int>(); ;
            foreach (var item in produits)
            {
                if (item.pictures.Count>0)
                {

                    int x = (int)item.pictures.ElementAt(0).idPicture;
                     
                    

                    idImages.Add(x);
                }
                else if (item.pictures.Count ==0)
                    idImages.Add(-1);

            }

            ViewBag.idImages = idImages;

            return View(produits.ToList());
        }

        //
        // GET: /ProductSupplier/Details/5
        public ActionResult Details(int id)
        {
            var  product = produitService.getProductById(id);
            var product2 = produitService.getProduct(id);

            return View(product);
        }

        //
        // GET: /ProductSupplier/Create
        public ActionResult Create()
        {
            var categories = categoryService.getAllCategory();
            var promotions = promotionService.getAllPromotion();
            var users = userService.getAllUser();
            ViewBag.category_idCategory = new SelectList(categories, "idCategory", "name");
            ViewBag.promotion_idPromotion = new SelectList(promotions, "idPromotion", "description");
            ViewBag.supplier_idUser = new SelectList(users, "idUser", "DTYPE");

            return View();
        }

        //
        // POST: /ProductSupplier/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "idProduct,currency,date,description,name,price,quantity,taxe,category_idCategory,promotion_idPromotion,supplier_idUser")] product product, FormCollection collection, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                picture img = new picture();

                img.description = image.FileName;

                img.picture1 = ConvertToBytes(image);
                product.pictures.Add(img);

                produitService.addProduct(product);
               
                
                return RedirectToAction("Index");
            }

            var categories = categoryService.getAllCategory();
            var promotions = promotionService.getAllPromotion();
            var users = userService.getAllUser();
            ViewBag.category_idCategory = new SelectList(categories, "idCategory", "name");
            ViewBag.promotion_idPromotion = new SelectList(promotions, "idPromotion", "description");

            ViewBag.supplier_idUser = new SelectList(users, "idUser", "DTYPE");
            return View(product);
        }
        public byte[] ConvertToBytes(HttpPostedFileBase img)
        {
            byte[] imagesByte = null;
           BinaryReader reader = new BinaryReader(img.InputStream);
            imagesByte = reader.ReadBytes((int)img.ContentLength);
            return imagesByte;


        }
        //
        // GET: /ProductSupplier/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();
        }

        //
        // POST: /ProductSupplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ProductSupplier/Delete/5
        public ActionResult Delete(int id)
        {
            product product = produitService.getProductById(id);
            produitService.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        //
        // POST: /ProductSupplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}