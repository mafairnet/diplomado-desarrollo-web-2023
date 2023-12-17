using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Bitacora
    {
        #region Atributos
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("idAccion")]
        public int IdAccion { get; set; }
        [JsonProperty("idUsuario")]
        public int IdUsuario { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}