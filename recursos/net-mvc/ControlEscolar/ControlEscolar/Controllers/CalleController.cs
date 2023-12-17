using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class CalleController : Controller
    {
        // GET: Calle
        public ActionResult Index()
        {
            return View();
        }

        // GET: Calle/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Calle/Create
        [HttpPost]
        public ActionResult Add(Calle usuario)
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

        // GET: Calle/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Calle/Edit/5
        [HttpPost]
        public ActionResult Edit(Calle usuario)
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

        // GET: Calle/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Calle/Delete/5
        [HttpPost]
        public ActionResult Delete(Calle usuario)
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
