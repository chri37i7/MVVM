using System;
using System.Windows.Input;

namespace MVVM.Entities
{
    /// <summary>
    /// Base command class implementing the ICommand interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommandBase<T> : ICommand
    {
        readonly Action<T> _TargetExecuteMethod;
        readonly Func<T, bool> _TargetCanExecuteMethod;

        public CommandBase(Action<T> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public CommandBase(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {

            if(_TargetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return _TargetCanExecuteMethod(tparm);
            }

            if(_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        // Beware - should use weak references if command instance lifetime is
        // longer than lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation 
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            _TargetExecuteMethod?.Invoke((T)parameter);
        }
        #endregion
    }
}
