using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Pais
    {
        #region Atributos
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}