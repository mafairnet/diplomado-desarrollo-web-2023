using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    [Authorize]
    public class UsuarioCarreraController : Controller
    {
        // GET: UsuarioCarrera
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioCarrera/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: UsuarioCarrera/Create
        [HttpPost]
        public ActionResult Add(UsuarioCarrera usuario)
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

        // GET: UsuarioCarrera/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: UsuarioCarrera/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioCarrera usuario)
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

        // GET: UsuarioCarrera/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: UsuarioCarrera/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioCarrera usuario)
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
