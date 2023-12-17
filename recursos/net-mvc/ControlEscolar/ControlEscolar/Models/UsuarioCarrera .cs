using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class UsuarioCarrera
    {
        #region Atributos
        
        [JsonProperty("idUsuario")]
        public int? IdUsuario { get; set; }
        [JsonProperty("idCarrerra")]
        public int? IdCarrera { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}