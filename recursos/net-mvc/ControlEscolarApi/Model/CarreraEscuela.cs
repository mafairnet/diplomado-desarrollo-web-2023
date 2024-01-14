using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class CarreraEscuela
    {
        #region Atributos
        [Key, Column("id_carrera", Order=0)]
        public int IdCarrera { get; set; }
        [Key, Column("id_escuela", Order = 1)]
        public int IdEscuela { get; set; }
        #endregion
    }
}
