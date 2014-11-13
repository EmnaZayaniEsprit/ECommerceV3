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
            return View();
        }

        //
        // GET: /Users/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["idUser"]) == null)
                return View();

            else
                return RedirectToAction("Index");

        }

        //
        // POST: /Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, user user, HttpPostedFileBase file)
        {


            if (ModelState.IsValid)
            {

                picture picture = new picture();
                picture.description = file.FileName;
                picture.picture1 = ConvertToBytes(file);
                pictureService.addPicture(picture);
                user.picture = picture;


                address address1 = new address();
                address1.city = collection["city"];
                address1.street = collection["street"];
                address1.country = collection["country"];
                address1.number = Convert.ToInt32(collection["number"]);
                address1.postalCode = Convert.ToInt32(collection["postalCode"]);

                gouvernorat gouvernorat1 = new gouvernorat();
                gouvernorat1.gouvernoratName = collection["governorate"];
                address1.gouvernorat = gouvernorat1;


                user.addresses.Add(address1);

                user.DTYPE = Request.Form["Type"].ToString();
                user.sexe = Request.Form["Sexe"].ToString();
                user.blocked = false;

                userService.addUser(user);
                return RedirectToAction("Index");
            }


            else

                return View();

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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = userService.getUser(id.Value);
            if (user == null)
            { return HttpNotFound(); }

            Session.Remove("idUser");
            Session.Add("idUser", id);
            return View(user);



        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        public ActionResult Edit(user user/*FormCollection collection, HttpPostedFileBase file*/)
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
                userService.updateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);

        }


        //
        // GET: /Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //user user = service.getUser(id);
                //service.deleteUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
