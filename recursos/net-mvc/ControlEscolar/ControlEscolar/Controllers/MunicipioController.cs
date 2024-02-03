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
    public class MunicipioController : Controller
    {
        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: Municipio
        public ActionResult Index()
        {
            var catalogoMunicipios = new List<Municipio>();
            var catalogoEstados = new List<Estado>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Municipio");
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

                    catalogoMunicipios = JsonConvert.DeserializeObject<List<Municipio>>(content.Result, jsonSettings);
                }

            }

            foreach (Municipio municipio in catalogoMunicipios)
            {
                var newEstado = new Estado();
                newEstado.Nombre = "No definido";
                municipio.Estado = newEstado;

                foreach (Estado estado in catalogoEstados)
                {
                    if (municipio.IdEstado == estado.ID)
                    {
                        municipio.Estado = estado;
                    }
                }
            }

            ViewData["catalogoMunicipios"] = catalogoMunicipios;

            return View();
        }

        // GET: Municipio/Create
        public ActionResult Add()
        {
            var catalogoEstados = new List<Estado>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
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

            ViewData["catalogoEstados"] = catalogoEstados;
            ViewBag.estados = new SelectList(catalogoEstados, "id", "nombre");
            return View();
        }

        // POST: Municipio/Create
        [HttpPost]
        public ActionResult Add(Municipio municipio)
        {
            try
            {
                // TODO: Add insert logic here
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var payload = JsonConvert.SerializeObject(municipio, jsonSettings);

                var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/municipio
                    var responseTask = client.PostAsync("Municipio/", payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();
                        municipio = JsonConvert.DeserializeObject<Municipio>(content.Result, jsonSettings);

                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Municipio/Edit/5
        public ActionResult Edit(int ID)
        {
            var municipio = new Municipio();
            var catalogoEstados = new List<Estado>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Municipio/" + ID);
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

                    municipio = JsonConvert.DeserializeObject<Municipio>(content.Result, jsonSettings);
                }
            }

            ViewData["municipio"] = municipio;

            ViewData["catalogoEstados"] = catalogoEstados;
            ViewBag.estadoes = new SelectList(catalogoEstados, "id", "nombre");

            return View();
        }

        // POST: Municipio/Edit/5
        [HttpPost]
        public ActionResult Edit(Municipio municipio)
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

                    var payload = JsonConvert.SerializeObject(municipio, jsonSettings);

                    var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");


                    //http://url-api:puerto/municipio
                    var responseTask = client.PutAsync("Municipio/" + municipio.ID, payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();



                        municipio = JsonConvert.DeserializeObject<Municipio>(content.Result, jsonSettings);

                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Municipio/Delete/5
        public ActionResult Delete(int ID)
        {
            var municipio = new Municipio();
            var catalogoEstados = new List<Estado>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/municipio
                var responseTask = client.GetAsync("Municipio/" + ID);
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

                    municipio = JsonConvert.DeserializeObject<Municipio>(content.Result, jsonSettings);
                }
            }

            ViewData["municipio"] = municipio;

            ViewData["catalogoEstados"] = catalogoEstados;
            ViewBag.estadoes = new SelectList(catalogoEstados, "id", "nombre");

            return View();
        }

        // POST: Municipio/Delete/5
        [HttpPost]
        public ActionResult Delete(Municipio municipio)
        {
            try
            {
                // TODO: Add delete logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/municipio
                    var responseTask = client.DeleteAsync("Municipio/" + municipio.ID);
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
