using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class UsuarioCurso
    {
        #region Atributos
        [Key, Column("id_usuario", Order=0)]
        public int IdUsuario { get; set; }
        [Key, Column("id_curso", Order = 1)]
        public int IdCurso { get; set; }
        #endregion
    }
}
