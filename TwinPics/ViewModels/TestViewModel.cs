
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

    //public class Common : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected void NotifyPropertyChanged(string info) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    //}

    //public class Command : ICommand
    //{
    //    private Action<object> action;
    //    private bool canExecute;
    //    public event EventHandler CanExecuteChanged;

    //    public Command(Action<object> action, bool canExecute)
    //    {
    //        this.action = action;
    //        this.canExecute = canExecute;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        return canExecute;
    //    }

    //    public void Execute(object parameter)
    //    {
    //        action(parameter);
    //    }
    //}
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
