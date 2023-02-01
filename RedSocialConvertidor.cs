using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProyectoDefinitivoDINT
{
    class RedSocialConvertidor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Twitter":
                    return "/Recursos/twitter.png";
                case "Facebook":
                    return "/Recursos/facebook.png";
                case "Instragram":
                    return "/Recursos/instagram.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
