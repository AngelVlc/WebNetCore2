using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Historicologins
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
