using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class UsuarioCurso
    {
        #region Atributos
        
        [JsonProperty("idUsuario")]
        public int? IdUsuario { get; set; }
        [JsonProperty("idCurso")]
        public int? IdCurso { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}