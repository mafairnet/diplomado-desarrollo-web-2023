using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            return View();
        }

        // GET: Status/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Status/Create
        [HttpPost]
        public ActionResult Add(Status usuario)
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

        // GET: Status/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Status/Edit/5
        [HttpPost]
        public ActionResult Edit(Status usuario)
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

        // GET: Status/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Status/Delete/5
        [HttpPost]
        public ActionResult Delete(Status usuario)
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
