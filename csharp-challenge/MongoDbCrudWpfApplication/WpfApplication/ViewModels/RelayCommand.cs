using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApplication.ViewModels
{
    class RelayCommand : ICommand
    {
        readonly Action<object> _executeMethod;
        readonly Func<object, bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}
