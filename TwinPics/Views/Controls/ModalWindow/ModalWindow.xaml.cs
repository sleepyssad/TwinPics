using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using System.Threading.Tasks;

namespace TwinPics.Views.Controls
{
    public sealed partial class ModalWindow : UserControl
    {

        public static double INDENT = 35.0;

        public readonly Thickness INDENT_THICKNESS_TOP = new Thickness(0, INDENT, 0, 0);

        public readonly Thickness INDENT_THICKNESS_BOTTOM = new Thickness(0, 0, 0, INDENT);

        public readonly double INDENT_HEIGHT = INDENT;

        private bool _canClose = false;

        public ModalWindow()
        {
            this.InitializeComponent();

            ModalWindowController.OnOpenModalWindow += OpenModalWindow;
            ModalWindowController.OnCloseModalWindow += CloseModalWindow;
        }

        private async Task StartCanCloseTimer()
        {
            if (!_canClose)
            {
                await Task.Delay(50);
                _canClose = true;
            }
        }

        private void SetProps(ModalWindowProps props)
        {
            /* Init grid columns */
            {
                ColumnDefinition getSideTemplate() => new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star),
                    MinWidth = INDENT
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
                {
                    modalTemplate.MinWidth = props.MinWidth;
                }

                if (props.MaxWidth != default)
                {
                    modalTemplate.MaxWidth = props.MaxWidth;
                }

                GridContainer.ColumnDefinitions.Clear();
                GridContainer.ColumnDefinitions.Add(getSideTemplate());
                GridContainer.ColumnDefinitions.Add(modalTemplate);
                GridContainer.ColumnDefinitions.Add(getSideTemplate());
            }

            /* Init header */
            {
                if (props.IsVisibleHeader == false)
                {
                    HeaderContainer.Height = HeaderContainer.CornerRadius.TopLeft;
                    HeaderContent.Visibility = Visibility.Collapsed;
                }
                else
                {
                    HeaderContainer.Height = 50;
                    HeaderContent.Visibility = Visibility.Visible;
                }

            }
        }

        private void ResetStates()
        {
            ContetntScrollViewer.ScrollToVerticalOffset(0);
            ContetntScrollViewer.Margin = new Thickness(0, 0, 0, 0);
        }

        private void OpenModalWindow(object sender, EventArgs e)
        {
            if (sender is ModalWindowProps props)
            {
                SetProps(props);

                MainContainer.Visibility = Visibility.Visible;

                OpenState.Begin();
                OpenState.Completed += (object sender, object e) => 
                {
                    /* Buffer time to allow close modal window */
                    StartCanCloseTimer();
                };
            }
        }

        private void CloseModalWindow(object sender, EventArgs e)
        {
            _canClose = false;
            ClosedState.Begin();
            ClosedState.Completed += (object sender, object e) =>
            {
                MainContainer.Visibility = Visibility.Collapsed;
                ResetStates();
            };
        }

        private void BackstageCloseClick(object sender, PointerRoutedEventArgs e)
        {
            if (_canClose)
            {
                ModalWindowController.CallCloseModalWindow();
            }
        }

        private void ButtonCloseClick(object sender, DragAndDropEventArgs e)
        {
            ModalWindowController.CallCloseModalWindow();
        }

        private void ScrollChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (sender is ScrollViewer scroll)
            {
                var offset = (scroll.VerticalOffset - scroll.ScrollableHeight) * -1;

                /* FocusVisualSecondaryThickness is responsible for Margin in VerticalScrollBar */
                scroll.FocusVisualSecondaryThickness = new Thickness(0, 0, 0, offset <= INDENT ? INDENT - offset : 0);
            }
        }
    }
}
