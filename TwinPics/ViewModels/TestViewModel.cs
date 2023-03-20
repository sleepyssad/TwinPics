
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace TwinPics.ViewModels
{

    public class Common : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }

    public class Command : ICommand
    {
        private Action<object> action;
        private bool canExecute;
        public event EventHandler CanExecuteChanged;

        public Command(Action<object> action, bool canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
    public class TestViewModel : Common
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { if (name != value) { name = value; NotifyPropertyChanged("Name"); } }
        }
        public ICommand TestCommand { get; set; }

        public TestViewModel()
        {
            TestCommand = new Command(Test, true);
            Name = "Hello";
        }
        public void Test(object s)
        {
            Name += "Hello";
        }
    }
}
