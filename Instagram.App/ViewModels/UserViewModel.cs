using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// امر التحديث لم يكتمل
    /// امر التحويل بين الاقسام لم يكتمل 
    /// امر  جلب الاشخاص الذين قامو بالتعليق لم يكتمل
    /// امر جلب الاشخاص الذين قامو بالاعجاب بمنشور لم يكتمل
    /// </summary>
   public class UserViewModel
    {
        private UserModel UserModel_;
        /* DataContext Of Form Loggedin */
        public UserModel UserModel
        {
            get { return UserModel_; }
            set { UserModel_ = value; }
        }
        public UserViewModel()
        {
            UserModel_ = new UserModel();
            UserModel_.Refresh = new BaseCommand(refresh);
        }

        private void refresh()
        {
            Task.Run(() => {
            UserModel_.Posts = new System.Collections.ObjectModel.ObservableCollection<ModelPost>(new User("https://www.instagram.com/kotlins2030/")._posts_);
            });
        }
    }
}
