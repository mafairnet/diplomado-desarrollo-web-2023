using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class UsuarioAsignatura
    {
        #region Atributos
        [JsonProperty("idAsignatura")]
        public int? IdAsignatura { get; set; }
        [JsonProperty("idUsuario")]
        public int? IdUsuario { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}