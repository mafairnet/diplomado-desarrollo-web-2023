using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bitacora/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Bitacora/Create
        [HttpPost]
        public ActionResult Add(Bitacora usuario)
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

        // GET: Bitacora/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Bitacora/Edit/5
        [HttpPost]
        public ActionResult Edit(Bitacora usuario)
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

        // GET: Bitacora/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
        [HttpPost]
        public ActionResult Delete(Bitacora usuario)
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
