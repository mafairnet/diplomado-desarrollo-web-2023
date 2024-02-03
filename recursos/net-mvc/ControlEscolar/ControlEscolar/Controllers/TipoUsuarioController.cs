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
    public class TipoUsuarioController : Controller
    {
        string apiUrl = WebConfigurationManager.AppSettings["ControlEscolarApiUri"];
        string apiKey = WebConfigurationManager.AppSettings["ControlEscolarApiKey"];

        // GET: TipoUsuario
        public ActionResult Index()
        {
            var catalogoTipoUsuarios = new List<TipoUsuario>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
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

            ViewData["catalogoTipoUsuarios"] = catalogoTipoUsuarios;

            return View();
        }

        // GET: TipoUsuario/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: TipoUsuario/Create
        [HttpPost]
        public ActionResult Add(TipoUsuario tipoUsuario)
        {
            try
            {
                // TODO: Add insert logic here
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var payload = JsonConvert.SerializeObject(tipoUsuario, jsonSettings);

                var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/pais
                    var responseTask = client.PostAsync("TipoUsuario/", payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();
                        tipoUsuario = JsonConvert.DeserializeObject<TipoUsuario>(content.Result, jsonSettings);

                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoUsuario/Edit/5
        public ActionResult Edit(int ID)
        {
            var tipoUsuario = new TipoUsuario();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
                var responseTask = client.GetAsync("TipoUsuario/" + ID);
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

                    tipoUsuario = JsonConvert.DeserializeObject<TipoUsuario>(content.Result, jsonSettings);
                }
            }

            ViewData["tipoUsuario"] = tipoUsuario;

            return View();
        }

        // POST: TipoUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoUsuario tipoUsuario)
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

                    var payload = JsonConvert.SerializeObject(tipoUsuario, jsonSettings);

                    var payloadContent = new StringContent(payload, Encoding.UTF8, "application/json");


                    //http://url-api:puerto/pais
                    var responseTask = client.PutAsync("TipoUsuario/" + tipoUsuario.ID, payloadContent);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync();



                        tipoUsuario = JsonConvert.DeserializeObject<TipoUsuario>(content.Result, jsonSettings);

                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoUsuario/Delete/5
        public ActionResult Delete(int ID)
        {
            var tipoUsuario = new TipoUsuario();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                //http://url-api:puerto/pais
                var responseTask = client.GetAsync("TipoUsuario/" + ID);
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

                    tipoUsuario = JsonConvert.DeserializeObject<TipoUsuario>(content.Result, jsonSettings);
                }
            }

            ViewData["tipoUsuario"] = tipoUsuario;
            return View();
        }

        // POST: TipoUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(TipoUsuario tipoUsuario)
        {
            try
            {
                // TODO: Add delete logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

                    //http://url-api:puerto/pais
                    var responseTask = client.DeleteAsync("TipoUsuario/" + tipoUsuario.ID);
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
