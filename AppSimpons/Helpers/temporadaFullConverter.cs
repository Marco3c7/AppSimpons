using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppSimpons.Helpers
{
    public class temporadaFullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = (int)value;
            switch (num)
            {
                case 1:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/FnX2MGS/temporada1full.png"));
                case 2:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/hBqxGBd/temporada2full.png"));
                case 3:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/6bTFfpm/temporada3full.jpg"));
                case 4:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/tDrb0f0/temporada4full.jpg"));
                case 5:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/dfxP49g/temporada5full.jpg"));
                case 6:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/61KPQwF/temporada6full.jpg"));
                case 7:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/0h3V745/temporada7full.jpg"));
                case 8:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/rGYTQSz/temporada8full.jpg"));
                case 9:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/tD60Dnh/temporada9full.jpg"));
                case 10:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/mRMZh1w/temporada10full.jpg"));
                case 11:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/MP4wvwH/temporada11full.jpg"));
                case 12:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/9yHxmx3/temporada12full.jpg"));
                case 13:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/pWdZV1X/temporada13full.png"));
                case 14:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/Tq3pZyW/temporada14full.jpg"));
                case 15:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/FxXGNKq/temporada15full.jpg"));
                case 16:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/Z2TNVsB/temporada16full.jpg"));
                case 17:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/rs8Pyy6/temporada17full.jpg"));
                case 18:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/58FpFyV/temporada18full.png"));
                case 19:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/8X8XZ5j/temporada19full.jpg"));
                case 20:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/ZT4BDtk/temporada20full.jpg"));
                case 21:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/822tjw8/temporada21full.png"));
                case 22:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/mRzWDmQ/temporada22full.jpg"));
                case 23:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/hF7WS2n/temporada23full.jpg"));
                case 24:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/yBtr8CM/temporada24full.png"));
                case 25:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/6wW55MW/temporada25full.jpg"));
                case 26:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/nkP8j3B/temporada26full.jpg"));
                case 27:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/vHDMjFx/temporada27full.jpg"));
                case 28:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/hyvYxZQ/temporada28full.jpg"));
                case 29:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/dcJCChv/temporada29full.jpg"));
                case 30:
                    return ImageSource.FromUri(new Uri("https://i.ibb.co/hDjmHVM/temporada30full.jpg"));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
