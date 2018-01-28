using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Citas
    {
        public int Id { get; set; }
        public int IdClinica { get; set; }
        public int IdPaciente { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Observaciones { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Clinicas IdClinicaNavigation { get; set; }
        public Pacientes IdPacienteNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
