using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TwinPics.Views.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace TwinPics.Views.Pages
{
   
    public sealed partial class PrimaryPage : Page
    {
        public PrimaryPage()
        {
            this.InitializeComponent();
        }

       
        private void FilesSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is ScrollViewer container && container.Content is FrameworkElement content)
            {
                DragAndDropControl.Margin = new Thickness(0, 0, 0, content.ActualHeight >= 40 ? content.ActualHeight + 10 : 0);
            }
        }
    }
}
