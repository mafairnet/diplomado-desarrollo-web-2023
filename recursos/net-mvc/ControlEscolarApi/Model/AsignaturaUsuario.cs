using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class AsignaturaUsuario
    {
        #region Atributos
        [Key, Column("id_asignatura", Order = 0)]
        public int IdAsignatura { get; set; }
        [Key, Column("id_usuario", Order = 1)]
        public int IdUsuario { get; set; }
        #endregion
    }
}
