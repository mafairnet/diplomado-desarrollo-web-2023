using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class CarreraEscuelaController : Controller
    {
        // GET: CarreraEscuela
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarreraEscuela/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: CarreraEscuela/Create
        [HttpPost]
        public ActionResult Add(CarreraEscuela usuario)
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

        // GET: CarreraEscuela/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: CarreraEscuela/Edit/5
        [HttpPost]
        public ActionResult Edit(CarreraEscuela usuario)
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

        // GET: CarreraEscuela/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: CarreraEscuela/Delete/5
        [HttpPost]
        public ActionResult Delete(CarreraEscuela usuario)
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
