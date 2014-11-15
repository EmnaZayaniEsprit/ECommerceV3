using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.GUI.Controllers
{
    public class AddresseController : Controller
    {
        //
        // GET: /Addresse/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Addresse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Addresse/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Addresse/Create
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
        // GET: /Addresse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Addresse/Edit/5
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
        // GET: /Addresse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Addresse/Delete/5
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
