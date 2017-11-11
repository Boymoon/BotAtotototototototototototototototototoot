using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Instagram.App
{
    public class BaseCommand : ICommand
    {
        /// <summary>
        /// تعريف الدالة Exc
        /// لتنفيذها في -Execute 
        /// </summary>
        Action Exc_;

        public BaseCommand(Action action_)
        {
            //اسناد قيمة Exc_ الى action_
            Exc_ = action_;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if (parameter == "--w")
            {
                return false;
            }
            else
            {
                //نخبر الزر الذي نريد الضغط عليه  بتنفيذ الدالة Execute 
                return true;
            }
        }

        public void Execute(object parameter)
        {
            Exc_();
        }
    }
}
