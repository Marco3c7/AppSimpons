using AppSimpons.Models;
using AppSimpons.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppSimpons.ViewModels
{
    public class InicioViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Temporada> Temporadas { get; set; } = new ObservableCollection<Temporada>();
        public ObservableCollection<Episodio> Episodios { get; set; } = new ObservableCollection<Episodio>();
        public ObservableCollection<Episodio> EpisodiosFiltrados { get; set; } = new ObservableCollection<Episodio>();

        public TemporadaEpisodios TemporadaEpisodios { get; set; } = new TemporadaEpisodios();
        public Episodio Episodio { get; set; } = new Episodio();

        public Command VerTemporadasCommand { get; set; }
        public Command VerEpisodiosCommand { get; set; }
        public Command<Episodio> VerEpisodioCommand { get; set; }
        public Command<Temporada> VerTemporadaCommand { get; set; }
        public Command AbrirBuscadorCommand { get; set; }
        public Command CancelarCommand { get; set; }
        public Command<string> FiltrarCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        private bool loading;

        public bool Loading
        {
            get { return loading; }
            set { loading = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loading")); }
        }


        public InicioViewModel()
        {
            VerEpisodiosCommand = new Command(VerEpisodios);
            VerEpisodioCommand = new Command<Episodio>(VerEpisodio);
            VerTemporadasCommand = new Command(VerTemporadas);
            VerTemporadaCommand = new Command<Temporada>(VerTemporada);
            CancelarCommand = new Command(Cancelar);
            AbrirBuscadorCommand = new Command(AbrirBuscador);
            FiltrarCommand = new Command<string>(FiltrarEpisodios);
            Temporadas = App.TheSimpson.GetTemporadas();
            Episodios = App.TheSimpson.GetUltimosEpisodios();
        }

        EpisodioView episodioView;
        private async void VerEpisodio(Episodio e)
        {
            if (episodioView == null)
                episodioView = new EpisodioView();

            if (App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 1].GetType() != episodioView.GetType())
            {
                Episodio = e;
                episodioView.BindingContext = null;
                episodioView.BindingContext = this;
                await App.Current.MainPage.Navigation.PushAsync(episodioView);
            }
        }

        EpisodiosView episodiosView;
        private async void VerEpisodios()
        {
            if (episodiosView == null)
                episodiosView = new EpisodiosView();

            if(App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 1].GetType() != episodiosView.GetType())
            {
                episodiosView.BindingContext = this;
                await App.Current.MainPage.Navigation.PushAsync(episodiosView);
            }
        }

        TemporadaView temporadaView;
        private async void VerTemporada(Temporada temporada)
        {
            if (temporadaView == null)
                temporadaView = new TemporadaView();

            if (App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 1].GetType() != temporadaView.GetType())
            {
                Loading = true;
                await App.TheSimpson.DescargarEpisodiosDeTemporada(temporada.Numero);
                TemporadaEpisodios.Temporada = temporada;
                TemporadaEpisodios.Episodios = App.TheSimpson.GetEpisodiosByNumeroTemporada(temporada.Numero);
                temporadaView.BindingContext = this;
                Loading = false;
                await App.Current.MainPage.Navigation.PushAsync(temporadaView);
            }
        }

        private async void Cancelar()
        {
            await App.Current.MainPage.Navigation.PopAsync();
            EpisodiosFiltrados.Clear();
        }

        TemporadasView temporadasView;
        private void VerTemporadas()
        {
            if (temporadasView == null)
                temporadasView = new TemporadasView();

            if (App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 1].GetType() != temporadasView.GetType())
            {
                temporadasView.BindingContext = this;
                App.Current.MainPage.Navigation.PushAsync(temporadasView);
            }
        }

        FiltrarView filtrarView;
        private void AbrirBuscador()
        {
            if (filtrarView == null)
                filtrarView = new FiltrarView();

            filtrarView.BindingContext = this;
            App.Current.MainPage.Navigation.PushAsync(filtrarView);
        }

        private void FiltrarEpisodios(string dato)
        {
            EpisodiosFiltrados.Clear();
            if (!string.IsNullOrWhiteSpace(dato))
            {
                var lista = App.TheSimpson.FiltrarEpisodios(dato);
                lista.ForEach(x => EpisodiosFiltrados.Add(x));
            }
        }
    }
}
