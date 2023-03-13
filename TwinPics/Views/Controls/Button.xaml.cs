using Microsoft.Toolkit.Uwp.Helpers;
using System;
using TwinPics.Controllers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace TwinPics.Views.Controls
{
    public sealed partial class Button : UserControl
    {
        // TODO: Button -> Add loading to button
        // TODO: Button -> Add tooltip
        // TODO: Button -> Add command & command parameter

        public event EventHandler<DragAndDropEventArgs> OnTapped;

        public event EventHandler<DragAndDropEventArgs> OnPointerEntered;

        public event EventHandler<DragAndDropEventArgs> OnPointerExited;

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(Button), new PropertyMetadata(null));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register("TextColor", typeof(SolidColorBrush), typeof(Button), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#ffffff"))));
        public SolidColorBrush TextColor
        {
            get { return (SolidColorBrush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty IconColorProperty = DependencyProperty.Register("IconColor", typeof(SolidColorBrush), typeof(Button), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#ffffff"))));
        public SolidColorBrush IconColor
        {
            get { return (SolidColorBrush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register("IconSize", typeof(double), typeof(Button), new PropertyMetadata((double)18));
        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(Uri), typeof(Button), new PropertyMetadata(null));
        public Uri Icon
        {
            get { return (Uri)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty CanRippleEffectProperty = DependencyProperty.Register("CanRippleEffect", typeof(bool), typeof(Button), new PropertyMetadata(true));
        public bool CanRippleEffect
        {
            get { return (bool)GetValue(CanRippleEffectProperty); }
            set { SetValue(CanRippleEffectProperty, value); }
        }

        public static readonly DependencyProperty HoveredTextColorProperty = DependencyProperty.Register("HoveredTextColor", typeof(SolidColorBrush), typeof(Button), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#ffffff"))));
        public SolidColorBrush HoveredTextColor
        {
            get { return (SolidColorBrush)GetValue(HoveredTextColorProperty); }
            set { SetValue(HoveredTextColorProperty, value); }
        }

        public static readonly DependencyProperty HoveredIconColorProperty = DependencyProperty.Register("HoveredIconColor", typeof(SolidColorBrush), typeof(Button), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#ffffff"))));
        public SolidColorBrush HoveredIconColor
        {
            get { return (SolidColorBrush)GetValue(HoveredIconColorProperty); }
            set { SetValue(HoveredIconColorProperty, value); }
        }

        public static readonly DependencyProperty HoveredBackgroundProperty = DependencyProperty.Register("HoveredBackground", typeof(SolidColorBrush), typeof(Button), new PropertyMetadata(new SolidColorBrush(ColorHelper.ToColor("#006be9"))));
        public SolidColorBrush HoveredBackground
        {
            get { return (SolidColorBrush)GetValue(HoveredBackgroundProperty); }
            set { SetValue(HoveredBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HoveredBorderBrushProperty = DependencyProperty.Register("HoveredBorderBrush", typeof(SolidColorBrush), typeof(Button), new PropertyMetadata(new SolidColorBrush(Windows.UI.Colors.Transparent)));
        public SolidColorBrush HoveredBorderBrush
        {
            get { return (SolidColorBrush)GetValue(HoveredBorderBrushProperty); }
            set { SetValue(HoveredBorderBrushProperty, value); }
        }


        public Button()
        {
            InitializeComponent();

            DataContext = this;
            AppController.OnThemeChanged += OnThemeChanged;
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            try
            {
                DataContext = null;
                DataContext = this;
                DefaultState.Begin();
            }
            catch
            {

            }
        }

        private void FormLoaded(object sender, RoutedEventArgs e)
        {
            if (BorderBrush == null)
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Transparent);
            if (Background == null)
                Background = new SolidColorBrush(ColorHelper.ToColor("#006be9"));
        }

        private void Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (CanRippleEffect)
            {
                EllipseElement.Width = EllipseElement.Height = this.ActualWidth / 5;
                EllipseElement.Margin = new Thickness(e.GetPosition(this).X - (EllipseElement.Width / 2), e.GetPosition(this).Y - (EllipseElement.Height / 2), 0, 0);
                TappedState.Begin();
            }

            if (OnTapped != null)
            {
                OnTapped(this, null);
            }
        }

        private void PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                HoverState.Begin();
            }
            catch
            {

            }

            if (OnPointerEntered != null) 
            {
                OnPointerEntered(this, null);
            }
        }

        private void PointerExited(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                DefaultState.Begin();
            }
            catch
            {

            }

            if (OnPointerExited != null)
            {
                OnPointerExited(this, null);
            }
        }

        private void OnEllipseLoaded(object sender, RoutedEventArgs e)
        {
            EllipseElement.Width = EllipseElement.Height = this.ActualWidth / 5;
        }
    }
}