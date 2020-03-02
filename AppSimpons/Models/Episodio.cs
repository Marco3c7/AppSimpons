using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppSimpons.Models
{
    public class Episodio
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string NombreOriginal { get; set; }
        public DateTime FechaEmision { get; set; }
        public int Duracion { get; set; }
        public string Sinopsis { get; set; }
        public int NumeroTemporada { get; set; }
        public int NumeroEpisodio { get; set; }

        //private int id;
        //private string imagen;
        //private string nombre;
        //private string nombreOriginal;
        //private DateTime fechaEmision;
        //private int duracion;
        //private string sinopsis;
        //private int numeroTemporada;
        //private int numeroEpisodio;

        //[PrimaryKey]
        //public int Id { get => id; set { id = value; Actualizar(); } }
        //public string Imagen { get => imagen; set { imagen = value; Actualizar(); } }
        //public string Nombre { get => nombre; set { nombre = value; Actualizar(); } }
        //public string NombreOriginal { get => nombreOriginal; set { nombreOriginal = value; Actualizar(); } }
        //public DateTime FechaEmision { get => fechaEmision; set { fechaEmision = value; Actualizar(); } }
        //public int Duracion { get => duracion; set { duracion = value; Actualizar(); } }
        //public string Sinopsis { get => sinopsis; set { sinopsis = value; Actualizar(); } }
        //public int NumeroTemporada { get => numeroTemporada; set { numeroTemporada = value; Actualizar(); } }
        //public int NumeroEpisodio { get => numeroEpisodio; set { numeroEpisodio = value; Actualizar(); } }
    }
}
