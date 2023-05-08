using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TwinPics.Views.Controls
{


    public class ModalWindowProps
    {
        public object Content { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public bool IsVisibleHeader { get; set; } = true;

        public ModalWindowSize Size { get; set; } = ModalWindowSize.Auto;

        public double WidthPercent { get; set; }

        public double Width { get; set; }

        public double MinWidth { get; set; } = 100;

        public double MaxWidth { get; set; }
    }
}
