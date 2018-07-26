using System;
using System.Windows.Input;

namespace TradITAM.ViewModel
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<T> execute,
            Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            if (parameter is T t)
            {
                return _canExecute((T)parameter);
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            if (parameter is T t)
            {
                _execute(t);
            }
            else
            {
                _execute(default(T));
            }

        }

        #endregion

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}