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
        public Page Page { get; set; }

        public string Title { get; set; }

        public bool IsVisibleTitleBar { get; set; } = true;

        public ModalWindowSize Size { get; set; } = ModalWindowSize.Adaptive;

        public double WidthPercent { get; set; }

        public double Width { get; set; }

        public double MinWidth { get; set; } = 100;

        public double MaxWidth { get; set; }
    }
}
