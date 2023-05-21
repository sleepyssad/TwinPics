using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TwinPics.Views.Components;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TwinPics.Views.Controls
{
    public sealed partial class DragAndDrop : UserControl
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(DragAndDrop), new PropertyMetadata(null));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public event EventHandler<DragAndDropEventArgs> OnStorageFolder;

        public DragAndDrop()
        {
            this.InitializeComponent();
        }

        private void InvalidState(DragEventArgs e = null)
        {
            if (e != null && e.DragUIOverride != null)
            {
                e.DragUIOverride.Caption = "Only folders allowed";
            }
            InvalidStrokeDash.Begin();
        }

        private void ValidState(DragEventArgs e = null)
        {
            if (e != null)
            {
                e.AcceptedOperation = DataPackageOperation.Copy;

                if (e.DragUIOverride != null)
                {
                    e.DragUIOverride.Caption = "Add folder";
                    e.DragUIOverride.IsContentVisible = true;
                }
            }

            ActiveStrokeDash.Begin();
        }

        private async void OnFolderDragOver(object sender, DragEventArgs e)
        {
            var deferral = e.GetDeferral();

            // Checking that we are not dragging the file.
            // We give consent only if we dragging the folder.
            try
            {
                foreach (var storag in await e.DataView.GetStorageItemsAsync())
                {
                    if (!storag.IsOfType(StorageItemTypes.Folder))
                    {
                        InvalidState(e);
                        deferral.Complete();
                        return;
                    }

                }
            }
            catch(Exception ex) 
            {
                InvalidState(e);
                deferral.Complete();
                return;
            }
           
            ValidState(e);
            deferral.Complete();
        }

      

        private void OnFolderDragLeave(object sender, DragEventArgs e)
        {
            DefaulStrokeDash.Begin();
        }

        private async void OnFolderDrop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    var DropEventArgs = new DragAndDropEventArgs(items.OfType<StorageFolder>().ToList());

                    OnStorageFolder?.Invoke(this, DropEventArgs);

                    if (Command.CanExecute(DropEventArgs))
                    {
                        Command.Execute(DropEventArgs);
                    }
                }
            }

            DefaulStrokeDash.Begin();
        }

        private async void OnRectangleClick(object sender, dynamic e)
        {  
            StorageFolder folder = await new FolderPicker().PickSingleFolderAsync();

            if (folder != null)
            {
                var DropEventArgs = new DragAndDropEventArgs(new List<StorageFolder> { folder });

                
                OnStorageFolder?.Invoke(this, DropEventArgs);

                if (Command.CanExecute(DropEventArgs))
                {
                    Command.Execute(DropEventArgs);
                }
            }
        }
    }
}
