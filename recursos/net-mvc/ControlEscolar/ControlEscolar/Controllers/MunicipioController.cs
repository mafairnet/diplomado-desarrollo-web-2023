using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class MunicipioController : Controller
    {
        // GET: Municipio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Municipio/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Municipio/Create
        [HttpPost]
        public ActionResult Add(Municipio usuario)
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

        // GET: Municipio/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Municipio/Edit/5
        [HttpPost]
        public ActionResult Edit(Municipio usuario)
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

        // GET: Municipio/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Municipio/Delete/5
        [HttpPost]
        public ActionResult Delete(Municipio usuario)
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
