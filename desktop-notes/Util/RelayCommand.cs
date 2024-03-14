using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace desktop_notes.Util
{
    public class RelayCommand : ICommand
    {
        #region Constructor
        public RelayCommand(Action<object?> action)
        {
            _action = action;
        }

        public RelayCommand(Action<object?> action, Func<object?, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        #endregion


        #region Field
        Action<object?> _action;
        Func<object?, bool>? _canExecute = null;
        #endregion


        #region ICommand member
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter) => _action(parameter);
        #endregion
    }
}
