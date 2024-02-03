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
    public class UbicacionController : Controller
    {
        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: Ubicacion
        public ActionResult Index()
        {
            var catalogoUbicacions = new List<Ubicacion>();
            var catalogoCalles = new List<Calle>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/ubicacion
                var responseTask = client.GetAsync("Calle");
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

                    catalogoCalles = JsonConvert.DeserializeObject<List<Calle>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/ubicacion
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

                    catalogoUbicacions = JsonConvert.DeserializeObject<List<Ubicacion>>(content.Result, jsonSettings);
                }

            }

            foreach (Ubicacion ubicacion in catalogoUbicacions)
            {
                var newCalle = new Calle();
                newCalle.Nombre = "No definido";
                ubicacion.Calle = newCalle;

                foreach (Calle calle in catalogoCalles)
                {
                    if (ubicacion.IdCalle == calle.ID)
                    {
                        ubicacion.Calle = calle;
                    }
                }
            }

            ViewData["catalogoUbicacions"] = catalogoUbicacions;

            return View();
        }

        // GET: Ubicacion/Create
        public ActionResult Add()
        {
            var catalogoCalles = new List<Calle>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/ubicacion
                var responseTask = client.GetAsync("Calle");
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

                    catalogoCalles = JsonConvert.DeserializeObject<List<Calle>>(content.Result, jsonSettings);
                }

            }

            ViewData["catalogoCalles"] = catalogoCalles;
            ViewBag.calles = new SelectList(catalogoCalles, "id", "nombre");
            return View();
        }

        // POST: Ubicacion/Create
        [HttpPost]
        public ActionResult Add(Ubicacion ubicacion)
        {
            try
            {
                // TODO: Add insert logic here
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var payload = JsonConvert.SerializeObject(ubicacion, jsonSettings);

                var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/ubicacion
                    var responseTask = client.PostAsync("Ubicacion/", payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();
                        ubicacion = JsonConvert.DeserializeObject<Ubicacion>(content.Result, jsonSettings);

                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ubicacion/Edit/5
        public ActionResult Edit(int ID)
        {
            var ubicacion = new Ubicacion();
            var catalogoCalles = new List<Calle>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/ubicacion
                var responseTask = client.GetAsync("Calle");
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

                    catalogoCalles = JsonConvert.DeserializeObject<List<Calle>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/ubicacion
                var responseTask = client.GetAsync("Ubicacion/" + ID);
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

                    ubicacion = JsonConvert.DeserializeObject<Ubicacion>(content.Result, jsonSettings);
                }
            }

            ViewData["ubicacion"] = ubicacion;

            ViewData["catalogoCalles"] = catalogoCalles;
            ViewBag.calles = new SelectList(catalogoCalles, "id", "nombre");

            return View();
        }

        // POST: Ubicacion/Edit/5
        [HttpPost]
        public ActionResult Edit(Ubicacion ubicacion)
        {
            try
            {
                // TODO: Add update logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    var payload = JsonConvert.SerializeObject(ubicacion, jsonSettings);

                    var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");


                    //http://url-api:puerto/ubicacion
                    var responseTask = client.PutAsync("Ubicacion/" + ubicacion.ID, payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();



                        ubicacion = JsonConvert.DeserializeObject<Ubicacion>(content.Result, jsonSettings);

                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ubicacion/Delete/5
        public ActionResult Delete(int ID)
        {
            var ubicacion = new Ubicacion();
            var catalogoCalles = new List<Calle>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/ubicacion
                var responseTask = client.GetAsync("Calle");
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

                    catalogoCalles = JsonConvert.DeserializeObject<List<Calle>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/ubicacion
                var responseTask = client.GetAsync("Ubicacion/" + ID);
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

                    ubicacion = JsonConvert.DeserializeObject<Ubicacion>(content.Result, jsonSettings);
                }
            }

            ViewData["ubicacion"] = ubicacion;

            ViewData["catalogoCalles"] = catalogoCalles;
            ViewBag.calles = new SelectList(catalogoCalles, "id", "nombre");

            return View();
        }

        // POST: Ubicacion/Delete/5
        [HttpPost]
        public ActionResult Delete(Ubicacion ubicacion)
        {
            try
            {
                // TODO: Add delete logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/ubicacion
                    var responseTask = client.DeleteAsync("Ubicacion/" + ubicacion.ID);
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
