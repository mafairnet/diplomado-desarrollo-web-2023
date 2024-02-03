using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    [Authorize]
    public class AsignaturaController : Controller
    {
        // GET: Asignatura
        public ActionResult Index()
        {
            return View();
        }

        // GET: Asignatura/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Asignatura/Create
        [HttpPost]
        public ActionResult Add(Asignatura usuario)
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

        // GET: Asignatura/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Asignatura/Edit/5
        [HttpPost]
        public ActionResult Edit(Asignatura usuario)
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

        // GET: Asignatura/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Asignatura/Delete/5
        [HttpPost]
        public ActionResult Delete(Asignatura usuario)
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
