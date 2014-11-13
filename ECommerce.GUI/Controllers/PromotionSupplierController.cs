using ECommerce.Data.Models;
using ECommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.GUI.Controllers
{
    public class PromotionSupplierController : Controller
    {
        IProductSupplierService produitService;
        ICategorySupplierService categoryService;
        IPromotionSupplierService promotionService;
        IUserSupplierService userService;
        public PromotionSupplierController(IProductSupplierService produitService, ICategorySupplierService categoryService, IPromotionSupplierService promotionService, IUserSupplierService userService)
        {
            this.produitService = produitService;
            this.categoryService = categoryService;
            this. userService=userService;
            this.promotionService = promotionService;
        }

        //
        // GET: /PromotionSupplier/
        public ActionResult Index()
        {

            var promotions = promotionService.getAllPromotion().ToList();


            return View(promotions.ToList());
        }

        //
        // GET: /PromotionSupplier/Details/5
        public ActionResult Details(int id)
        {
            var promotion = promotionService.getPromotionById(id);
            var products = produitService.getAllProducts();
            List<product> nvpro = new List<product>();
           
            foreach (product pro in products.ToList())
            {
                if (pro.promotion_idPromotion == id)
                {
                   // products.Remove(pro);
                    nvpro.Add(pro);
                }

            }
            promotion.products = nvpro;
            ViewBag.nvproduit = nvpro;
            
            return View(promotion);
        }

        //
        // GET: /PromotionSupplier/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PromotionSupplier/Create
        [HttpPost]
        public ActionResult Create(promotion promotion,FormCollection collection)
        {
            try
            {
                promotionService.addPromotion(promotion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PromotionSupplier/Edit/5
        public ActionResult Edit(int id)
        {
            promotion promotion = promotionService.getPromotionById(id);

            return View(promotion);
        }

        //
        // POST: /PromotionSupplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, promotion promotion)
        {
           
                promotionService.updatePromotion(promotion);

                

                return RedirectToAction("Index");
            
              
           
        }

        //
        // GET: /PromotionSupplier/Delete/5
        public ActionResult Delete(int id)
        {
            promotionService.deletePromotion(promotionService.getPromotionById(id));

            return RedirectToAction("Index");
        }

        //
        // POST: /PromotionSupplier/Delete/5
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
