using ControlEscolar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: Usuario
        public ActionResult Index()
        {
            var catalogoTipoUsuarios = new List<TipoUsuario>();
            var catalogoStatuses = new List<Status>();
            var catalogoUbicaciones = new List<Ubicacion>();
            var catalogoUsuarios = new List<Usuario>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("TipoUsuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoTipoUsuarios = JsonConvert.DeserializeObject<List<TipoUsuario>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Status");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoStatuses = JsonConvert.DeserializeObject<List<Status>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Ubicacion");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoUbicaciones = JsonConvert.DeserializeObject<List<Ubicacion>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Usuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(content.Result, jsonSettings);
                }

            }

            foreach (Usuario usuario in catalogoUsuarios)
            {
                var newTipoUsuario = new TipoUsuario();
                newTipoUsuario.Nombre = "No definido";
                usuario.TipoUsuario = newTipoUsuario;

                foreach (TipoUsuario tipoUsuario in catalogoTipoUsuarios)
                {
                    if (usuario.IdTipoUsuario == tipoUsuario.ID)
                    {
                        usuario.TipoUsuario = tipoUsuario;
                    }
                }

                var newStatus = new Status();
                newStatus.Nombre = "No definido";
                usuario.Status = newStatus;

                foreach (Status status in catalogoStatuses)
                {
                    if (usuario.IdStatus == status.ID)
                    {
                        usuario.Status = status;
                    }
                }

                var newUbicacion = new Ubicacion();
                newUbicacion.Nombre = "No definido";
                usuario.Ubicacion = newUbicacion;

                foreach (Ubicacion ubicacion in catalogoUbicaciones)
                {
                    if (usuario.IdUbicacion == ubicacion.ID)
                    {
                        usuario.Ubicacion = ubicacion;
                    }
                }
            }

            
            ViewData["catalogoUsuarios"] = catalogoUsuarios;
            ViewBag.usuarios = new SelectList(catalogoUsuarios, "id", "nombre");

            return View();
        }

        // GET: Usuario/Create
        public ActionResult Add()
        {

            var catalogoTipoUsuarios = new List<TipoUsuario>();
            var catalogoStatuses = new List<Status>();
            var catalogoUbicaciones = new List<Ubicacion>();
            
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("TipoUsuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoTipoUsuarios = JsonConvert.DeserializeObject<List<TipoUsuario>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Status");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoStatuses = JsonConvert.DeserializeObject<List<Status>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Ubicacion");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoUbicaciones = JsonConvert.DeserializeObject<List<Ubicacion>>(content.Result, jsonSettings);
                }

            }

            var seleccionaStatus = new Status();
            seleccionaStatus.ID = 0;
            seleccionaStatus.Nombre = "Seleccione una opcion";
            catalogoStatuses.Add(seleccionaStatus);

            var seleccionaTipoUsuario = new TipoUsuario();
            seleccionaTipoUsuario.ID = 0;
            seleccionaTipoUsuario.Nombre = "Seleccione una opcion";
            catalogoTipoUsuarios.Add(seleccionaTipoUsuario);

            var seleccionaUbicacion = new Ubicacion();
            seleccionaUbicacion.ID = 0;
            seleccionaUbicacion.Nombre = "Seleccione una opcion";
            catalogoUbicaciones.Add(seleccionaUbicacion);

            ViewData["catalogoTipoUsuarios"] = catalogoTipoUsuarios;
            ViewBag.tipoUsuarios = new SelectList(catalogoTipoUsuarios, "id", "nombre");

            ViewData["catalogoStatuses"] = catalogoStatuses;
            ViewBag.statuses = new SelectList(catalogoStatuses, "id", "nombre");

            ViewData["catalogoUbicaciones"] = catalogoUbicaciones;
            ViewBag.ubicaciones = new SelectList(catalogoUbicaciones, "id", "nombre");


            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Add(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                // TODO: Add insert logic here
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var payload = JsonConvert.SerializeObject(usuario, jsonSettings);

                var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/municipio
                    var responseTask = client.PostAsync("Usuario/", payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();
                        usuario = JsonConvert.DeserializeObject<Usuario>(content.Result, jsonSettings);

                    }

                }

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
            var usuario = new Usuario();
            var catalogoTipoUsuarios = new List<TipoUsuario>();
            var catalogoStatuses = new List<Status>();
            var catalogoUbicaciones = new List<Ubicacion>();

            var seleccionaStatus = new Status();
            seleccionaStatus.ID = 0;
            seleccionaStatus.Nombre = "Seleccione una opcion";
            catalogoStatuses.Add(seleccionaStatus);

            var seleccionaTipoUsuario = new TipoUsuario();
            seleccionaTipoUsuario.ID = 0;
            seleccionaTipoUsuario.Nombre = "Seleccione una opcion";
            catalogoTipoUsuarios.Add(seleccionaTipoUsuario);

            var seleccionaUbicacion = new Ubicacion();
            seleccionaUbicacion.ID = 0;
            seleccionaUbicacion.Nombre = "Seleccione una opcion";
            catalogoUbicaciones.Add(seleccionaUbicacion);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("TipoUsuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoTipoUsuarios = JsonConvert.DeserializeObject<List<TipoUsuario>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Status");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoStatuses = JsonConvert.DeserializeObject<List<Status>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Ubicacion");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoUbicaciones = JsonConvert.DeserializeObject<List<Ubicacion>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Usuario/" + ID);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    usuario = JsonConvert.DeserializeObject<Usuario>(content.Result, jsonSettings);
                }
            }

            ViewData["catalogoTipoUsuarios"] = catalogoTipoUsuarios;
            ViewBag.tipoUsuarios = new SelectList(catalogoTipoUsuarios, "id", "nombre");

            ViewData["catalogoStatuses"] = catalogoStatuses;
            ViewBag.statuses = new SelectList(catalogoStatuses, "id", "nombre");

            ViewData["catalogoUbicaciones"] = catalogoUbicaciones;
            ViewBag.ubicaciones = new SelectList(catalogoUbicaciones, "id", "nombre");


            ViewData["usuario"] = usuario;

            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    var payload = JsonConvert.SerializeObject(usuario, jsonSettings);

                    var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");


                    //http://url-api:puerto/municipio
                    var responseTask = client.PutAsync("Usuario/" + usuario.ID, payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();



                        usuario = JsonConvert.DeserializeObject<Usuario>(content.Result, jsonSettings);

                    }

                }

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
            var usuario = new Usuario();
            var catalogoTipoUsuarios = new List<TipoUsuario>();
            var catalogoStatuses = new List<Status>();
            var catalogoUbicaciones = new List<Ubicacion>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("TipoUsuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoTipoUsuarios = JsonConvert.DeserializeObject<List<TipoUsuario>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Status");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoStatuses = JsonConvert.DeserializeObject<List<Status>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Ubicacion");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    catalogoUbicaciones = JsonConvert.DeserializeObject<List<Ubicacion>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Usuario/" + ID);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    usuario = JsonConvert.DeserializeObject<Usuario>(content.Result, jsonSettings);
                }
            }

            ViewData["catalogoTipoUsuarios"] = catalogoTipoUsuarios;
            ViewBag.tipoUsuarios = new SelectList(catalogoTipoUsuarios, "id", "nombre");

            ViewData["catalogoStatuses"] = catalogoStatuses;
            ViewBag.statuses = new SelectList(catalogoStatuses, "id", "nombre");

            ViewData["catalogoUbicaciones"] = catalogoUbicaciones;
            ViewBag.ubicaciones = new SelectList(catalogoUbicaciones, "id", "nombre");


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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/municipio
                    var responseTask = client.DeleteAsync("Usuario/" + usuario.ID);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
