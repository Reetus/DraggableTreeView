using System;
using System.Windows.Input;

namespace SampleApp
{
    public class BaseViewModel : SetPropertyNotifyChanged
    {
    }

    public class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand( Action<object> execute, Func<object, bool> canExecute = null )
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute( object parameter )
        {
            return _canExecute == null || _canExecute( parameter );
        }

        public void Execute( object parameter )
        {
            _execute( parameter );
        }

        private event EventHandler CanExecuteChangedInternal;

        // ReSharper disable once UnusedMember.Global
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChangedInternal?.Invoke( this, EventArgs.Empty );
        }
    }
}