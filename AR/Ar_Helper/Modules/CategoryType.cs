using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper
{
   public class CategoryType:NotifyPropertyChanged
    {
        private int CategoryID_;
        public int CategoryID
        {
            get => CategoryID_;
            set
            {
               
                CategoryID_ = value;
                OnPropertyChanged();
            }
        }
        private string catagorytype_;
        public string Categorytype
        {
            get => catagorytype_;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                catagorytype_ = value;
                OnPropertyChanged();
            }
        }

       
    }
}
