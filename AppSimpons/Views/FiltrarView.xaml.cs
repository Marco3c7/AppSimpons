using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSimpons.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FiltrarView : ContentPage
    {
        public FiltrarView()
        {
            InitializeComponent();
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.ReturnCommand.Execute("");
            }
        }

        private void ventana_Disappearing(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
        }
    }
}