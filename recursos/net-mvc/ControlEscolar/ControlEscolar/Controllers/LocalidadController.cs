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
    public class LocalidadController : Controller
    {
        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: Localidad
        public ActionResult Index()
        {
            var catalogoLocalidades = new List<Localidad>();
            var catalogoMunicipios = new List<Municipio>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/localidad
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/localidad
                var responseTask = client.GetAsync("Localidad");
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

                    catalogoLocalidades = JsonConvert.DeserializeObject<List<Localidad>>(content.Result, jsonSettings);
                }

            }

            foreach (Localidad localidad in catalogoLocalidades)
            {
                var newMunicipio = new Municipio();
                newMunicipio.Nombre = "No definido";
                localidad.Municipio = newMunicipio;

                foreach (Municipio municipio in catalogoMunicipios)
                {
                    if (localidad.IdMunicipio == municipio.ID)
                    {
                        localidad.Municipio = municipio;
                    }
                }
            }

            ViewData["catalogoLocalidades"] = catalogoLocalidades;

            return View();
        }

        // GET: Localidad/Create
        public ActionResult Add()
        {
            var catalogoMunicipios = new List<Municipio>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/localidad
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

            ViewData["catalogoMunicipios"] = catalogoMunicipios;
            ViewBag.municipios = new SelectList(catalogoMunicipios, "id", "nombre");
            return View();
        }

        // POST: Localidad/Create
        [HttpPost]
        public ActionResult Add(Localidad localidad)
        {
            try
            {
                // TODO: Add insert logic here
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var payload = JsonConvert.SerializeObject(localidad, jsonSettings);

                var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/localidad
                    var responseTask = client.PostAsync("Localidad/", payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();
                        localidad = JsonConvert.DeserializeObject<Localidad>(content.Result, jsonSettings);

                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Localidad/Edit/5
        public ActionResult Edit(int ID)
        {
            var localidad = new Localidad();
            var catalogoMunicipios = new List<Municipio>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/localidad
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/localidad
                var responseTask = client.GetAsync("Localidad/" + ID);
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

                    localidad = JsonConvert.DeserializeObject<Localidad>(content.Result, jsonSettings);
                }
            }

            ViewData["localidad"] = localidad;

            ViewData["catalogoMunicipios"] = catalogoMunicipios;
            ViewBag.municipios = new SelectList(catalogoMunicipios, "id", "nombre");

            return View();
        }

        // POST: Localidad/Edit/5
        [HttpPost]
        public ActionResult Edit(Localidad localidad)
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

                    var payload = JsonConvert.SerializeObject(localidad, jsonSettings);

                    var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");


                    //http://url-api:puerto/localidad
                    var responseTask = client.PutAsync("Localidad/" + localidad.ID, payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();



                        localidad = JsonConvert.DeserializeObject<Localidad>(content.Result, jsonSettings);

                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Localidad/Delete/5
        public ActionResult Delete(int ID)
        {
            var localidad = new Localidad();
            var catalogoMunicipios = new List<Municipio>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/localidad
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/localidad
                var responseTask = client.GetAsync("Localidad/" + ID);
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

                    localidad = JsonConvert.DeserializeObject<Localidad>(content.Result, jsonSettings);
                }
            }

            ViewData["localidad"] = localidad;

            ViewData["catalogoMunicipios"] = catalogoMunicipios;
            ViewBag.municipios = new SelectList(catalogoMunicipios, "id", "nombre");

            return View();
        }

        // POST: Localidad/Delete/5
        [HttpPost]
        public ActionResult Delete(Localidad localidad)
        {
            try
            {
                // TODO: Add delete logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/localidad
                    var responseTask = client.DeleteAsync("Localidad/" + localidad.ID);
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
