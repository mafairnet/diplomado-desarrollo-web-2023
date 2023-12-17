using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Escuela
    {
        #region Atributos
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("idUbicacion")]
        public int IdUbicacion { get; set; }
        [JsonProperty("idStatus")]
        public int IdStatus { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}