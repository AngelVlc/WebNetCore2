using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Citas = new HashSet<Citas>();
            Datosclinicos = new HashSet<Datosclinicos>();
            Dolencias = new HashSet<Dolencias>();
        }

        public int Id { get; set; }
        public int IdClinica { get; set; }
        public string NombreApellidos { get; set; }
        public string Dni { get; set; }
        public string Nacionalidad { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int? CodigoPostal { get; set; }
        public string Email { get; set; }
        public int? TlfFijo { get; set; }
        public int? TlfMovil { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Peso { get; set; }
        public string Profesion { get; set; }
        public string ActividadFisica { get; set; }
        public string Diagnostico { get; set; }
        public string TratamientoFisioterapia { get; set; }
        public sbyte? Consentimiento { get; set; }
        public sbyte Estado { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }

        public Clinicas IdClinicaNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Citas> Citas { get; set; }
        public ICollection<Datosclinicos> Datosclinicos { get; set; }
        public ICollection<Dolencias> Dolencias { get; set; }
    }
}
