using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class Curso
    {
        #region Atributos
        [Column("id")]
        public int ID { get; set; }
        [Column("nombre")]
        public int Nombre { get; set; }
        [Column("id_periodo")]
        public int IdPeriodo { get; set; }
        [Column("id_asignatura")]
        public int IdAsignatura { get; set; }
        #endregion
    }
}
