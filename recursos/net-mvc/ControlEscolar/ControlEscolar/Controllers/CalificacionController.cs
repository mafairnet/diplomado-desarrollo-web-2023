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
    public class CalificacionController : Controller
    {
        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: Calificacion
        public ActionResult Index()
        {
            var catalogoCalificaciones = new List<Calificacion>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
                var responseTask = client.GetAsync("Calificacion");
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

                    catalogoCalificaciones = JsonConvert.DeserializeObject<List<Calificacion>>(content.Result, jsonSettings);
                }

            }

            ViewData["catalogoCalificaciones"] = catalogoCalificaciones;

            return View();
        }

        // GET: Calificacion/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Calificacion/Create
        [HttpPost]
        public ActionResult Add(Calificacion calificacion)
        {
            try
            {
                // TODO: Add insert logic here
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var payload = JsonConvert.SerializeObject(calificacion, jsonSettings);

                var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/pais
                    var responseTask = client.PostAsync("Calificacion/", payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();
                        calificacion = JsonConvert.DeserializeObject<Calificacion>(content.Result, jsonSettings);

                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calificacion/Edit/5
        public ActionResult Edit(int ID)
        {
            var calificacion = new Calificacion();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
                var responseTask = client.GetAsync("Calificacion/" + ID);
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

                    calificacion = JsonConvert.DeserializeObject<Calificacion>(content.Result, jsonSettings);
                }
            }

            ViewData["calificacion"] = calificacion;

            return View();
        }

        // POST: Calificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(Calificacion calificacion)
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

                    var payload = JsonConvert.SerializeObject(calificacion, jsonSettings);

                    var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");


                    //http://url-api:puerto/pais
                    var responseTask = client.PutAsync("Calificacion/" + calificacion.ID, payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();



                        calificacion = JsonConvert.DeserializeObject<Calificacion>(content.Result, jsonSettings);

                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calificacion/Delete/5
        public ActionResult Delete(int ID)
        {
            var calificacion = new Calificacion();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
                var responseTask = client.GetAsync("Calificacion/" + ID);
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

                    calificacion = JsonConvert.DeserializeObject<Calificacion>(content.Result, jsonSettings);
                }
            }

            ViewData["calificacion"] = calificacion;
            return View();
        }

        // POST: Calificacion/Delete/5
        [HttpPost]
        public ActionResult Delete(Calificacion calificacion)
        {
            try
            {
                // TODO: Add delete logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/pais
                    var responseTask = client.DeleteAsync("Calificacion/" + calificacion.ID);
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
