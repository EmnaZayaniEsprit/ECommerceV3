using ECommerce.Data.Models;
using ECommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.GUI.Controllers
{
    public class LogInController : Controller
    {
        IUserService userService = null;
       
        public LogInController(IUserService userService)
        {
            this.userService = userService;
            

        }
        //
        // GET: /Login/
        public ActionResult Index()
        {
            String login = Request.Form["login"];
            String password = Request.Form["password"];
            Object usr = userService.AutentificationUser(login, password);
            user user = (user)usr;
           
            

            if (user != null)
            {
                if (Session.IsNewSession) 
                { Session["idUser"] = user.idUser; }
                

                if (user.DTYPE == "Supplier")
                {
                    //return RedirectToAction("Index","Users");
                   return RedirectToAction("supplier");
                }
                else
                    //return RedirectToAction("Index", "Users");
                    return RedirectToAction("customer");
            }
         

            
    
            else return View();
        }

        //
        // GET: /Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Login/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Login/Edit/5
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
        // GET: /Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Login/Delete/5
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
