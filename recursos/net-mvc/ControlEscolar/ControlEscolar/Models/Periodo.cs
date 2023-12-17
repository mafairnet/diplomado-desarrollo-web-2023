﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Periodo
    {
        #region Atributos
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("fechaInicio")]
        public DateTime FechaInicio { get; set; }
        [JsonProperty("fechaFin")]
        public DateTime FechaFin { get; set; }
        [JsonProperty("idStatus")]
        public int IdStatus { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}