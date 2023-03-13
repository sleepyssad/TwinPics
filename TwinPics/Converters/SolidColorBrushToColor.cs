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
            try 
            {
                return value != null ? (value as SolidColorBrush).Color : Colors.Transparent;
            }
            catch
            {
                return Colors.Transparent;
            } 
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return new SolidColorBrush(value != null ? (Color)value : Colors.Transparent);
            }
            catch
            {
                return new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
