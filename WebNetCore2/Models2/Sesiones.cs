using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Sesiones
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public string Tratamiento { get; set; }
        public decimal Coste { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
