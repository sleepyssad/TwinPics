using Microsoft.Toolkit.Uwp.UI.Helpers;
using TwinPics.Resources;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace TwinPics.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            sdsdds.IsRunning = !sdsdds.IsRunning;
        }
    }
}
