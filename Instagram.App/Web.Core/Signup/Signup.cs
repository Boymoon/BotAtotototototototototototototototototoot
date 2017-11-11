using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using System.Threading;
using System;
using System.Windows;

namespace Instagram.App
{
    /// <summary>
    /// كلاس  او فئة لتسجيل حساب جديد 
    /// </summary>
    public class Signup
    {
        #region private
        /// <summary>
        /// متغير يحمل قيمتين 
        /// true 
        /// false
        /// نستخدمه من اجل  ان نرفع اشعار للبرنامج ان تسجيل الحساب نجح
        /// </summary>
        private bool? IsLogedin;

        /// <summary>
        /// متغير يستخدم في جلب القيم
        /// الاسم 
        /// الاسم الكامل 
        /// ..كلمةالمرور
        /// الايميل
        /// </summary>
        private SignupViewModel SignupNew;
        /// <summary>
        /// متغير يستخدم في جلب القيم من فئة اخرى
        /// </summary>
        private CustomButton CustomButton;
        #endregion

        #region Methods
        /// <summary>
        /// دالة  تقوم  بإسناد قيمة  من البرامتر
        /// </summary>
        /// <param name="signup_">لجلب القيم  من فئة اخرى</param>
        public Signup(SignupViewModel signup_, CustomButton CustomButton_)
        {
            SignupNew = signup_;
            CustomButton = CustomButton_;
        }
        /// <summary>
        /// دالة  تقوم  بإسناد قيمة  من البرامتر
        /// </summary>
        /// <param name="signup_">لجلب القيم  من فئة اخرى</param>
        public Signup(SignupViewModel signup_)
            :this(signup_,null)
        {
            SignupNew = signup_;
        }
        /// <summary>
        /// دالة تقوم بعمل حساب جديد 
        /// </summary>
        /// <returns> ترجع متغير ثنائي القيمة  
        /// في حالة تسجيل حساب جديد ترجع لنا True
        /// في حالة عدم تسجيل حساب جديد ترجع لنا False
        /// </returns>
        public bool SignUp()
        {
            //التأكد من ان المتغير يحمل قيمة ثم التأكد من ان تنفيذه بدأ بعد ما المستخدم بدأ عملية تسجيل آلية
            if (CustomButton != null && CustomButton.Content == "بدأ" && CustomButton.CommandParam == "DontStartagain")
                return false;
            //التأكد من ان المتغير يحمل قيمة حتى يتسنى لنا  جلب  القيم منه 
            if (SignupNew == null)
                return false;
            try
            {
                //بدأ تشغيل الصفحة
                KernalWeb.Setup();
                //-بدأ ارسال البيانات -الايميل
                if (CustomButton != null && CustomButton.Content == "بدأ" && CustomButton.CommandParam == "DontStartagain")
                    return false;
                KernalWeb.Driver.FindElement(By.Name("emailOrPhone")).SendKeys(SignupNew.Email);

                //-بدأ ارسال البيانات -الاسم الكامل
                KernalWeb.Driver.FindElement(By.Name("fullName")).SendKeys(SignupNew.Fullname);

                //-بدأ ارسال البيانات -اسم المستخدم
                KernalWeb.Driver.FindElement(By.Name("username")).SendKeys(SignupNew.Username);

                //-بدأ ارسال البيانات -كلمة المرور
                KernalWeb.Driver.FindElement(By.Name("password")).SendKeys(SignupNew.Password);

                //بدأ ارسال نقرة على الزر تسجيل حساب بإستخدام TagName
                KernalWeb.Driver.FindElements(By.TagName("button"))[1].Click();

                //عملية  منفصلة للتأكد من ان تسجيل الحساب قد تم 
                Task task = Task.Run(() =>
                {
                    //نأخر التأكيد ل5 ثواني  حتى  يتم التأكد  من ان تسجيل الحساب قد تم 
                    Thread.Sleep(5000);
                    //التأكد من ان الحساب قد سُجل   
                    try
                    {
                        if (KernalWeb.Driver.FindElement(By.XPath("//*[@id='mainFeed']/div/div/h2")).Text.Contains("Welcome"))
                        {
                            IsLogedin = true;
                        }
                        else
                        {
                            IsLogedin = false;
                            SignupNew.unregistered++;
                        }
                    }
                    catch (Exception) { IsLogedin = false; SignupNew.unregistered++; LoggerViewModel.Log("Ops..! Something Went Wrong ):", TypeOfLog.questioncircle);
                    }
                });
                task.Wait();
            }
            catch (Exception)
            {
                IsLogedin = false;
                SignupNew.unregistered++;
            }
            return (bool)IsLogedin;

        }
        #endregion
    }
}
