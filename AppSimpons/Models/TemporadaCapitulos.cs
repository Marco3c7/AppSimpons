using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppSimpons.Models
{
    public class TemporadaCapitulos
    {
        public Temporada Temporada { get; set; }
        public ObservableCollection<Capitulo> Capitulos { get; set; }
    }
}
