using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    [Authorize]
    public class UsuarioCursoController : Controller
    {
        // GET: UsuarioCurso
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioCurso/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: UsuarioCurso/Create
        [HttpPost]
        public ActionResult Add(UsuarioCurso usuario)
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

        // GET: UsuarioCurso/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: UsuarioCurso/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioCurso usuario)
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

        // GET: UsuarioCurso/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: UsuarioCurso/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioCurso usuario)
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
