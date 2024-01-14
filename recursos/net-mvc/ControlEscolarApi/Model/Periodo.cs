using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class Periodo
    {
        #region Atributos
        [Column("id")]
        public int ID { get; set; }
        [Column("nombre")]
        public int Nombre { get; set; }
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }
        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }
        [Column("id_status")]
        public int IdStatus { get; set; }
    #endregion
}
}
