
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

namespace TwinPics.ViewModels
{

    public class FileData
    {
        public string FileName { get; set; }
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
        public void Test(DragAndDropEventArgs dropEventArgs)
        {
            Files.Add(new FileData { FileName = "1" });
        }
    }
}
