using System;
using System.Collections.Generic;
using System.Text;

namespace AppSimpons.Models
{
    public class Capitulo
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string NombreOriginal { get; set; }
        public DateTime FechaEmision { get; set; }
        public int Duracion { get; set; }
        public string Sinopsis { get; set; }
        public int Temporada { get; set; }
        public int Episodio { get; set; }
    }
}
