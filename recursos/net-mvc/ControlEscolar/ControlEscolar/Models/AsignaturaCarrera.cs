using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class AsignaturaCarrera
    {
        #region Atributos
        [JsonProperty("idAsignatura")]
        public int? IdAsignatura { get; set; }
        [JsonProperty("idCarrera")]
        public int? IdCarrera { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}