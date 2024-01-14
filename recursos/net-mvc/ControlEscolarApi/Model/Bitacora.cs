using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class Bitacora
    {
        #region Atributos
        [Column("id")]
        public int ID { get; set; }
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }
        [Column("id_accion")]
        public int IdAccion { get; set; }
        [Column("id_Usuario")]
        public int IdUsuario { get; set; }
        [Column("data")]
        public string Data { get; set; }
        #endregion
    }
}
