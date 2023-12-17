using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class CarreraController : Controller
    {
        // GET: Carrera
        public ActionResult Index()
        {
            return View();
        }

        // GET: Carrera/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Carrera/Create
        [HttpPost]
        public ActionResult Add(Carrera usuario)
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

        // GET: Carrera/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Carrera/Edit/5
        [HttpPost]
        public ActionResult Edit(Carrera usuario)
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

        // GET: Carrera/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Carrera/Delete/5
        [HttpPost]
        public ActionResult Delete(Carrera usuario)
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
