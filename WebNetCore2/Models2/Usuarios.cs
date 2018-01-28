using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Citas = new HashSet<Citas>();
            Historicologins = new HashSet<Historicologins>();
            Pacientes = new HashSet<Pacientes>();
            Sesiones = new HashSet<Sesiones>();
        }

        public int Id { get; set; }
        public string NombreApellidos { get; set; }
        public string Password { get; set; }
        public bool? Estado { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public int IdClinica { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Clinicas IdClinicaNavigation { get; set; }
        public ICollection<Citas> Citas { get; set; }
        public ICollection<Historicologins> Historicologins { get; set; }
        public ICollection<Pacientes> Pacientes { get; set; }
        public ICollection<Sesiones> Sesiones { get; set; }
    }
}
