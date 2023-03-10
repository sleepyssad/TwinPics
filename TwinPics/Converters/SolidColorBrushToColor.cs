using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace TwinPics.Converters
{
    
    public class SolidColorBrushToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value as SolidColorBrush).Color;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return new SolidColorBrush(value != null ? (Color)value : Colors.Transparent);
        }
    }
}
