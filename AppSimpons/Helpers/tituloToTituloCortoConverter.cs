using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppSimpons.Helpers
{
    public class tituloToTituloCortoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string titulo = value as string;
            if (titulo.Length > 23)
                titulo = $"{titulo.Substring(0, 20)}...";

            return titulo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
