using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using TwinPics.Controllers;
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
    public sealed partial class TestControl : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TestControl), new PropertyMetadata(null));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register("TextColor", typeof(SolidColorBrush), typeof(TestControl), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#00ff00"))));
        public SolidColorBrush TextColor
        {
            get { return (SolidColorBrush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty HoveredTextColorProperty = DependencyProperty.Register("HoveredTextColor", typeof(SolidColorBrush), typeof(TestControl), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#ff0000"))));
        public SolidColorBrush HoveredTextColor
        {
            get { return (SolidColorBrush)GetValue(HoveredTextColorProperty); }
            set { SetValue(HoveredTextColorProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(TestControl), new PropertyMetadata(null));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public TestControl()
        {
            this.InitializeComponent();

            AppController.OnThemeChanged += OnThemeChanged;
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            try
            {
                HoverStateTextElement.To = HoveredTextColor.Color;
                DefaultStateTextElement.To = TextColor.Color;
                var sds = Background;
                DefaultState.Begin();
            }
            catch
            {

            }
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }

        
        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {  
            HoverState.Begin();
        }

        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            DefaultState.Begin();
        }
    }
}
