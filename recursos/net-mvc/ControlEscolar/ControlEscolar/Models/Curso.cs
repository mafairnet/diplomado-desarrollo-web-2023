using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Curso
    {
        #region Atributos
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("idPeriodo")]
        public int IdPeriodo { get; set; }
        [JsonProperty("idAsignatura")]
        public int IdAsignatura { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}