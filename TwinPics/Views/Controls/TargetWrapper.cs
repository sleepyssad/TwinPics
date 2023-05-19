using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TwinPics.Views.Controls
{
    public class TargetWrapper : UserControl
    {
        private bool _isPointerPressed;

        public event RoutedEventHandler Click;

        protected override void OnPointerExited(PointerRoutedEventArgs e)
        {
            base.OnPointerExited(e);
            _isPointerPressed = false;
        }

        protected override void OnPointerPressed(PointerRoutedEventArgs e)
        {
            base.OnPointerPressed(e);

            _isPointerPressed = true;
        }

        protected override void OnPointerReleased(PointerRoutedEventArgs e)
        {
            base.OnPointerReleased(e);

            if (_isPointerPressed)
            {
                _isPointerPressed = false;
                Click?.Invoke(this, e);
            }
        }
    }
}
