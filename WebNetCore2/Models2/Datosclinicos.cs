using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Datosclinicos
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdTipoDatoClinico { get; set; }
        public string Valor { get; set; }

        public Pacientes IdPacienteNavigation { get; set; }
        public Tiposdatosclinicos IdTipoDatoClinicoNavigation { get; set; }
    }
}
