using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppSimpons.Models
{
    public class Capitulo : INotifyPropertyChanged
    {
        private string imagen;
        private int minutos;
        private string titulo;

        public string Titulo { get => titulo; set { titulo = value; Actualizar(); } }
        public int Minutos { get => minutos; set { minutos = value; Actualizar(); } }
        public string Imagen { get => imagen; set { imagen = value; Actualizar(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        void Actualizar([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
