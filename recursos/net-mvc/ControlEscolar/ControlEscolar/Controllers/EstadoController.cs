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
    public class EstadoController : Controller
    {
        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: Estado
        public ActionResult Index()
        {
            var catalogoEstados = new List<Estado>();
            var catalogoPaises = new List<Pais>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/estado
                var responseTask = client.GetAsync("Pais");
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

                    catalogoPaises = JsonConvert.DeserializeObject<List<Pais>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/estado
                var responseTask = client.GetAsync("Estado");
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

                    catalogoEstados = JsonConvert.DeserializeObject<List<Estado>>(content.Result, jsonSettings);
                }

            }

            foreach (Estado estado in catalogoEstados) {
                var newPais = new Pais();
                newPais.Nombre = "No definido";
                estado.Pais = newPais;

                foreach (Pais pais in catalogoPaises) {
                    if (estado.IdPais == pais.ID) {
                        estado.Pais = pais;
                    }
                }
            }

            ViewData["catalogoEstados"] = catalogoEstados;

            return View();
        }

        // GET: Estado/Create
        public ActionResult Add()
        {
            var catalogoPaises = new List<Pais>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/estado
                var responseTask = client.GetAsync("Pais");
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

                    catalogoPaises = JsonConvert.DeserializeObject<List<Pais>>(content.Result, jsonSettings);
                }

            }

            ViewData["catalogoPaises"] = catalogoPaises;
            ViewBag.paises = new SelectList(catalogoPaises, "id", "nombre");
            return View();
        }

        // POST: Estado/Create
        [HttpPost]
        public ActionResult Add(Estado estado)
        {
            try
            {
                // TODO: Add insert logic here
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var payload = JsonConvert.SerializeObject(estado, jsonSettings);

                var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/estado
                    var responseTask = client.PostAsync("Estado/", payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();
                        estado = JsonConvert.DeserializeObject<Estado>(content.Result, jsonSettings);

                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estado/Edit/5
        public ActionResult Edit(int ID)
        {
            var estado = new Estado();
            var catalogoPaises = new List<Pais>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/estado
                var responseTask = client.GetAsync("Pais");
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

                    catalogoPaises = JsonConvert.DeserializeObject<List<Pais>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/estado
                var responseTask = client.GetAsync("Estado/" + ID);
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

                    estado = JsonConvert.DeserializeObject<Estado>(content.Result, jsonSettings);
                }
            }

            ViewData["estado"] = estado;

            ViewData["catalogoPaises"] = catalogoPaises;
ViewBag.paises = new SelectList(catalogoPaises, "id", "nombre");

            return View();
        }

        // POST: Estado/Edit/5
        [HttpPost]
        public ActionResult Edit(Estado estado)
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

                    var payload = JsonConvert.SerializeObject(estado, jsonSettings);

                    var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");


                    //http://url-api:puerto/estado
                    var responseTask = client.PutAsync("Estado/" + estado.ID, payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();



                        estado = JsonConvert.DeserializeObject<Estado>(content.Result, jsonSettings);

                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estado/Delete/5
        public ActionResult Delete(int ID)
        {
            var estado = new Estado();
            var catalogoPaises = new List<Pais>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/estado
                var responseTask = client.GetAsync("Pais");
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

                    catalogoPaises = JsonConvert.DeserializeObject<List<Pais>>(content.Result, jsonSettings);
                }

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/estado
                var responseTask = client.GetAsync("Estado/" + ID);
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

                    estado = JsonConvert.DeserializeObject<Estado>(content.Result, jsonSettings);
                }
            }

            ViewData["estado"] = estado;

            ViewData["catalogoPaises"] = catalogoPaises;
            ViewBag.paises = new SelectList(catalogoPaises, "id", "nombre");

            return View();
        }

        // POST: Estado/Delete/5
        [HttpPost]
        public ActionResult Delete(Estado estado)
        {
            try
            {
                // TODO: Add delete logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/estado
                    var responseTask = client.DeleteAsync("Estado/" + estado.ID);
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
