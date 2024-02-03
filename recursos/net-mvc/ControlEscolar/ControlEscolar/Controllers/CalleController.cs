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
    public class CalleController : Controller
    {
        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: Calle
        public ActionResult Index()
        {
            var catalogoCalles = new List<Calle>();
            var catalogoLocalidades = new List<Localidad>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/calle
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/calle
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

            foreach (Calle calle in catalogoCalles)
            {
                var newLocalidad = new Localidad();
                newLocalidad.Nombre = "No definido";
                calle.Localidad = newLocalidad;

                foreach (Localidad localidad in catalogoLocalidades)
                {
                    if (calle.IdLocalidad == localidad.ID)
                    {
                        calle.Localidad = localidad;
                    }
                }
            }

            ViewData["catalogoCalles"] = catalogoCalles;

            return View();
        }

        // GET: Calle/Create
        public ActionResult Add()
        {
            var catalogoLocalidades = new List<Localidad>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/calle
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

            ViewData["catalogoLocalidades"] = catalogoLocalidades;
            ViewBag.localidades = new SelectList(catalogoLocalidades, "id", "nombre");
            return View();
        }

        // POST: Calle/Create
        [HttpPost]
        public ActionResult Add(Calle calle)
        {
            try
            {
                // TODO: Add insert logic here
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var payload = JsonConvert.SerializeObject(calle, jsonSettings);

                var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/calle
                    var responseTask = client.PostAsync("Calle/", payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();
                        calle = JsonConvert.DeserializeObject<Calle>(content.Result, jsonSettings);

                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calle/Edit/5
        public ActionResult Edit(int ID)
        {
            var calle = new Calle();
            var catalogoLocalidades = new List<Localidad>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/calle
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/calle
                var responseTask = client.GetAsync("Calle/" + ID);
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

                    calle = JsonConvert.DeserializeObject<Calle>(content.Result, jsonSettings);
                }
            }

            ViewData["calle"] = calle;

            ViewData["catalogoLocalidades"] = catalogoLocalidades;
            ViewBag.localidades = new SelectList(catalogoLocalidades, "id", "nombre");

            return View();
        }

        // POST: Calle/Edit/5
        [HttpPost]
        public ActionResult Edit(Calle calle)
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

                    var payload = JsonConvert.SerializeObject(calle, jsonSettings);

                    var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");


                    //http://url-api:puerto/calle
                    var responseTask = client.PutAsync("Calle/" + calle.ID, payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();



                        calle = JsonConvert.DeserializeObject<Calle>(content.Result, jsonSettings);

                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calle/Delete/5
        public ActionResult Delete(int ID)
        {
            var calle = new Calle();
            var catalogoLocalidades = new List<Localidad>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/calle
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/calle
                var responseTask = client.GetAsync("Calle/" + ID);
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

                    calle = JsonConvert.DeserializeObject<Calle>(content.Result, jsonSettings);
                }
            }

            ViewData["calle"] = calle;

            ViewData["catalogoLocalidades"] = catalogoLocalidades;
            ViewBag.localidades = new SelectList(catalogoLocalidades, "id", "nombre");

            return View();
        }

        // POST: Calle/Delete/5
        [HttpPost]
        public ActionResult Delete(Calle calle)
        {
            try
            {
                // TODO: Add delete logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/calle
                    var responseTask = client.DeleteAsync("Calle/" + calle.ID);
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
