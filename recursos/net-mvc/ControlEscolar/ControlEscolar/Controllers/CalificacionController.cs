using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class CalificacionController : Controller
    {
        // GET: Calificacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Calificacion/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Calificacion/Create
        [HttpPost]
        public ActionResult Add(Calificacion usuario)
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

        // GET: Calificacion/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Calificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(Calificacion usuario)
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

        // GET: Calificacion/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Calificacion/Delete/5
        [HttpPost]
        public ActionResult Delete(Calificacion usuario)
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
