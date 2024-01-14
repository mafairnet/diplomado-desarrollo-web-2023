using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class Usuario
    {
        #region Atributos
        [Column("id")]
        public int ID { get; set; }
        [Column("numero_identificacion")]
        public string NumeroIdentificacion { get; set; }
        [Column("primer_nombre")]
        public string PrimerNombre { get; set; }
        [Column("segundo_nombre")]
        public string SegundoNombre { get; set; }
        [Column("primer_apellido")]
        public string PrimerApellido { get; set; }
        [Column("segundo_apellido")]
        public string SegundoApellido { get; set; }
        [Column("correo")]
        public string Correo { get; set; }
        [Column("numero_fijo")]
        public string NumeroFijo { get; set; }
        [Column("numero_movil")]
        public string NumeroMovil { get; set; }
        [Column("contrasena")]
        public string Contrasena { get; set; }
        [Column("id_ubicacion")]
        public int IdUbicacion { get; set; }
        [Column("id_status")]
        public int IdStatus { get; set; }
        [Column("id_tipo_usuario")]
        public int IdTipoUsuario { get; set; }
        #endregion
    }
}
