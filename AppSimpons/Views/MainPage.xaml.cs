using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppSimpons
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool flag;
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(8), () =>
            {
                CambiarWallpaper();
                return true;
            });
        }
        uint time = 1500;
        private async void CambiarWallpaper()
        {
            if (flag)
            {
                await wallpaper.FadeTo(0, time, Easing.Linear);
                wallpaper.Source = ImageSource.FromFile("wallpaper.png");
                await wallpaper.FadeTo(1, time, Easing.Linear);


                flag = false;
            }
            else
            {
                await wallpaper.FadeTo(0, time, Easing.Linear);
                wallpaper.Source = ImageSource.FromFile("wallpaper2.png");
                await wallpaper.FadeTo(1, time, Easing.Linear);

                flag = true;
            }
        }
    }
}
