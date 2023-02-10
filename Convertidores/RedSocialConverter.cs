using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProyectoDefinitivoDINT.Convertidores
{
    class RedSocialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Twitter":
                    return "/Recursos/twitter.jpg";
                case "Instagram":
                    return "/Recursos/instagram.jpg";
                case "Facebook":
                    return "/Recursos/facebook.png";
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
