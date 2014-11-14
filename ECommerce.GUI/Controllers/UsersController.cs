using ECommerce.Data.Models;
using ECommerce.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.GUI.Controllers
{
    public class UsersController : Controller
    {

        IUserService userService = null;
        IPictureService pictureService = null;
        IAddressService addressService = null;
        public UsersController(IUserService userService, IPictureService pictureService, IAddressService addressService)
        {
            this.userService = userService;
            this.pictureService = pictureService;
            this.addressService = addressService;

        }


        //
        // GET: /Users/
        public ActionResult Index()
        {
            var users = userService.getAllUsers().ToList();
            return View(users);
        }



        //
        // GET: /Users/Details/5
        public ActionResult Details(int id)
        {
            user user = userService.getUser(id);

            return View(user);
        }

        //
        // GET: /Users/Create
        public ActionResult Create()
        {
            //if (Convert.ToInt32(Session["idUser"]) == null)
             return View();

            //else
            //    return RedirectToAction("Index");

        }

        //
        // POST: /Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, user user, HttpPostedFileBase file)
        {


            if (ModelState.IsValid)
            {

                user.DTYPE = Request.Form["Type"].ToString();
                user.sexe = Request.Form["Sexe"].ToString();
                user.blocked = false;
               
                picture picture = new picture();
                picture.description = file.FileName;
                picture.picture1 = ConvertToBytes(file);
               

               Session["Image"] = picture;

                Session["User"] = user;
                return RedirectToAction("CreateStep2");
            }
           

           else

               return View();

        }


        public ActionResult CreateStep2()
        {
            return View();
        }
        public ActionResult ValidateCreate(FormCollection collection,address address)
        {
            user user = Session["User"] as user;
          
            picture picture = Session["Image"] as picture;

            if (ModelState.IsValid)
            {
                gouvernorat gouvernorat1 = new gouvernorat();
                gouvernorat1.gouvernoratName = collection["governorate"];
                address.gouvernorat = gouvernorat1;


                addressService.addAddress(address);
                pictureService.addPicture(picture);
                user.picture = picture;
                user.idPicture = picture.idPicture;
                user.addresses.Add(address);
                userService.addUser(user);
                return RedirectToAction("Index");
            }

            else

                return RedirectToAction("CreateStep2"); 

        }
        public byte[] ConvertToBytes(HttpPostedFileBase img)
        {
            byte[] imagesByte = null;
            BinaryReader reader = new BinaryReader(img.InputStream);
            imagesByte = reader.ReadBytes((int)img.ContentLength);
            return imagesByte;


        }

        //
        // GET: /Users/Edit/5
        public ActionResult Edit(int? id, string DType, char Sexe)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = userService.getUser(id.Value);
            if (user == null)
            { return HttpNotFound(); }

            TempData["DType"] = DType;
            TempData["Sexe"] = Sexe;
            Session.Remove("idUser");
            Session.Add("idUser", id);
            return View(user);



        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        public ActionResult Edit(user user, FormCollection collection/* HttpPostedFileBase file*/)
        {


            //picture picture = new picture();
            //picture.description = file.FileName;
            //picture.picture1 = ConvertToBytes(file);
            //pictureService.addPicture(picture);
            //user.picture = picture;


            //address address1 = new address();

            //address1.city = collection["city"];
            //address1.street = collection["street"];
            //address1.country = collection["country"];
            //address1.number = Convert.ToInt32(collection["number"]);
            //address1.postalCode = Convert.ToInt32(collection["postalCode"]);

            //gouvernorat gouvernorat1 = new gouvernorat();
            //gouvernorat1.gouvernoratName = collection["governorate"];
            //address1.gouvernorat = gouvernorat1;


            //addressService.updateAddress(address1);


            //user.DTYPE = Request.Form["Type"].ToString();
            //user.sexe = Request.Form["Sexe"].ToString();
            //user.blocked = false;

            //    userService.updateUser(userService.getUser(user.idUser));
            //    return RedirectToAction("Index");
            //}
            //return View(user);
            

            if (ModelState.IsValid)
            {


                user.idUser = (int)Session["idUser"];
                Session.Remove("idUser");
                user.DTYPE = Request.Form["Type"].ToString();
                user.sexe = Request.Form["Sexe"].ToString();
                userService.updateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);

        }


        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id)
        {
           
           user user = userService.getUser(id);
            userService.deleteUser(user);
            return RedirectToAction("Index", "Home");
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
