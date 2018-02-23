using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ar_Helper.ModelView
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

      public void refreshCommand()
        {
            CommandManager.InvalidateRequerySuggested();
        }
       
           
        
        public bool CanExecute(object parameter)
        {
            if (this.canExecute!=null)
            {
                return this.canExecute(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
