using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace TwinPics.Resources
{
    public static class ThemeManager
    {
        public static void UpdateTheme(ApplicationTheme theme)
        {
            try
            {
                var resourceSource = new Uri($"ms-appx:///Resources/Brushes/{theme}Brushes.xaml");

                foreach (var resource in new ResourceDictionary { Source = resourceSource })
                {
                    var colorObj = (dynamic)resource.Value;

                    switch (resource.Value.GetType().Name)
                    {
                        case "SolidColorBrush":
                            (App.Current.Resources[resource.Key] as SolidColorBrush).Color = Color.FromArgb(
                                colorObj.Color.A,
                                colorObj.Color.R,
                                colorObj.Color.G,
                                colorObj.Color.B);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("There was a problem changing the theme: " + e.Message);
            }
            
        }
    }
}
