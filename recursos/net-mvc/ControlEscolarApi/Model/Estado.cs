using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class Estado
    {
        #region Atributos
        [Column("id")]
        public int ID { get; set; }
        [Column("nombre")]
        public int Nombre { get; set; }
        [Column("id_pais")]
        public int IdPais { get; set; }
        #endregion
    }
}
