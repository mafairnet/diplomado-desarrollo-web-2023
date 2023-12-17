using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class UsuarioAsignaturaController : Controller
    {
        // GET: UsuarioAsignatura
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioAsignatura/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: UsuarioAsignatura/Create
        [HttpPost]
        public ActionResult Add(UsuarioAsignatura usuario)
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

        // GET: UsuarioAsignatura/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: UsuarioAsignatura/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioAsignatura usuario)
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

        // GET: UsuarioAsignatura/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: UsuarioAsignatura/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioAsignatura usuario)
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
