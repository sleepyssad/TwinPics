using Microsoft.Toolkit.Uwp.Helpers;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace TwinPics.Views.Controls
{
    public sealed partial class Loader : UserControl
    {

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(Loader), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#006be9"))));
        public SolidColorBrush Color
        {
            get { return (SolidColorBrush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty = DependencyProperty.Register("Thickness", typeof(double), typeof(Loader), new PropertyMetadata((double)25));
        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty IsRunningProperty = DependencyProperty.Register("IsRunning", typeof(bool), typeof(Loader), new PropertyMetadata(true));
        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set 
            {
                if (value)
                {
                    Visibility = Visibility.Visible;
                    StoryboardLoader.Begin();
                }
                else
                {
                    Visibility = Visibility.Collapsed;
                    StoryboardLoader.Stop();
                }
                SetValue(IsRunningProperty, value);
            }
        }

        public Loader()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content != null && IsRunning == true)
            {
                Visibility = Visibility.Visible;
                StoryboardLoader.Begin();
            }
        }
    }
}