using ControlEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Add()
        {
            var tipoUsuarios = new List<TipoUsuario>();
            var statuses = new List<Status>();
            var ubicaciones = new List<Ubicacion>();

            var tipoUsuario0 = new TipoUsuario();
            tipoUsuario0.ID = 0;
            tipoUsuario0.Nombre = "Seleccione Tipo de Usuario...";

            var tipoUsuario1 = new TipoUsuario();
            tipoUsuario1.ID = 1;
            tipoUsuario1.Nombre = "Alumno";

            var tipoUsuario2 = new TipoUsuario();
            tipoUsuario2.ID = 2;
            tipoUsuario2.Nombre = "Maestro";

            var tipoUsuario3 = new TipoUsuario();
            tipoUsuario3.ID = 3;
            tipoUsuario3.Nombre = "Administrativo";

            tipoUsuarios.Add(tipoUsuario0);
            tipoUsuarios.Add(tipoUsuario1);
            tipoUsuarios.Add(tipoUsuario2);
            tipoUsuarios.Add(tipoUsuario3);

            var status0 = new Status();
            status0.ID = 0;
            status0.Nombre = "Seleccione status...";

            var status1 = new Status();
            status1.ID = 1;
            status1.Nombre = "Activo";

            var status2 = new Status();
            status2.ID = 2;
            status2.Nombre = "Inactivo";

            var status3 = new Status();
            status3.ID = 3;
            status3.Nombre = "Pendiente";

            statuses.Add(status0);
            statuses.Add(status1);
            statuses.Add(status2);
            statuses.Add(status3);

            var ubicacion0 = new Ubicacion();
            ubicacion0.ID = 0;
            ubicacion0.Nombre = "Seleccione Ubicacion...";

            var ubicacion1 = new Ubicacion();
            ubicacion1.ID = 1;
            ubicacion1.Nombre = "Cancun";

            var ubicacion2 = new Ubicacion();
            ubicacion2.ID = 2;
            ubicacion2.Nombre = "CDMX";

            var ubicacion3 = new Ubicacion();
            ubicacion3.ID = 3;
            ubicacion3.Nombre = "Monterrey";

            ubicaciones.Add(ubicacion0);
            ubicaciones.Add(ubicacion1);
            ubicaciones.Add(ubicacion2);
            ubicaciones.Add(ubicacion3);

            ViewData["catalogoTipoUsuarios"] = tipoUsuarios;
            ViewBag.tipoUsuarios = new SelectList(tipoUsuarios, "id", "nombre");

            ViewData["catalogoStatuses"] = statuses;
            ViewBag.statuses = new SelectList(statuses, "id", "nombre");

            ViewData["catalogoUbicaciones"] = ubicaciones;
            ViewBag.ubicaciones = new SelectList(ubicaciones, "id", "nombre");



            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Add(Usuario usuario)
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int ID)
        {
            var tipoUsuarios = new List<TipoUsuario>();
            var statuses = new List<Status>();
            var ubicaciones = new List<Ubicacion>();

            var tipoUsuario0 = new TipoUsuario();
            tipoUsuario0.ID = 0;
            tipoUsuario0.Nombre = "Seleccione Tipo de Usuario...";

            var tipoUsuario1 = new TipoUsuario();
            tipoUsuario1.ID = 1;
            tipoUsuario1.Nombre = "Alumno";

            var tipoUsuario2 = new TipoUsuario();
            tipoUsuario2.ID = 2;
            tipoUsuario2.Nombre = "Maestro";

            var tipoUsuario3 = new TipoUsuario();
            tipoUsuario3.ID = 3;
            tipoUsuario3.Nombre = "Administrativo";

            tipoUsuarios.Add(tipoUsuario0);
            tipoUsuarios.Add(tipoUsuario1);
            tipoUsuarios.Add(tipoUsuario2);
            tipoUsuarios.Add(tipoUsuario3);

            var status0 = new Status();
            status0.ID = 0;
            status0.Nombre = "Seleccione status...";

            var status1 = new Status();
            status1.ID = 1;
            status1.Nombre = "Activo";

            var status2 = new Status();
            status2.ID = 2;
            status2.Nombre = "Inactivo";

            var status3 = new Status();
            status3.ID = 3;
            status3.Nombre = "Pendiente";

            statuses.Add(status0);
            statuses.Add(status1);
            statuses.Add(status2);
            statuses.Add(status3);

            var ubicacion0 = new Ubicacion();
            ubicacion0.ID = 0;
            ubicacion0.Nombre = "Seleccione Ubicacion...";

            var ubicacion1 = new Ubicacion();
            ubicacion1.ID = 1;
            ubicacion1.Nombre = "Cancun";

            var ubicacion2 = new Ubicacion();
            ubicacion2.ID = 2;
            ubicacion2.Nombre = "CDMX";

            var ubicacion3 = new Ubicacion();
            ubicacion3.ID = 3;
            ubicacion3.Nombre = "Monterrey";

            ubicaciones.Add(ubicacion0);
            ubicaciones.Add(ubicacion1);
            ubicaciones.Add(ubicacion2);
            ubicaciones.Add(ubicacion3);

            ViewData["catalogoTipoUsuarios"] = tipoUsuarios;
            ViewBag.tipoUsuarios = new SelectList(tipoUsuarios, "id", "nombre");

            ViewData["catalogoStatuses"] = statuses;
            ViewBag.statuses = new SelectList(statuses, "id", "nombre");

            ViewData["catalogoUbicaciones"] = ubicaciones;
            ViewBag.ubicaciones = new SelectList(ubicaciones, "id", "nombre");

            ViewData["userId"] = ID;

            var usuario = new Usuario();
            if (ID == 1)
            {
                usuario.ID = ID;
                usuario.NumeroIdentificacion = "11111";
                usuario.PrimerNombre = "Miguel";
                usuario.SegundoNombre = "Angel";
                usuario.PrimerApellido = "Torres";
                usuario.SegundoApellido = "Govea";
                usuario.Correo = "miguel@maf.mx";
                usuario.NumeroFijo = 55555555;
                usuario.NumeroMovil = 555555555;
                usuario.IdUbicacion = 1;
                usuario.Contrasena = "P4ssword";
                usuario.IdStatus = 2;
                usuario.IdTipoUsuario = 3;
            }

            if (ID == 2)
            {
                usuario.ID = ID;
                usuario.NumeroIdentificacion = "11111";
                usuario.PrimerNombre = "Dey";
                usuario.SegundoNombre = "Angel";
                usuario.PrimerApellido = "Tello";
                usuario.SegundoApellido = "Govea";
                usuario.Correo = "dey@maf.mx";
                usuario.NumeroFijo = 55555555;
                usuario.NumeroMovil = 555555555;
                usuario.IdUbicacion = 1;
                usuario.Contrasena = "P4ssword";
                usuario.IdStatus = 2;
                usuario.IdTipoUsuario = 3;
            }

            if (ID == 3)
            {
                usuario.ID = ID;
                usuario.NumeroIdentificacion = "11111";
                usuario.PrimerNombre = "Erato";
                usuario.SegundoNombre = "Angel";
                usuario.PrimerApellido = "Rodriguez";
                usuario.SegundoApellido = "Govea";
                usuario.Correo = "erasto@maf.mx";
                usuario.NumeroFijo = 55555555;
                usuario.NumeroMovil = 555555555;
                usuario.IdUbicacion = 1;
                usuario.Contrasena = "P4ssword";
                usuario.IdStatus = 2;
                usuario.IdTipoUsuario = 3;
            }

            ViewData["usuario"] = usuario;

            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int ID)
        {
            var tipoUsuarios = new List<TipoUsuario>();
            var statuses = new List<Status>();
            var ubicaciones = new List<Ubicacion>();

            var tipoUsuario0 = new TipoUsuario();
            tipoUsuario0.ID = 0;
            tipoUsuario0.Nombre = "Seleccione Tipo de Usuario...";

            var tipoUsuario1 = new TipoUsuario();
            tipoUsuario1.ID = 1;
            tipoUsuario1.Nombre = "Alumno";

            var tipoUsuario2 = new TipoUsuario();
            tipoUsuario2.ID = 2;
            tipoUsuario2.Nombre = "Maestro";

            var tipoUsuario3 = new TipoUsuario();
            tipoUsuario3.ID = 3;
            tipoUsuario3.Nombre = "Administrativo";

            tipoUsuarios.Add(tipoUsuario0);
            tipoUsuarios.Add(tipoUsuario1);
            tipoUsuarios.Add(tipoUsuario2);
            tipoUsuarios.Add(tipoUsuario3);

            var status0 = new Status();
            status0.ID = 0;
            status0.Nombre = "Seleccione status...";

            var status1 = new Status();
            status1.ID = 1;
            status1.Nombre = "Activo";

            var status2 = new Status();
            status2.ID = 2;
            status2.Nombre = "Inactivo";

            var status3 = new Status();
            status3.ID = 3;
            status3.Nombre = "Pendiente";

            statuses.Add(status0);
            statuses.Add(status1);
            statuses.Add(status2);
            statuses.Add(status3);

            var ubicacion0 = new Ubicacion();
            ubicacion0.ID = 0;
            ubicacion0.Nombre = "Seleccione Ubicacion...";

            var ubicacion1 = new Ubicacion();
            ubicacion1.ID = 1;
            ubicacion1.Nombre = "Cancun";

            var ubicacion2 = new Ubicacion();
            ubicacion2.ID = 2;
            ubicacion2.Nombre = "CDMX";

            var ubicacion3 = new Ubicacion();
            ubicacion3.ID = 3;
            ubicacion3.Nombre = "Monterrey";

            ubicaciones.Add(ubicacion0);
            ubicaciones.Add(ubicacion1);
            ubicaciones.Add(ubicacion2);
            ubicaciones.Add(ubicacion3);

            ViewData["catalogoTipoUsuarios"] = tipoUsuarios;
            ViewBag.tipoUsuarios = new SelectList(tipoUsuarios, "id", "nombre");

            ViewData["catalogoStatuses"] = statuses;
            ViewBag.statuses = new SelectList(statuses, "id", "nombre");

            ViewData["catalogoUbicaciones"] = ubicaciones;
            ViewBag.ubicaciones = new SelectList(ubicaciones, "id", "nombre");

            ViewData["userId"] = ID;

            var usuario = new Usuario();
            if (ID == 1)
            {
                usuario.ID = ID;
                usuario.NumeroIdentificacion = "11111";
                usuario.PrimerNombre = "Miguel";
                usuario.SegundoNombre = "Angel";
                usuario.PrimerApellido = "Torres";
                usuario.SegundoApellido = "Govea";
                usuario.Correo = "miguel@maf.mx";
                usuario.NumeroFijo = 55555555;
                usuario.NumeroMovil = 555555555;
                usuario.IdUbicacion = 1;
                usuario.Contrasena = "P4ssword";
                usuario.IdStatus = 2;
                usuario.IdTipoUsuario = 3;
            }

            if (ID == 2)
            {
                usuario.ID = ID;
                usuario.NumeroIdentificacion = "11111";
                usuario.PrimerNombre = "Dey";
                usuario.SegundoNombre = "Angel";
                usuario.PrimerApellido = "Tello";
                usuario.SegundoApellido = "Govea";
                usuario.Correo = "dey@maf.mx";
                usuario.NumeroFijo = 55555555;
                usuario.NumeroMovil = 555555555;
                usuario.IdUbicacion = 1;
                usuario.Contrasena = "P4ssword";
                usuario.IdStatus = 2;
                usuario.IdTipoUsuario = 3;
            }

            if (ID == 3)
            {
                usuario.ID = ID;
                usuario.NumeroIdentificacion = "11111";
                usuario.PrimerNombre = "Erato";
                usuario.SegundoNombre = "Angel";
                usuario.PrimerApellido = "Rodriguez";
                usuario.SegundoApellido = "Govea";
                usuario.Correo = "erasto@maf.mx";
                usuario.NumeroFijo = 55555555;
                usuario.NumeroMovil = 555555555;
                usuario.IdUbicacion = 1;
                usuario.Contrasena = "P4ssword";
                usuario.IdStatus = 2;
                usuario.IdTipoUsuario = 3;
            }

            ViewData["usuario"] = usuario;

            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
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
