using System;
using System.Collections.Generic;
using Windows.Storage;

namespace TwinPics.Views.Controls
{
    public class DragAndDropEventArgs : EventArgs
    {
        private readonly List<StorageFolder> storageFolders;

        public DragAndDropEventArgs(List<StorageFolder> list)
        {
            storageFolders = list;
        }

        public List<StorageFolder> StorageFolders
        {
            get { return storageFolders; }
        }
    }
}
