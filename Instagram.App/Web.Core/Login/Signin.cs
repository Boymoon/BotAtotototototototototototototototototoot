using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Instagram.App
{
    public class Login
    {
        /// <summary>
        /// متغير خاص  يستخدم في عملية  جلب البيانات من صفحة تسجيل الدخول 
        /// </summary>
        private ModelMainWindow model_;
        /// <summary>
        /// مشيد للفئة signin
        /// </summary>
        /// <param name="model"></param>
        public Login(ModelMainWindow model)
        {
            model_ = model;
        }
        public bool login()
        {
            if (model_ == null)
            {
                return false;
            }
            try
            {

                KernalWeb.Driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
                Thread.Sleep(4000);

                //ارسال اسم المستخدم 
                KernalWeb.Driver.FindElement(By.Name("username")).SendKeys(model_.Username);
                LoggerViewModel.Log("Typing username", TypeOfLog.check);
                //ارسال كلمة المرور
                KernalWeb.Driver.FindElement(By.Name("password")).SendKeys(model_.Password);
                LoggerViewModel.Log("Typing password", TypeOfLog.check);
                //الضغط على زر تسجيل الدخول
                KernalWeb.Driver.FindElements(By.TagName("button"))[0].Click();
                //التحقق من تسجيل الدخول
                Thread.Sleep(1500);
                try
                {
                    KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 1);
                    if (KernalWeb.Driver.FindElement(By.Id("slfErrorAlert")).Displayed)
                    {
                        //لم يتم تسجيل الدخول
                        return false;
                    }
                    else
                    {
                        //تم تسجيل الدخول
                        foreach (var CheckForAlerts in KernalWeb.Driver.FindElements(By.TagName("a")))
                        {
                            if (!string.IsNullOrEmpty(CheckForAlerts.Text) && CheckForAlerts.Text.Contains("Not Now"))
                            {
                                CheckForAlerts.Click();
                            }

                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("no")||ex.Message.Contains("HTTP"))
                    {
                        foreach (var CheckForAlerts in KernalWeb.Driver.FindElements(By.TagName("a")))
                        {
                            if (!string.IsNullOrEmpty(CheckForAlerts.Text) && CheckForAlerts.Text.Contains("Not Now"))
                            {
                                CheckForAlerts.Click();
                            }

                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("password"))
                {
                    //تم تسجيل الدخول
                    return true;
                }
                else
                {
                    LoggerViewModel.Log($"Ops.. something went wrong -> {ex.Message}", TypeOfLog.exclamationcircle);
                    //لم يتم تسجيل الدخول
                    return false;
                }
            }
        }
    }
}
