using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    [Authorize]
    public class EscuelaController : Controller
    {
        // GET: Escuela
        public ActionResult Index()
        {
            return View();
        }

        // GET: Escuela/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Escuela/Create
        [HttpPost]
        public ActionResult Add(Escuela usuario)
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

        // GET: Escuela/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Escuela/Edit/5
        [HttpPost]
        public ActionResult Edit(Escuela usuario)
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

        // GET: Escuela/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Escuela/Delete/5
        [HttpPost]
        public ActionResult Delete(Escuela usuario)
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
