using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    [Authorize]
    public class CalificacionCursoUsuarioController : Controller
    {
        // GET: CalificacionCursoUsuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: CalificacionCursoUsuario/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: CalificacionCursoUsuario/Create
        [HttpPost]
        public ActionResult Add(CalificacionCursoUsuario usuario)
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

        // GET: CalificacionCursoUsuario/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: CalificacionCursoUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(CalificacionCursoUsuario usuario)
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

        // GET: CalificacionCursoUsuario/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: CalificacionCursoUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(CalificacionCursoUsuario usuario)
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
