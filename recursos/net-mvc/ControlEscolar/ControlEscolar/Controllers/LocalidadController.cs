using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class LocalidadController : Controller
    {
        // GET: Localidad
        public ActionResult Index()
        {
            return View();
        }

        // GET: Localidad/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Localidad/Create
        [HttpPost]
        public ActionResult Add(Localidad usuario)
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

        // GET: Localidad/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Localidad/Edit/5
        [HttpPost]
        public ActionResult Edit(Localidad usuario)
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

        // GET: Localidad/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Localidad/Delete/5
        [HttpPost]
        public ActionResult Delete(Localidad usuario)
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
