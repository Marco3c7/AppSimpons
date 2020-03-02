using AppSimpons.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSimpons
{
    public partial class App : Application
    {
        public static TheSimpson TheSimpson { get; set; } = new TheSimpson();
        public App()
        {
            InitializeComponent();
            Cargar();
        }

        public async void Cargar()
        {
            try
            {
                await TheSimpson.DescargarTemporadas();
                await TheSimpson.DescargarEpisodiosDeTemporada(30);
            Device.SetFlags(new string[]
            {
                "CarouselView_Experimental"
            });
                MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception ex)
            {
                MainPage = new NavigationPage(new MainPage());
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
