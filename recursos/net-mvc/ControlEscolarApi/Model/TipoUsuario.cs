﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarApi.Model
{
    public class TipoUsuario
    {
        #region Atributos
        [Column("id")]
        public int ID { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        #endregion
    }
}
