using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class Status
    {
        #region Atributos
        [Column("id")]
        public int ID { get; set; }
        [Column("nombre")]
        public int Nombre { get; set; }
        #endregion
    }
}
