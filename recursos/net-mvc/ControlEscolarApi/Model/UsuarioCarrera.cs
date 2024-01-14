using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class UsuarioCarrera
    {
        #region Atributos
        [Key, Column("id_usuario", Order=0)]
        public int IdUsuario { get; set; }
        [Key, Column("id_carrera", Order = 1)]
        public int IdCarrera { get; set; }
        #endregion
    }
}
