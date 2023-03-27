
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

namespace TwinPics.ViewModels
{
    public partial class TestViewModel : ObservableObject
    {
        
        [ObservableProperty]
        private string name;
       
        public ICommand TestCommand { get; set; }

        public TestViewModel()
        {
            TestCommand = new RelayCommand<DragAndDropEventArgs>(Test);
        }
        public void Test(DragAndDropEventArgs dropEventArgs)
        {
           
        }
    }
}
