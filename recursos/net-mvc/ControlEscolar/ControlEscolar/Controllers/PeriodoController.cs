using ControlEscolar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ControlEscolar.Controllers
{
    [Authorize]
    public class PeriodoController : Controller
    {

        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: Periodo
        public ActionResult Index()
        {
            var catalogoPeriodos = new List<Periodo>();

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
                var responseTask = client.GetAsync("Periodo");
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

                    catalogoPeriodos = JsonConvert.DeserializeObject<List<Periodo>>(content.Result, jsonSettings);
                }

            }

            ViewData["catalogoPeriodos"] = catalogoPeriodos;
            return View();
        }

        // GET: Periodo/Create
        public ActionResult Add()
        {
            
                return View();
        }

        // POST: Periodo/Create
        [HttpPost]
        public ActionResult Add(Periodo periodo)
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

        // GET: Periodo/Edit/5
        public ActionResult Edit(int ID)
        {
            var periodo = new Periodo();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
                var responseTask = client.GetAsync("Periodo/" + ID);
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

                    periodo = JsonConvert.DeserializeObject<Periodo>(content.Result, jsonSettings);
                }
            }

            ViewData["periodo"] = periodo;
            return View();
        }

        // POST: Periodo/Edit/5
        [HttpPost]
        public ActionResult Edit(Periodo periodo)
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

        // GET: Periodo/Delete/5
        public ActionResult Delete(int ID)
        {
            var periodo = new Periodo();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
                var responseTask = client.GetAsync("Periodo/" + ID);
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

                    periodo = JsonConvert.DeserializeObject<Periodo>(content.Result, jsonSettings);
                }
            }

            ViewData["periodo"] = periodo;
            return View();
        }

        // POST: Periodo/Delete/5
        [HttpPost]
        public ActionResult Delete(Periodo periodo)
        {
            try
            {
                // TODO: Add delete logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/pais
                    var responseTask = client.DeleteAsync("Periodo/" + periodo.ID);
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
