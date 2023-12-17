using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            return View();
        }

        // GET: Estado/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Estado/Create
        [HttpPost]
        public ActionResult Add(Estado usuario)
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

        // GET: Estado/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Estado/Edit/5
        [HttpPost]
        public ActionResult Edit(Estado usuario)
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

        // GET: Estado/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Estado/Delete/5
        [HttpPost]
        public ActionResult Delete(Estado usuario)
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
