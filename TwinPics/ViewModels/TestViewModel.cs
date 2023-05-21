
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TwinPics.Views.Controls;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.Toolkit.Uwp.Helpers;

namespace TwinPics.ViewModels
{

    public partial class FileData : ObservableObject
    {
        [ObservableProperty]
        private int fileName;
    }

    public partial class TestViewModel : ObservableObject
    {
        
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private ObservableCollection<FileData> files;

        public ICommand TestCommand { get; set; }

        public TestViewModel()
        {
            Files = new ObservableCollection<FileData>();

            TestCommand = new RelayCommand<DragAndDropEventArgs>(Test);
        }

       

        private async Task TaskAsync()
        {
            Files.Add(new FileData { FileName = 1 });
            int index = Files.Count - 1;

            while (Files[index].FileName < 1000)
            {
                await Task.Delay(250);

                // Используем метод RunAsync для выполнения кода в основном потоке UI
                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    Files[index].FileName++;
                });
            }
        }
        private CancellationTokenSource cancellationTokenSource;
        public async void Test(DragAndDropEventArgs dropEventArgs)
        {
           
            cancellationTokenSource = new CancellationTokenSource();
            await TaskAsync();

        }
    }
}
