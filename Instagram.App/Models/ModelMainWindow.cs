using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Instagram.App
{
    public class ModelMainWindow : BaseViewModel
    {
        private string Username_;
        /// <summary>
        /// مؤشر لإسم المستخدم
        /// </summary>
        public string Username
        {
            get => Username_;
            set
            {
                Username_ = value;
                OnPropertyChanged();
            }
        }

        private string Password_;
        /// <summary>
        /// مؤشر لكلمة المرور
        /// </summary>
        public string Password
        {
            get => Password_;
            set
            {
                Password_ = value;
                OnPropertyChanged();
            }
        }
        private string StateOfLogin_ = "تسجيل الدخول";
        /// <summary>
        /// حالة تسجيل الدخول
        /// </summary>
        public string StateOfLogin
        {
            get { return StateOfLogin_; }
            set { StateOfLogin_ = value; OnPropertyChanged(); }
        }

        private bool IsLogedin_ = false;
        /// <summary>
        /// نتأكد ان الحساب قد دخل
        /// </summary>
        public bool IsLogedin
        {
            get => IsLogedin_;
            set
            {
                IsLogedin_ = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// امر حذف جميع العناصر من قاعدة البيانات
        /// /// </summary>
        public ICommand DeleteAll { get; set; }
        /// <summary>
        /// امر حذف عنصر محدد 
        /// </summary>
        public ICommand DeleteSelected { get; set; }
        /// <summary>
        /// امر لتسجيل الدخول
        /// </summary>
        public ICommand SigninCommand { get; set; }
        /// <summary>
        /// امر جديد لإظهار واجهة تسجيل الحسابات
        /// </summary>
        public ICommand ShowSignup { get; set; }
        /// <summary>
        /// امر جديد لإستيراد الحسابات من اكسل
        /// </summary>
        public ICommand ImportaccountCommand { get; set; }
        /// <summary>
        /// امر جديد لإضافة حساب الى قاعدة بيانات البرنامج
        /// </summary>
        public ICommand AddaccountsCommand { get; set; }
        /// <summary>
        /// اساس الواجهة الرئيسية
        /// </summary>
        public ModelMainWindow()
        {
            IsLogedin = IsLogedin_;
        }
    }
}

