using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TwinPics.Views.Controls
{
    public sealed partial class DragAndDrop : UserControl
    {
        // TODO: DragAndDrop -> Add command & command parameter
        public DragAndDrop()
        {
            this.InitializeComponent();
        }

        public event EventHandler<DragAndDropEventArgs> OnStorageFolder;

        private async void OnFolderDragOver(object sender, DragEventArgs e)
        {
            var deferral = e.GetDeferral();

            // Checking that we are not dragging the file.
            // We give consent only if we dragging the folder.

            foreach (var storag in await e.DataView.GetStorageItemsAsync())
            {
                if (!storag.IsOfType(StorageItemTypes.Folder))
                {
                    if (e.DragUIOverride != null)
                    {
                        e.DragUIOverride.Caption = "Only folders allowed";
                    }

                    InvalidStrokeDash.Begin();
                    deferral.Complete();

                    return;
                }
              
            }

            e.AcceptedOperation = DataPackageOperation.Copy;

            if (e.DragUIOverride != null)
            {
                e.DragUIOverride.Caption = "Add folder";
                e.DragUIOverride.IsContentVisible = true;
            }

            ActiveStrokeDash.Begin();

            deferral.Complete();
        }

      

        private void OnFolderDragLeave(object sender, DragEventArgs e)
        {
            DefaulStrokeDash.Begin();
        }

        private async void OnFolderDrop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems) && OnStorageFolder != null)
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    OnStorageFolder(this, new DragAndDropEventArgs(items.OfType<StorageFolder>().ToList()));
                }
            }

            DefaulStrokeDash.Begin();
        }

        private async void OnRectangleTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {  
            StorageFolder folder = await new FolderPicker().PickSingleFolderAsync();

            if (folder != null && OnStorageFolder != null)
            {
                OnStorageFolder(this, new DragAndDropEventArgs(new List<StorageFolder> { folder }));
            }
        }
    }
}
