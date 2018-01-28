using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Clinicas
    {
        public Clinicas()
        {
            Citas = new HashSet<Citas>();
            Pacientes = new HashSet<Pacientes>();
            Tiposdatosclinicos = new HashSet<Tiposdatosclinicos>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cif { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int? CodigoPostal { get; set; }
        public string Email { get; set; }
        public int? TlfFijo { get; set; }
        public int? TlfMovil { get; set; }
        public sbyte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<Citas> Citas { get; set; }
        public ICollection<Pacientes> Pacientes { get; set; }
        public ICollection<Tiposdatosclinicos> Tiposdatosclinicos { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
