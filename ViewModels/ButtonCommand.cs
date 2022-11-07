using System;
using System.Windows.Input;
using WeatherDesktop.ViewModels;

namespace WeatherDesktop.ViewModels
{
    internal class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action _action;
        Func<bool> _func;

        public ButtonCommand(Action action, Func<bool> func = null)
        {
            _action = action;
            _func = func;
        }

        public bool CanExecute(object parameter)
        {
            return _func == null || _func();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}




