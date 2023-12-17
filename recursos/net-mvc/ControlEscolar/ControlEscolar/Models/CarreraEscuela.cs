using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class CarreraEscuela
    {
        #region Atributos
        [JsonProperty("idCarrerra")]
        public int? IdCarrera { get; set; }
        [JsonProperty("idEscuela")]
        public int? IdEscuela { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}