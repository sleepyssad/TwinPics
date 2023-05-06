using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace TwinPics.Views.Controls
{
    public sealed partial class ModalWindow : UserControl
    {
        public ModalWindow()
        {
            this.InitializeComponent();

            ModalWindowController.OnOpenModalWindow += OpenModalWindow;
            ModalWindowController.OnCloseModalWindow += CloseModalWindow;
        }

        private void SetProps(ModalWindowProps props)
        {
            /* Init grid columns */
            {
                ColumnDefinition getSideTemplate() => new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star),
                    MinWidth = 50
                };

                var modalTemplate = new ColumnDefinition();

                switch (props.Size)
                {
                    case ModalWindowSize.Adaptive:
                        modalTemplate = new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) };
                        break;
                    case ModalWindowSize.Small:
                        modalTemplate = new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) };
                        break;
                    case ModalWindowSize.Medium:
                        modalTemplate = new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) };
                        break;
                    case ModalWindowSize.Large:
                        modalTemplate = new ColumnDefinition { Width = new GridLength(8, GridUnitType.Star) };
                        break;
                    case ModalWindowSize.Width:
                        modalTemplate = new ColumnDefinition { Width = new GridLength(props.Width) };
                        break;
                    case ModalWindowSize.Percent:
                        modalTemplate = new ColumnDefinition { Width = new GridLength(props.WidthPercent, GridUnitType.Star) };
                        break;
                }

                if (props.MinWidth != default)
                    modalTemplate.MinWidth = props.MinWidth;

                if (props.MaxWidth != default)
                    modalTemplate.MaxWidth = props.MaxWidth;


                GridContainer.ColumnDefinitions.Clear();
                GridContainer.ColumnDefinitions.Add(getSideTemplate());
                GridContainer.ColumnDefinitions.Add(modalTemplate);
                GridContainer.ColumnDefinitions.Add(getSideTemplate());
            }
        }

        private void OpenModalWindow(object sender, EventArgs e)
        {
            if (sender is ModalWindowProps props)
            {
                SetProps(props);

                MainContainer.Visibility = Visibility.Visible;
            }
        }

        private void CloseModalWindow(object sender, EventArgs e)
        {
            MainContainer.Visibility = Visibility.Collapsed;
        }

        private void BackstagePointerReleased(object sender, PointerRoutedEventArgs e)
        {
            ModalWindowController.CallCloseModalWindow();
        }
    }
}
