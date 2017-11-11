using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Instagram.App
{
    /// <summary>
    /// كلاس يهتم بجانب  تسجيل الحسابات
    /// يحتوي على 
    /// 1-تسجيل حساب  جديد اعتيادي
    /// 2-تسجيل حساب  جديد آلي
    /// </summary>
    public class SignupViewModel : BaseViewModel
    {
        /// <summary>
        /// متغيرات خاصة  تساعدنا على تعديل المتغيرات العامة
        /// </summary>
        #region PrivateFields

        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على الاسم 
        /// </summary>
        private string Username_;
        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على الاسم الكامل 
        /// </summary>
        private string Fullname_;
        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على كلمة المرور 
        /// </summary>
        private string Password_;
        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على الايميل 
        /// </summary>
        private string Email_;
        /// <summary>
        /// متغير يساعدنا في معرفة حالة  خيار التسجيل الآلي 
        /// </summary>
        private bool IsAutoSignup_;
        /// <summary>
        /// متغير يحصي الحسابات المسجلة
        /// </summary>
        private int Count_;
        /// <summary>
        /// متغير يحصي الحسابات التي فشل تسجيلها 
        /// </summary>
        private int unregistered_;
        /// <summary>
        /// متغير يساعدنا في عمل تأخير بين كل عملية تسجيل يجريها البرنامج
        /// </summary>
        private int From_ = 1;
        /// <summary>
        /// متغير يساعدنا في عمل تأخير بين كل عملية تسجيل يجريها البرنامج
        /// </summary>
        private int To_ = 60;
        #endregion
        /// <summary>
        /// متغيرات عامة تاخذ قيمها  من حقول صفحة التسجيل
        /// </summary>
        #region Public Properties
        /// <summary>
        /// اسم المستخدم لأجل التسجيل
        /// </summary>
        public string Username { get => Username_; set { Thread.Sleep(10); Username_ = (String.IsNullOrEmpty(value)) ? HelperData.Generate(false) : value; OnPropertyChanged(); } }
        /// <summary>
        /// الاسم الكامل من اجل التسجيل
        /// </summary>
        public string Fullname { get => Fullname_; set { Thread.Sleep(10); Fullname_ = (String.IsNullOrEmpty(value)) ? HelperData.Generate(false) : value; OnPropertyChanged(); } }
        /// <summary>
        /// كلمة المرور من اجل التسجيل
        /// </summary>
        public string Password { get => Password_; set { Thread.Sleep(10); Password_ = (String.IsNullOrEmpty(value)) ? HelperData.Generate(false) : value; OnPropertyChanged(); } }
        /// <summary> 
        /// -الايميل من اجل التسجيل -ليس شرط ان يكون حقيقي
        /// </summary>
        public string Email { get => Email_; set { Thread.Sleep(10); Email_ = (String.IsNullOrEmpty(value)) ? HelperData.Generate(true) : value; OnPropertyChanged(); } }
        /// <summary>
        /// تفعيل خيار التسجيل الآلي 
        /// </summary>
        public bool IsAutoSignup { get => IsAutoSignup_; set { IsAutoSignup_ = value; OnPropertyChanged(); } }
        /// <summary>
        /// متغير يحصي الحسابات المسجلة
        /// </summary>
        public int Count { get => Count_; set { Count_ = value; OnPropertyChanged(); } }
        /// <summary>
        /// متغير يحصي الحسابات التي فشل تسجيلها 
        /// </summary>
        public int unregistered { get => unregistered_; set { unregistered_ = value; OnPropertyChanged(); } }
        /// <summary>
        /// متغير يساعدنا في عمل تأخير بين كل عملية تسجيل يجريها البرنامج
        /// </summary>
        public int From { get => From_; set { From_ = value; OnPropertyChanged(); } }
        /// <summary>
        /// متغير يساعدنا في عمل تأخير بين كل عملية تسجيل يجريها البرنامج
        /// </summary>
        public int To { get => To_; set { To_ = value; OnPropertyChanged(); } }
        /// <summary>
        /// اذا  كان خيار  التسجيل  الآلي  مفعل  اضف جميع محتويات هذه الفئة في  هذا المجمع
        /// </summary>
        public ObservableCollection<HelperSignupViewModel> CollectionOfSignup { get; set; }
        /// <summary>
        /// ننشئ امر لتنفيذ تسجيل حساب جديد 
        /// </summary>
        public ICommand SignupCommand { get; set; }
        /// <summary>
        /// انشاء نسخة  من فئة تحمل 
        /// محتوى وايقونة الزر  ايقاف|بدأ 
        /// </summary>
        public CustomButton CustomButton { get; set; }
        #endregion
        /// <summary>
        /// اساس صفحة تسجيل الحسابات
        /// </summary>
        #region Constructor
        public SignupViewModel()
        {
            //اسناد المتغيرات الخاصة الى العامة  لتغير القيمة في صفحة تسجيل حساب 
            Username = Username_;
            Email = Email_;
            Password = Password_;
            Fullname = Fullname_;
            Count = Count_;
            To = To_;
            From = From_;
            unregistered = unregistered_;
            CollectionOfSignup = new ObservableCollection<HelperSignupViewModel>();

            CustomButton = new CustomButton(() =>
            {
                if (CustomButton.CommandParam != "DontStartagain")
                {
                    MultiSignup_IsOn();
                }
            });


            Task.Run(() =>
            {
                //ارسال طلب  لتسجيل حساب جديد
                SignupCommand = new BaseCommand(() =>
                {
                    try
                    {
                        KernalWeb.Driver.Quit();
                    }
                    catch (Exception)
                    {

                    }
                    if (new Signup(this).SignUp())
                    {
                        CollectionOfSignup.Add(new HelperSignupViewModel()
                        {
                            Username = Username_,
                            Email = Email_,
                            Password = Password_
                        });
                        Count++;
                    }
                    Username = string.Empty;
                    Email = string.Empty;
                    Password = string.Empty;
                    Fullname = string.Empty;

                });
            });


        }
        #endregion
        /// <summary>
        /// الدوال المساعدة
        /// </summary>
        /// <returns></returns>
        #region Methods
        /// <summary>
        /// دالة  ترجع لنا عملية تسجيل آلي 
        /// </summary>
        /// <returns></returns>
        public Task MultiSignup_IsOn()
        {
            //متغير لا يرجع قيمة حتى يتم اكمال  الثريد 
            var tcs = new TaskCompletionSource<bool>();
            //التأكد من زر بدأ\ايقاف لتجهيزه 
            if (CustomButton.Content == "!توقف")
            {
                CustomButton.CommandParam = "توقف";
                CustomButton.Content = null;
                CustomButton.CommandParam = "DontStartagain";
                CustomButton.Icon = null;


            }
            else
                Task.Run(() =>
                  {
                      //ارسال طلب  لبدء التسجيل الآلي
                      while (true)
                      {
                          if (CustomButton.Content == "بدأ" && CustomButton.CommandParam == "DontStartagain")
                          {
                              CustomButton.Content = null;
                              CustomButton.Icon = null;
                              CustomButton.CommandParam = null;
                              try
                              {
                                  KernalWeb.Driver.Quit();
                              }
                              catch (Exception) { tcs.TrySetCanceled(); }
                              break;
                          }
                          CustomButton.Content = "!توقف";
                          CustomButton.Icon = "Pause";
                          //نعمل عملية تأخير بين كل عملية تسجيل 

                          Thread.Sleep(new Random().Next(From, To) * 1000);
                          //نتأكد من  ان عملية التسجيل  قد تمت
                          if (new Signup(this, CustomButton).SignUp())
                          {
                              Application.Current.Dispatcher.Invoke(() =>
                              {
                                  CollectionOfSignup.Add(new HelperSignupViewModel()
                                  {
                                      Username = Username_,
                                      Email = Email_,
                                      Password = Password_
                                  });
                                  Count++;
                              });
                              try
                              {
                                  KernalWeb.Driver.Quit();
                              }
                              catch (Exception) { }
                          }

                          else
                          {
                              Username = string.Empty;
                              Email = string.Empty;
                              Password = string.Empty;
                              Fullname = string.Empty;
                              try
                              {
                                  KernalWeb.Driver.Quit();
                              }
                              catch (Exception) { }
                          }

                      }
                      try
                      {
                          KernalWeb.Driver.Quit();
                      }
                      catch (Exception) { tcs.TrySetCanceled(); return; }
                  });
            return tcs.Task;
        }
        #endregion
    }
    /// <summary>
    /// الكلاسات المساعدة 
    /// </summary>
    #region HelperClasses
    /// <summary>
    /// كلاس مساعد
    /// </summary>
    public class HelperSignupViewModel
    {
        /// <summary>
        /// متغير يحمل القيمة التي نريد  نقلها الى المجمع لعرضها في صفحة التسجيل
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// متغير يحمل القيمة التي نريد  نقلها الى المجمع لعرضها في صفحة التسجيل
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// متغير يحمل القيمة التي نريد  نقلها الى المجمع لعرضها في صفحة التسجيل
        /// </summary>
        public string Password { get; set; }

    }
    #endregion
}
