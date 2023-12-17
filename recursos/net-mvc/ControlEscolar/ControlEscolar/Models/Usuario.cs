using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Usuario
    {
        #region Atributos
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("numeroIdentificacion")]
        public string NumeroIdentificacion { get; set; }
        [JsonProperty("primerNombre")]
        public string PrimerNombre { get; set; }
        [JsonProperty("segundoNombre")]
        public string SegundoNombre { get; set; }
        [JsonProperty("primerApellido")]
        public string PrimerApellido { get; set; }
        [JsonProperty("segundoApellido")]
        public string SegundoApellido { get; set; }
        [JsonProperty("Correo")]
        public string Correo { get; set; }
        [JsonProperty("NumeroFijo")]
        public long NumeroFijo { get; set; }
        [JsonProperty("NumeroMovil")]
        public long NumeroMovil { get; set; }
        [JsonProperty("idUbicacion")]
        public int IdUbicacion { get; set; }
        [JsonProperty("contrasena")]
        public string Contrasena { get; set; }
        [JsonProperty("idStatus")]
        public int IdStatus { get; set; }
        [JsonProperty("idTipoUsuario")]
        public int IdTipoUsuario { get; set; }
        [JsonProperty("Ubicacion")]
        public Ubicacion Ubicacion{get;set;}
        [JsonProperty("Status")]
        public Status Status { get; set; }
        [JsonProperty("TipoUsuario")]
        public TipoUsuario TipoUsuario { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}