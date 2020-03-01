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
        public ObservableCollection<Capitulo> Capitulos { get; set; } = new ObservableCollection<Capitulo>();
        public TemporadaCapitulos TemporadaTemp { get; set; } = new TemporadaCapitulos();

        public Command VerTemporadasCommand { get; set; }
        public Command<Temporada> VerTemporadaCommand { get; set; }
        public Command CancelarCommand { get; set; }

        public InicioViewModel()
        {
            VerTemporadasCommand = new Command(VerTemporadas);
            VerTemporadaCommand = new Command<Temporada>(VerTemporada);
            CancelarCommand = new Command(Cancelar);
            Temporadas = App.TheSimpson.GetTemporadas();
            Capitulos = App.TheSimpson.GetCapitulosRandom();
        }

        TemporadaView temporadaView;
        private async void VerTemporada(Temporada temporada)
        {
            if (temporadaView == null)
            {
                temporadaView = new TemporadaView();
            }
            await App.TheSimpson.DescargarCapitulosDeTemporada(temporada.Numero);
            //TemporadaCapitulos temp = new TemporadaCapitulos()
            //{
            //    Temporada = temporada,
            //    Capitulos = App.TheSimpson.GetCapitulosByTemporada(temporada.Numero)
            //};
            TemporadaTemp.Temporada = temporada;
            TemporadaTemp.Capitulos = App.TheSimpson.GetCapitulosByTemporada(temporada.Numero);
            temporadaView.BindingContext = this;
            await App.Current.MainPage.Navigation.PushAsync(temporadaView);
        }

        private async void Cancelar()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        TemporadasView temporadasView;
        private void VerTemporadas()
        {
            if (temporadasView == null)
                temporadasView = new TemporadasView();
            temporadasView.BindingContext = this;
            App.Current.MainPage.Navigation.PushAsync(temporadasView);
        }
    }
}
