using AppSimpons.Models;
using AppSimpons.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AppSimpons.ViewModels
{
    public class InicioViewModel
    {
        public ObservableCollection<Temporada> Temporadas { get; set; } = new ObservableCollection<Temporada>();
        public ObservableCollection<Capitulo> Capitulos { get; set; }

        public Command VerTemporadasCommand { get; set; }
        public Command CancelarCommand { get; set; }

        public InicioViewModel()
        {
            VerTemporadasCommand = new Command(VerTemporadas);
            CancelarCommand = new Command(Cancelar);
            Temporadas = App.TheSimpson.GetTemporadas();
            Capitulos = new ObservableCollection<Capitulo>
            {
                new Capitulo
                {
                    Titulo = "No puedes conducir mi auto",
                    Minutos = 22,
                    Imagen = "http://itesrc.net/simpsons/30x05.jpg"
                },
                new Capitulo
                {
                    Titulo = "Desde Rusia sin amor",
                    Minutos = 22,
                    Imagen = "http://itesrc.net/simpsons/30x06.jpg"
                },
                new Capitulo
                {
                    Titulo = "Krusty el payaso",
                    Minutos = 22,
                    Imagen = "http://itesrc.net/simpsons/30x08.jpg"
                },
                new Capitulo
                {
                    Titulo = "Es la temporada 30",
                    Minutos = 22,
                    Imagen = "http://itesrc.net/simpsons/30x10.jpg"
                },
                new Capitulo
                {
                    Titulo = "Mis deportes",
                    Minutos = 22,
                    Imagen = "http://itesrc.net/simpsons/30x17.jpg"
                }
            };
        }

        private async void Cancelar()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        TemporadasView temporadasView;
        private void VerTemporadas()
        {
            if (temporadasView == null)
            {
                temporadasView = new TemporadasView();
            }
            App.Current.MainPage.Navigation.PushAsync(temporadasView);
        }
    }
}
