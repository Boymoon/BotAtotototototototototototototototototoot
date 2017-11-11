using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instagram.App
{
   public class ModelMention:BaseViewModel
    {
        private string FullMention_;
        /// <summary>
        /// كامل المنشن 
        /// </summary>
        public string FullMention
        {
            get { return FullMention_; }
            set { FullMention_ = value; OnPropertyChanged(); }
        }
        private string username_;
        /// <summary>
        /// اسم الشخص المراد منشنته
        /// </summary>
        public string Username
        {
            get { return username_; }
            set { username_ = value; OnPropertyChanged(); }
        }
        private string Uid_;
        /// <summary>
        /// اسم الشخص المراد منشنته
        /// </summary>
        public string Uid
        {
            get { return Uid_; }
            set { Uid_= value; OnPropertyChanged(); }
        }
        /// <summary>
        /// امر الحفظ
        /// </summary>
        public ICommand SaveCommand { get; set; }
    }
}
