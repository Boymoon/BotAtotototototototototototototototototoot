using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using System.Net;

namespace Instagram.App
{
    /// <summary>
    /// كلاس او فئة لتشغيل الدرايفر
    /// </summary>
    public static class KernalWeb
    {
        #region  Public properties
        /// <summary>
        /// عنوان عمليات المتصفح
        /// </summary>
        public static List<Int64> _PID { get; private set; } = new List<long>();
        /// <summary>
        /// نسند له قيمه افتراضية وهي رابط instagram
        /// </summary>
        public static string Url { get; set; } = "https://www.instagram.com/";
        /// <summary>
        /// معامل المتصفح
        /// </summary>
        private static string args { get { return "--user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25"; } }
        /// <summary>
        /// المحرك الرئيسي لتشغيل جميع الصفحات درايفر  من نوع كروم درايفر 
        /// </summary>
        public static ChromeDriver Driver { get; private set; }
        /// <summary>
        /// المتصفح المؤقت
        /// </summary>
        private static ChromeDriver _TemporaryDriver;
        /// <summary>
        /// المتصفح المؤقت 
        /// </summary>
        public static ChromeDriver TemporaryDriver { get { return _TemporaryDriver;} }
        /// <summary>
        /// عنوان الحساب المستهدف في المتصفح المؤقت
        /// </summary>
        public static string target { get; set; }
        #endregion
        /// <summary>
        /// تنصيب وتجهيز  الدرايفر الخاص بتشغيل الصفحة 
        /// </summary>
        public static void Setup()
        {
            //ليس فارغ url التحقق  من ان المتغير
            if (String.IsNullOrEmpty(Url))
            {
                return;
            }
            var driver_serv = ChromeDriverService.CreateDefaultService();
            driver_serv.HideCommandPromptWindow = true;
            var driverOptions = new ChromeOptions();
            driverOptions.AddArgument("headless");
            driverOptions.AddArgument(args);
            Driver = new ChromeDriver(driver_serv, driverOptions);
            _PID.Add((long)driver_serv.ProcessId);
            //اذهب الى الصفحة URL
            Driver.Navigate().GoToUrl(Url);
        }
        public static void CreateTemporaryDriver(string target_)
        {
            target = target_;
            _TemporaryDriver = CreateTemporaryDriver();
        }
        /// <summary>
        /// انشاء متصفح لغرض  محدد مثل  جلب  المنشورات  
        /// <paramref name="Target">عنوان الهدف</paramref>
        /// </summary>
        /// 
        private static ChromeDriver CreateTemporaryDriver()
        {
            var Service = ChromeDriverService.CreateDefaultService();
            Service.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument(args);
            _PID.Add((long)Service.ProcessId);
            return new ChromeDriver(Service, options);
        }
        /// <summary>
        /// اضافة الجلسة الحالية للمتصفح  المؤقت 
        /// </summary>
        /// <param name="CurrentDriver"></param>
        public static void AddCookiesToTemporaryDriver(ChromeDriver CurrentDriver)
        {
            if (CurrentDriver==null)
            {
                return;
            }
            CurrentDriver.Manage().Cookies.AddCookie(Driver.Manage().Cookies.AllCookies[1]);
        }
        /* exctract Cookies From Webbrowser that we logged in with */
        public static CookieContainer GetCookie()
        {
            if (Driver.Manage().Cookies.AllCookies.Count == 0)
            {
                return null;
            }
            var container = new CookieContainer();
            foreach (var Cookie_ in Driver.Manage().Cookies.AllCookies)
            {
                container.Add(new System.Net.Cookie()
                {
                    Domain = Cookie_.Domain,
                    HttpOnly = Cookie_.IsHttpOnly,
                    Value = Cookie_.Value,
                    Name = Cookie_.Name,
                    Path = Cookie_.Path,
                    Secure = Cookie_.Secure,
                    Expires = Cookie_.Expiry.GetValueOrDefault()
                });
            }
            return container;
        }
    }
}
