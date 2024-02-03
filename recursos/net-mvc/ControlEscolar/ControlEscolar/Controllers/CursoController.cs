using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    [Authorize]
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        // GET: Curso/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        public ActionResult Add(Curso usuario)
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

        // GET: Curso/Edit/5
        public ActionResult Edit(int ID)
        {
            
            return View();
        }

        // POST: Curso/Edit/5
        [HttpPost]
        public ActionResult Edit(Curso usuario)
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

        // GET: Curso/Delete/5
        public ActionResult Delete(int ID)
        {
            return View();
        }

        // POST: Curso/Delete/5
        [HttpPost]
        public ActionResult Delete(Curso usuario)
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
