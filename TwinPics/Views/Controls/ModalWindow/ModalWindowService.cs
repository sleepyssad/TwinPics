using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinPics.Contracts.Services;

namespace TwinPics.Views.Controls
{
    public class ModalWindowService : IModalWindowService
    {
        public event EventHandler Opened;

        public event EventHandler Closed;

        public void Open(ModalWindowProps props)
        {
            Opened?.Invoke(props, new EventArgs());
        }

        public void Close()
        {
            Closed?.Invoke(default, new EventArgs());
        }
    }
}
