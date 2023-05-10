using System;
using TwinPics.Views.Controls;

namespace TwinPics.Contracts.Services
{
    public interface IModalWindowService
    {
        event EventHandler Opened;

        event EventHandler Closed;

        void Open(ModalWindowProps props);

        void Close();
    }
}
