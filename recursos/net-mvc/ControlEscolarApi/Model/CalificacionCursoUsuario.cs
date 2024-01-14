using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class CalificacionCursoUsuario
    {
        #region Atributos
        [Key, Column("id_usuario", Order=0)]
        public int IdUsuario { get; set; }
        [Key, Column("id_curso", Order = 1)]
        public int IdCurso { get; set; }
        [Key, Column("id_calificacion", Order = 2)]
        public int IdCalificacion { get; set; }
        #endregion
    }
}
