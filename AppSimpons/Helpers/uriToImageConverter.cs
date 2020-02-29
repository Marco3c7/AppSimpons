using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppSimpons.Helpers
{
    public class uriToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = (int)value;
            switch (num)
            {
                case 1:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/S56RBCW/temporada1.jpg"));
                case 2:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/3FWzyBy/temporada2.jpg"));
                case 3:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/4tCVRJB/temporada3.jpg"));
                case 4:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/rsRWp4D/temporada4.jpg"));
                case 5:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/jRr1JYg/temporada5.jpg"));
                case 6:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/fGkrPLT/temporada6.jpg"));
                case 7:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/NL9m7cC/temporada7.jpg"));
                case 8:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/JBKKQwT/temporada8.jpg"));
                case 9:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/zfQ28Zg/temporada9.jpg"));
                case 10:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/XJMSfk7/temporada10.jpg"));
                case 11:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/595kgWF/temporada11.jpg"));
                case 12:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/xjt4pdS/temporada12.jpg"));
                case 13:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/VSCW6yK/temporada13.jpg"));
                case 14:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/4KB8CzB/temporada14.jpg"));
                case 15:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/LtFsj85/temporada15.jpg"));
                case 16:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/ykQb2wM/temporada16.jpg"));
                case 17:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/zP9zKFx/temporada17.jpg"));
                case 18:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/s3g8zdq/temporada18.jpg"));
                case 19:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/sVz48K0/temporada19.jpg"));
                case 20:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/NrRBnLq/temporada20.jpg"));
                case 21:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/kMqsd3L/temporada21.jpg"));
                case 22:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/GfwBSbt/temporada22.jpg"));
                case 23:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/kg51FXR/temporada23.jpg"));
                case 24:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/5MkCLJ5/temporada24.jpg"));
                case 25:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/YfpmQZL/temporada25.jpg"));
                case 26:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/9pjmdzb/temporada26.jpg"));
                case 27:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/x7txDj5/temporada27.jpg"));
                case 28:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/yFwkmBN/temporada28.jpg"));
                case 29:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/dJwBYn3/temporada29.jpg"));
                case 30:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/N3MhQ7k/temporada30.jpg"));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
