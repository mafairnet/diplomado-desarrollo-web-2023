using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class UbicacionController : Controller
    {
        // GET: Ubicacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ubicacion/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Ubicacion/Create
        [HttpPost]
        public ActionResult Add(Ubicacion usuario)
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

        // GET: Ubicacion/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Ubicacion/Edit/5
        [HttpPost]
        public ActionResult Edit(Ubicacion usuario)
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

        // GET: Ubicacion/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Ubicacion/Delete/5
        [HttpPost]
        public ActionResult Delete(Ubicacion usuario)
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
