using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class PeriodoController : Controller
    {
        // GET: Periodo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Periodo/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Periodo/Create
        [HttpPost]
        public ActionResult Add(Periodo usuario)
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

        // GET: Periodo/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Periodo/Edit/5
        [HttpPost]
        public ActionResult Edit(Periodo usuario)
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

        // GET: Periodo/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Periodo/Delete/5
        [HttpPost]
        public ActionResult Delete(Periodo usuario)
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
