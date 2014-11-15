
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
        public static int idUser = 2;
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
            //var products = produitService.getAllProducts().ToList();
            var produits = produitService.getManyProduct(idUser).ToList();
            
            foreach(var  produit in produits){

                if (produit.promotion_idPromotion != null)
                {
                    int idd=produit.promotion_idPromotion.Value;

                    produit.promotion = promotionService.getPromotionRepository(idd);

                }

            }

           // CODE PAR EMNA : RECUPERER ID USER
            //int iduser = Convert.ToInt32(Session["idUser"]);
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
            var product = produitService.getProductReposotoryById(id);
            

            return View(product);
        }

        //
        // GET: /ProductSupplier/Create
        public ActionResult Create()
        {
            var categories = categoryService.getAllCategory();
            var promotions = promotionService.getManyPromotion(idUser);
            var users = userService.getAllUser();
            ViewBag.category_idCategory = new SelectList(categories, "idCategory", "name");
            ViewBag.promotion_idPromotion = new SelectList(promotions, "idPromotion", "nomPromotion");
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
                product.supplier_idUser = idUser;
                produitService.addProduct(product);
               
                
                return RedirectToAction("Index");
            }

            var categories = categoryService.getAllCategory();
            var promotions = promotionService.getAllPromotion();
            var users = userService.getAllUser();
            ViewBag.category_idCategory = new SelectList(categories, "idCategory", "name");
            ViewBag.promotion_idPromotion = new SelectList(promotions, "idPromotion", "nomPromotion");

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
            var product = produitService.getProductById(id);

            var categories = categoryService.getAllCategory();
            var promotions = promotionService.getAllPromotion();
            var users = userService.getAllUser();
            ViewBag.category_idCategory = new SelectList(categories, "idCategory", "name");
            ViewBag.promotion_idPromotion = new SelectList(promotions, "idPromotion", "nomPromotion");
            ViewBag.supplier_idUser = new SelectList(users, "idUser", "DTYPE");




            return View(product);
        }

        //
        // POST: /ProductSupplier/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "idProduct,currency,date,description,name,price,quantity,taxe,category_idCategory,promotion_idPromotion,supplier_idUser")] product product, FormCollection collection, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    produitService.EditProduct(product);


                    return RedirectToAction("Details");

                }
                else
                {
                    picture img = new picture();

                    img.description = image.FileName;

                    img.picture1 = ConvertToBytes(image);
                    product.pictures.Add(img);

                    produitService.EditProduct(product);
                }

                return RedirectToAction("Details");
            }

            var categories = categoryService.getAllCategory();
            var promotions = promotionService.getAllPromotion();
            var users = userService.getAllUser();
            ViewBag.category_idCategory = new SelectList(categories, "idCategory", "name");
            ViewBag.promotion_idPromotion = new SelectList(promotions, "idPromotion", "nomPromotion");

            ViewBag.supplier_idUser = new SelectList(users, "idUser", "DTYPE");
            return RedirectToAction("Edit");
        }

        //
        // GET: /ProductSupplier/Delete/5
        public ActionResult Delete(int id)
        {
            product product = produitService.getProductReposotoryById(id);
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
