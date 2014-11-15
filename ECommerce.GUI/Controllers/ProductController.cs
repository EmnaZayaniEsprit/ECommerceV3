using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Data.Infrastructure;
using ECommerce.Service;
using System.Configuration;
using ECommerce.Data.Models;

namespace ECommerce.GUI.Controllers
{

    [AllowAnonymous]

    public class ProductController : Controller
    {
        private ecommerceContext db = new ecommerceContext();
        ProduitService service = new ProduitService();

        static IDatabaseFactory dbFact = new DatabaseFactory();
        IUnitOfWork utOfW = new UnitOfWork(dbFact);


        // GET: /Product/
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.category).Include(p => p.promotion).Include(p => p.user);
            ViewBag.Count = utOfW.ProductRepository.GetById(1).pictures.Count(); // the result is 3 and it is true 

            ViewBag.Categories = utOfW.CategoryRepository.GetAll().ToList();

            List<category> categories = utOfW.CategoryRepository.GetAll().ToList();
            ViewData["categories"] = categories;

//************* preparer dans la session un panier vide
            if (Session.IsNewSession)
            {
                List<orderitem> orderitems = new List<orderitem>();
                Session["panier"] = orderitems;
                Session["totalAmount"] = 0.00;

            }
            
//*************

            Session["IDCLIENT"] = 1;

            return View(products.ToList());
        }


        public ActionResult viewMyCart()
        {

            return View();
        }


        public ActionResult addToCart(int idProduit, int quantity)
        {
            // si creer bon de commande 
            List<orderitem> panier = (List<orderitem>)Session["panier"];
            float totalAmount = float.Parse(Session["totalAmount"].ToString());

            orderitem orderItem = new orderitem();

            orderItem.product_idProduct = idProduit;
            // massit ici
            orderItem.product = utOfW.ProductRepository.GetById((long)idProduit);
            //*************
            orderItem.quantity = quantity;
            if (panier.Contains(orderItem))
            {
                panier.Find(o => o.product_idProduct == idProduit).quantity= panier.Find(o => o.product_idProduct == idProduit).quantity+ 1;
            }
            else
            {
                panier.Add(orderItem);

            }
                totalAmount = totalAmount + utOfW.ProductRepository.GetById((long)idProduit).price*quantity;
                Session["panier"] = panier;
                Session["totalAmount"] = totalAmount;
                ViewBag.Count = panier.Count();
                ViewBag.Total = totalAmount;

               // return new EmptyResult();
               return RedirectToAction("Index");
              //  return View();

            //****************************************

        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            if (Session.IsNewSession)
            {
                List<orderitem> orderitems = new List<orderitem>();
                Session["panier"] = orderitems;
            }

            var allProducts = utOfW.ProductRepository.GetAll().ToList();
            // nrajja3 dima les categories
            ViewBag.Categories = utOfW.CategoryRepository.GetAll().ToList();
            try
            {
                var cat = Int32.Parse(collection["catID"]);
                var nameProd = collection["nameProd"];
                var minPriceProd = float.Parse(collection["minPriceProd"]);
                var maxPriceProd = float.Parse(collection["maxPriceProd"]); 
                
   
                var results = service.findproductByAllCriteria(cat,nameProd,minPriceProd,maxPriceProd,false).ToList();

                if (results.Count() != 0)
                {
                    return View(results);

                }
                else
                {

                }
                return RedirectToAction("viewMyCart");

            }
            catch
           {
                return HttpNotFound();
            }
        }



        public ActionResult testMethode(string idUser)
        {

            var products = db.products.Include(p => p.category).Include(p => p.promotion).Include(p => p.user);
            //ViewBag.Count = 0;


            ViewBag.Count = Session["IDCLIENT"];

            List<orderitem> ordersClients = (List<orderitem>)Session["panier"];

            ViewBag.Panier = ordersClients.Count();
              
            return View(products.ToList());
        }

    
        public FileContentResult imageGenerate(int id)
        {
            byte[] image=null;
            if (utOfW.ProductRepository.GetById((long)id).pictures.Count() != 0) 
            {
                ViewBag.Nombre = utOfW.ProductRepository.GetById((long)id).pictures.Count();
                image = utOfW.ProductRepository.GetById((long)id).pictures.ElementAt(0).picture1;

            }
        
        if (image != null)  {
           return new FileContentResult(image, "image/jpg");
        }
             return null;
        }


        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //*******************************Paypaaaaaaaaaaaaaaaaaaaaaaaaaaallll**************************************




        public ActionResult RedirectFromPaypal()
        {
            return View();
        }
        public ActionResult CancelFromPaypal()
        {
            return View();
        }
        public ActionResult NotifyFromPaypal()
        {
            return View();
        }



        public ActionResult ValidateCommand(string product, string totalPrice)
        {
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPalModel(useSandbox);
            paypal.item_name = product;
            paypal.amount = totalPrice;


            var listofOrderItems = Session["panier"] as List<orderitem>;
            float totalAmount = float.Parse(Session["totalAmount"].ToString());


           //********* Order **************
                        
            order myOrder = new order();
            myOrder.customer_idUser = 1;
           // myOrder.deleveryAddress = "Ariana"; // 
            myOrder.orderDate= new DateTime();
            myOrder.paymentMethod = "Paypal";
            myOrder.totalAmount = totalAmount;
            utOfW.OrderRepository.Add(myOrder);
            utOfW.Commit();

            //*******************************

            foreach (var o in listofOrderItems)
            {
                o.order = myOrder;
                utOfW.OrderItemRepository.Add(o);
                utOfW.Commit();
            }


          
            // Vider le panier mel Session
 
            List<orderitem> newOrdedrItems = new List<orderitem>();
            Session["panier"] = newOrdedrItems;
            Session["totalAmount"] = 0.00;
            //*******************************************************


            return View(paypal);
        }

        //**********************************************************************************************
      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
