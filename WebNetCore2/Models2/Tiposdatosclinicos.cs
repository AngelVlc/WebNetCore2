using System;
using System.Collections.Generic;

namespace WebNetCore2.Models2
{
    public partial class Tiposdatosclinicos
    {
        public Tiposdatosclinicos()
        {
            Datosclinicos = new HashSet<Datosclinicos>();
        }

        public int Id { get; set; }
        public int IdClinica { get; set; }
        public string NombreTipo { get; set; }
        public string DescripcionTipo { get; set; }

        public Clinicas IdClinicaNavigation { get; set; }
        public ICollection<Datosclinicos> Datosclinicos { get; set; }
    }
}
