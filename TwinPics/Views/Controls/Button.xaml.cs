using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TwinPics.Views.Controls
{
    public sealed partial class Button : UserControl
    {  
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(Button), new PropertyMetadata(string.Empty));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register("TextColor", typeof(SolidColorBrush), typeof(Button), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#ff0000"))));
        public SolidColorBrush TextColor
        {
            get { return (SolidColorBrush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty IconColorProperty = DependencyProperty.Register("IconColor", typeof(SolidColorBrush), typeof(Button), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#ff0000"))));
        public SolidColorBrush IconColor
        {
            get { return (SolidColorBrush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }


        public static readonly DependencyProperty HoveredStatesProperty = DependencyProperty.Register("HoveredStates", typeof(ButtonHoveredStates), typeof(Button), new PropertyMetadata(null));
        public ButtonHoveredStates HoveredStates
        {
            get { return (ButtonHoveredStates)GetValue(HoveredStatesProperty); }
            set { SetValue(HoveredStatesProperty, value); }
        }

        public Button()
        {
            this.InitializeComponent();
            
        }

        private void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            
        }
    }
}