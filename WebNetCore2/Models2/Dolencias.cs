using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Dolencias
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public string DondeDuele { get; set; }
        public string DesdeCuandoDuele { get; set; }
        public string ComoLeDuele { get; set; }
        public int? Intensidad { get; set; }
        public string CuandoDuele { get; set; }
        public string Observaciones { get; set; }
        public int? EscalaDolor { get; set; }
        public int? EscalaAlivio { get; set; }
        public int? ApreciacionDolor { get; set; }
        public int? EscalaDisposicionAnimo { get; set; }

        public Pacientes IdPacienteNavigation { get; set; }
    }
}
