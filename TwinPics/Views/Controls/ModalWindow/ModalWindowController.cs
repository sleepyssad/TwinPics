using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TwinPics.Views.Controls
{
    public static class ModalWindowController
    {
        public static event EventHandler OnOpenModalWindow;
        public static void CallOpenModalWindow(ModalWindowProps props)
        {
            if (OnOpenModalWindow != null)
            {
                OnOpenModalWindow(props, new EventArgs());
            }
        }

        public static event EventHandler OnCloseModalWindow;
        public static void CallCloseModalWindow()
        {
            if (OnCloseModalWindow != null)
            {
                OnCloseModalWindow(default, new EventArgs());
            }
        }
    }
}
