using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppSimpons.Models
{
    public class TemporadaEpisodios : INotifyPropertyChanged
    {
        private Temporada temporada;
        private ObservableCollection<Episodio> episodios;

        public Temporada Temporada { get => temporada; set { temporada = value;  Actualizar(); } }
        public ObservableCollection<Episodio> Episodios { get => episodios; set { episodios = value; Actualizar(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        void Actualizar([CallerMemberName] string nombre = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
