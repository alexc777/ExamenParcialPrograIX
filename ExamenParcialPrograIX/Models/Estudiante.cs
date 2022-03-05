using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcialPrograIX.Models
{
    public class Estudiante
    {
        public int? id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public int edad { get; set; }
        public int carne { get; set; }
        public string facultad { get; set; }
        public string curso { get; set; }
    }
}
