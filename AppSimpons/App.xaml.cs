using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSimpons
{
    public partial class App : Application
    {
        public static AppSimpons.Models.TheSimpson TheSimpson { get; set; } = new AppSimpons.Models.TheSimpson();
        public App()
        {
            InitializeComponent();
            Cargar();
        }

        public async void Cargar()
        {
            await TheSimpson.DescargarTemporadas();
            Device.SetFlags(new string[]
            {
                "CarouselView_Experimental"
            });
            MainPage = new NavigationPage(new MainPage());
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
