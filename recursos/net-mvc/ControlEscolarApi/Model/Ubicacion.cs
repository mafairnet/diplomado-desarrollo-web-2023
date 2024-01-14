using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class Ubicacion
    {
        #region Atributos
        [Column("id")]
        public int ID { get; set; }
        [Column("nombre")]
        public int Nombre { get; set; }
        [Column("numero_exterior")]
        public string NumeroExterior { get; set; }
        [Column("numero_interior")]
        public string NumeroInterior { get; set; }
        [Column("codigo_postal")]
        public string CodigoPostal { get; set; }
        [Column("id_calle")]
        public int IdCalle { get; set; }
    #endregion
}
}
