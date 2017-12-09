using DevExpress.Xpf.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Instagram.App
{
    public class InfoMember
    {
        private string _username;
        public static bool Cancel = false;
        public InfoMember(string username)
        {
            _username = username;
            Cancel = false;
        }
        /// <summary>
        ///  دالة لجلب عدد متابعين بالتزامن 
        /// </summary>
        public Func<string, string, int> AsyncGetFollowers_ = (string Uid, string Name) =>
         {
             Operations.CurrentOT = OperationsTypes.DoGetCountAccount;
             int b = 0;
             var driver_serv = ChromeDriverService.CreateDefaultService();
             driver_serv.HideCommandPromptWindow = true;
             var driverOptions = new ChromeOptions();
             driverOptions.AddArgument("---headless");
             driverOptions.AddArgument("--user-agent=Mozilla/5.0 (Linux; Android 4.4.2; Nexus 4 Build/KOT49H) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.114 Mobile Safari/537.36");
             ChromeDriver driver = new ChromeDriver(driver_serv, driverOptions);
             driver.Navigate().GoToUrl(Uid);
             driver.Manage().Cookies.AddCookie(KernalWeb.Driver.Manage().Cookies.AllCookies[1]);
             driver.Navigate().GoToUrl(Uid);
             foreach (IWebElement itemm in driver.FindElements(By.TagName("a")))
             {
                 if (itemm.GetAttribute("href").Contains(Name))
                 {
                     try
                     {
                         KernalWeb.Driver.ExecuteScript("window.scrollBy(0,140);");
                         b = int.Parse(itemm.FindElement(By.TagName("span")).GetAttribute("title").Replace(",", "").Replace("followers", ""));
                         break;
                     }
                     catch (Exception ex)
                     {

                         Console.WriteLine(ex.Message);
                     }

                 }
                 else { }
             }
             //اذا كان  البي يساوي صفر اذا الحساب الخاص 
             if (b == 0)
             {
                 foreach (IWebElement itemm in driver.FindElements(By.TagName("li")))
                 {
                     if (itemm.FindElement(By.TagName("span")).Text.Contains("followers"))
                     {
                         try
                         {
                             KernalWeb.Driver.ExecuteScript("window.scrollBy(0,140);");
                             string bg = itemm.Text.Replace(",", "").Replace("followers", "");
                             b = int.Parse(itemm.Text.Replace(",", "").Replace("followers", ""));
                             break;
                         }
                         catch (Exception ex)
                         {

                             Console.WriteLine(ex.Message);
                         }

                     }
                     else { }
                 }
             }
             driver.Close();
             driver_serv.Dispose();
             Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
             return b;
         };
        public string GetFollower()
        {
            Operations.CurrentOT = OperationsTypes.GetCurrentFollowers;
            string b = "";
            try
            {

                foreach (IWebElement item in KernalWeb.Driver.FindElements(By.CssSelector("[class*='_ttgfw']")))
                {

                    if (item.GetAttribute("href") != null)
                    {
                        if (item.GetAttribute("href").Contains(_username.Substring(0, 5)[0]))
                        {
                            item.Click();
                            foreach (IWebElement itemm in KernalWeb.Driver.FindElements(By.TagName("a")))
                            {
                                if (itemm.GetAttribute("href").Contains(Getname()))
                                {
                                    b = itemm.Text.Replace("followers", "");
                                    break;
                                }

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        DXMessageBox.Show("يبدو ان هنالك مشكلة ما", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    });
                    LoggerViewModel.Log("Ops..! something went wrong", TypeOfLog.check);

                }
            }
            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
            return b;
        }
        /// <summary>
        /// متابعة حساب محدد|الغاء متابعة حساب محدد
        /// </summary>
        /// <param name="name">اسم الحساب المستهدف</param>
        /// <param name="Uid">رابط الحساب المستهدف</param>
        /// <returns>تمت  المتابعة ام لا|تم الغاء المتابعة ام لا </returns>
        public TypeOfResponse Follow(string name, string Uid, AccountOperations Conditions_,LoginViewModel loginViewModel_)
        {
            Operations.CurrentOT = OperationsTypes.DoFollow;
            KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 60);
            KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 60);
            var result = new TypeOfResponse();
            if (Uid == null)
                return TypeOfResponse.None;

            KernalWeb.Driver.Navigate().GoToUrl(Uid);
            try
            {
            KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(1200, 1000);

            }
            catch (Exception) { }
            try
            {
                foreach (var item in KernalWeb.Driver.FindElements(By.TagName("button")))
                {

                    if (Conditions_ != null
                     && Conditions_.FollowWhohasFollowingFrom_To
                     && item.Text == "Follow"
                     && Conditions_.To >= Conditions_.Followers
                     && Conditions_.From <= Conditions_.Followers
                     || Conditions_ != null
                     && Conditions_.FollowWhohasFollowingFrom_To
                     && item.Text == "Follow"
                     && Conditions_.To >= Conditions_.Followers
                     && Conditions_.From <= Conditions_.Followers
                     || Conditions_ != null
                     && item.Text == "Follow"
                     || Conditions_ != null
                     && loginViewModel_.AccountOperations.FollowAll
                     && Conditions_.FollowWhohasFollowingFrom_To
                     && item.Text == "Follow"
                     && Conditions_.To >= Conditions_.Followers
                     && Conditions_.From <= Conditions_.Followers
                     || Conditions_ != null
                     && loginViewModel_.AccountOperations.FollowAll
                     && item.Text == "Follow"
                     || Conditions_ != null
                     && item.Text == "Follow"
                     || Conditions_ != null
                     && Conditions_.FollowWhohasFollowingFrom_To
                     && (item.Text != "Follow" && item.Text.ToLower() == "following" || item.Text.ToLower() == "requested")
                     && Conditions_.To >= Conditions_.Followers
                     && Conditions_.From <= Conditions_.Followers
                     || Conditions_ != null
                     && Conditions_.FollowWhohasFollowingFrom_To
                     && (item.Text != "Follow" && item.Text.ToLower() == "following" || item.Text.ToLower() == "requested")
                     && Conditions_.To >= Conditions_.Followers
                     && Conditions_.From <= Conditions_.Followers
                     || Conditions_ != null
                     && (item.Text != "Follow" && item.Text.ToLower() == "following" || item.Text.ToLower() == "requested")
                     || Conditions_ != null
                     && loginViewModel_.AccountOperations.UnFollowAll
                     && Conditions_.FollowWhohasFollowingFrom_To
                     && (item.Text != "Follow" && item.Text.ToLower() == "following" || item.Text.ToLower() == "requested")
                     && Conditions_.To >= Conditions_.Followers
                     && Conditions_.From <= Conditions_.Followers
                     || Conditions_ != null
                     && loginViewModel_.AccountOperations.UnFollowAll
                     && (item.Text != "Follow" && item.Text.ToLower() == "following" || item.Text.ToLower() == "requested")
                     || Conditions_ != null
                     && (item.Text != "Follow" && item.Text.ToLower() == "following" || item.Text.ToLower() == "requested")

                     )
                    {

                        item.Click();
                        Thread.Sleep(4 * 1000);
                        switch (item.Text.ToLower())
                        {

                            case "follow":
                                {
                                    if (loginViewModel_.AccountOperations.UnFollowAll)
                                    {

                                        result = TypeOfResponse.None;
                                    }
                                    else
                                    {
                                        result = TypeOfResponse.Follow;
                                    }
                                    LoggerViewModel.Log(String.Format("you have recently canceled => {0}", Conditions_.Username), TypeOfLog.Warning);
                                    LoggerViewModel.Log(String.Format("you have recently canceled => {0}", loginViewModel_.AccountOperations.UnFollowAll), TypeOfLog.Warning);

                                    loginViewModel_.Login = Conditions_;
                                    //ارجاع حالة الحساب 
                                    Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                    return result;
                                }

                            case "following":
                                {
                                    if (loginViewModel_.AccountOperations.UnFollowAll)
                                    {

                                    result = TypeOfResponse.None;
                                    }
                                    else
                                    {
                                        result = TypeOfResponse.Following;
                                    }
                                    LoggerViewModel.Log(String.Format("you have recently Delete => {0} from your Followings", Conditions_.Username), TypeOfLog.check);
                                    loginViewModel_.Login = Conditions_;
                                    //ارجاع حالة الحساب 
                                    Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                    return result;
                                }

                            case "requested":
                                {
                                    if (loginViewModel_.AccountOperations.UnFollowAll)
                                    {

                                        result = TypeOfResponse.None;
                                    }
                                    else
                                    {
                                        result = TypeOfResponse.Requested;
                                    }
                                    LoggerViewModel.Log(String.Format("you have to wait your request to follow => {0}", Conditions_.Username), TypeOfLog.questioncircle);
                                    loginViewModel_.Login = Conditions_;
                                    //ارجاع حالة الحساب 
                                    Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                    return result;
                                }
                            default:
                                result = TypeOfResponse.None;
                                LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);
                                loginViewModel_.Login = Conditions_;
                                //تعذر العثور على القيمة المطلوبة
                                Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                return result;
                        }

                    }
                    else if (Conditions_ == null)
                    {
                        if (item.Text == "Follow")
                        {
                            item.Click();
                            Thread.Sleep(4 * 1000);
                            switch (item.Text)
                            {

                                case "Follow":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.None;
                                    }

                                case "Following":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.Following;
                                    }

                                case "Requested":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.Requested;
                                    }
                                default:
                                    //تعذر العثور على القيمة المطلوبة
                                    Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                    return TypeOfResponse.None;
                            }
                        }
                        else if (item.Text == "Following")
                        {
                            item.Click();
                            Thread.Sleep(4 * 1000);
                            switch (item.Text)
                            {

                                case "Follow":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.Follow;
                                    }

                                case "Following":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.None;
                                    }

                                case "Requested":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.Requested;
                                    }
                                default:
                                    //تعذر العثور على القيمة المطلوبة
                                    Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                    return TypeOfResponse.None;
                            }
                        }
                        else if (item.Text == "Requested")
                        {
                            item.Click();
                            Thread.Sleep(4 * 1000);
                            switch (item.Text)
                            {

                                case "Follow":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.Follow;
                                    }

                                case "Following":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.None;
                                    }

                                case "Requested":
                                    {
                                        //ارجاع حالة الحساب 
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return TypeOfResponse.Requested;
                                    }
                                default:
                                    //تعذر العثور على القيمة المطلوبة
                                    Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                    return TypeOfResponse.None;
                            }
                        }
                    }
                }
            }
            
            catch (Exception) { }
            return TypeOfResponse.None;

        }

        #region Removed 
        /// <summary>
        /// جلب متابعين حساب محدد
        /// </summary>
        /// <param name="observableCollectionCore">حاوية لتخزين البيانات</param>
        /// <param name="Uid">رابط الحساب المستهدف</param>
        /// <remarks>
        /// *حل مشكلة  ال xpath
        /// </remarks>
        //public void GetFollower(AccountOperations modelLogin_, ObservableCollection<AccountOperations> observableCollectionCore, ObservableCollection<int> Indexer, string Uid, Action act_ = null,LoginViewModel SelectedItem_=null)
        //{

        //    if (Uid == null)
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        //متغير للتحقق من ان القيمة ليست مكررة
        //        bool isRepeated = false;
        //        KernalWeb.Driver.Navigate().GoToUrl(Uid);
        //        KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 1);
        //        KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 1);
        //        try
        //        {
        //        KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(5, 400);

        //        }catch(Exception SizeEx)
        //        {
        //            LoggerViewModel.Log($"[Line:311,Class:InfoMember,Method:GetFollowers] More Info -> {SizeEx.Message}",TypeOfLog.exclamationcircle);
        //            KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(40, 200);

        //        }
        //        int Followers = 0;
        //        foreach (IWebElement itemm in KernalWeb.Driver.FindElements(By.TagName("a")))
        //        {
        //            if (itemm.Text != null && itemm.Text.Contains("followers"))
        //            {

        //                KernalWeb.Driver.ExecuteScript("window.scrollBy(0,240);");
        //                if (Followers == 0)
        //                {
        //                    if (observableCollectionCore.Count != 0)
        //                    {
        //                        Followers = observableCollectionCore.Count + int.Parse(itemm.FindElement(By.TagName("span")).GetAttribute("title").Replace(",", "").Replace("followers", ""));
        //                    }
        //                    else
        //                    {
        //                        Followers = int.Parse(itemm.FindElement(By.TagName("span")).GetAttribute("title").Replace(",", "").Replace("followers", ""));
        //                    }
        //                }
        //                itemm.Click();
        //                int counter = 1;
        //                Task.Run(() => {
        //                while (!Cancel)
        //                {

        //                        try
        //                        {
        //                            Thread.Sleep(100);
        //                    KernalWeb.Driver.ExecuteScript("window.scrollBy(0,500);");
        //                        }
        //                        catch (Exception)
        //                        {

        //                        }
        //                }
        //                });
        //                      while (true)
        //          {

        //                    Thread.Sleep(2000);
        //                    foreach (var itemtest in KernalWeb.Driver.FindElements(By.TagName("li")))
        //                    {
        //                        bool IsDivIncludeDiv = false;
        //                        try
        //                        {
        //                            var Follower_name = "";
        //                            try
        //                            {
        //                                 Follower_name = KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/li[{0}]/div/div[1]/div/div[1]/a", counter))).GetAttribute("title");
        //                                LoggerViewModel.Log(Follower_name, TypeOfLog.exclamationcircle);
        //                                IsDivIncludeDiv = false;

        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                LoggerViewModel.Log(ex.Message,TypeOfLog.exclamationcircle);
        //                                 Follower_name = KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/div/li[{0}]/div/div[1]/div/div[1]/a", counter))).GetAttribute("title");
        //                                LoggerViewModel.Log(Follower_name, TypeOfLog.exclamationcircle);
        //                                IsDivIncludeDiv = true;
        //                            }

        //                            if (!Follower_name.Contains(_username.Substring(0, _username.IndexOf(_username.Contains("@") ? '@' : _username.Substring(0, _username.Length)[1]))))
        //                            {
        //                                if (Followers != 0 && observableCollectionCore.Count == Followers || Followers != 0 && counter == Followers)
        //                                {
        //                                    break;
        //                                }
        //                                if (Cancel)
        //                                {
        //                                    break;
        //                                }
        //                                Application.Current.Dispatcher.Invoke(() =>
        //                                {
        //                                    try
        //                                    {
        //                                        if (!IsDivIncludeDiv)
        //                                        {
        //                                        LoggerViewModel.Log($"Count ==> {KernalWeb.Driver.FindElements(By.TagName("li")).Count}", TypeOfLog.Warning);
        //                                        CollectionsHelper.Followers.Add(new AccountOperations()
        //                                        {
        //                                            Uid = KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/li[{0}]/div/div[1]/a", counter))).GetAttribute("href"),
        //                                            Username = KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/li[{0}]/div/div[1]/div/div[1]/a", counter))).GetAttribute("title"),
        //                                            IsFollower = (KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/li[{0}]/div/div[2]/span/button", counter))).Text == "Follow") ? TypeOfResponse.Follow :
        //                                                                                    (KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/li[{0}]/div/div[2]/span/button", counter))).Text == "Following") ? TypeOfResponse.Following : TypeOfResponse.Requested
        //                                                                                    ,
        //                                            UnFollow_FollowCommand = new BaseCommand(act_)
        //                                                                                    ,
        //                                            FollowAll = modelLogin_.FollowAll
        //                                                                                    ,
        //                                            FollowWhohasFollowingFrom_To = modelLogin_.FollowWhohasFollowingFrom_To
        //                                                                                    ,
        //                                            IsFollowWIthCondition = modelLogin_.IsFollowWIthCondition
        //                                                                                    ,
        //                                            From = modelLogin_.From
        //                                                                                    ,
        //                                            To = modelLogin_.To
        //                                        });

        //                                        }
        //                                        else
        //                                        {
        //                                            LoggerViewModel.Log($"Count ==> {KernalWeb.Driver.FindElements(By.TagName("li")).Count}", TypeOfLog.Warning);
        //                                            Task.Run(() => {

        //                                            for (int i = 0; i < Followers; i++)
        //                                            {
        //                                                LoggerViewModel.Log($"Count Of I ==> {i}", TypeOfLog.Warning);
        //                                                LoggerViewModel.Log($"Current Account ({KernalWeb.Driver.FindElements(By.TagName("li"))[i].GetAttribute("title")})", TypeOfLog.check);
        //                                                    Thread.Sleep(100);
        //                                            }
        //                                            });
        //                                            CollectionsHelper.Followers.Add(new AccountOperations()
        //                                            {
        //                                                Uid = KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/div/li[{0}]/div/div[1]/a", counter))).GetAttribute("href"),
        //                                                Username = KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/div/li[{0}]/div/div[1]/div/div[1]/a", counter))).GetAttribute("title"),
        //                                                IsFollower = (KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/div/li[{0}]/div/div[2]/span/button", counter))).Text == "Follow") ? TypeOfResponse.Follow :
        //                                                                                 (KernalWeb.Driver.FindElement(By.XPath(String.Format("//*[@id='react-root']/section/main/ul/div/li[{0}]/div/div[2]/span/button", counter))).Text == "Following") ? TypeOfResponse.Following : TypeOfResponse.Requested
        //                                                                                 ,
        //                                                UnFollow_FollowCommand = new BaseCommand(act_)
        //                                                                                 ,
        //                                                FollowAll = modelLogin_.FollowAll
        //                                                                                 ,
        //                                                FollowWhohasFollowingFrom_To = modelLogin_.FollowWhohasFollowingFrom_To
        //                                                                                 ,
        //                                                IsFollowWIthCondition = modelLogin_.IsFollowWIthCondition
        //                                                                                 ,
        //                                                From = modelLogin_.From
        //                                                                                 ,
        //                                                To = modelLogin_.To
        //                                            });
        //                                        }
        //                                        //التركيز على اخر عنصر دخل المجموعة
        //                                        SelectedItem_.Login = observableCollectionCore[observableCollectionCore.Count - 1];
        //                                        LoggerViewModel.Log(string.Format("Follower Has been added ==> {0}", observableCollectionCore[observableCollectionCore.Count - 1].Username), TypeOfLog.questioncircle);
        //                                        LoggerViewModel.Log($"State: Counter({counter}) Followers({Followers}) Followers has already been added({CollectionsHelper.Followers.Count})", TypeOfLog.questioncircle);

        //                                        if (observableCollectionCore[observableCollectionCore.Count - 1].IsFollower == TypeOfResponse.Follow)
        //                                        {
        //                                            Indexer.Add(observableCollectionCore.Count - 1);
        //                                            modelLogin_.AmountOfFollowers++;
        //                                        }
        //                                        else if (observableCollectionCore[observableCollectionCore.Count - 1].IsFollower == TypeOfResponse.Following)
        //                                        {
        //                                            modelLogin_.AmountOfFollowing++;
        //                                        }
        //                                        else if (observableCollectionCore[observableCollectionCore.Count - 1].IsFollower == TypeOfResponse.Requested)
        //                                        {
        //                                            modelLogin_.AmountOfRequested++;
        //                                        }
        //                                        modelLogin_.Amount = observableCollectionCore.Count;
        //                                    }
        //                                    catch(Exception ex)
        //                                    {
        //                                        LoggerViewModel.Log($"Error [Line:402,Class:InfoMember,Method:GetFollowers More Info -> {ex.Message}]", TypeOfLog.Warning);
        //                                    }

        //                                });

        //                                counter++;
        //                            }
        //                            else if (!isRepeated&&Follower_name.Contains(_username.Substring(0, _username.IndexOf(_username.Contains("@") ? '@' : _username.Substring(0, _username.Length)[1]))))
        //                            {

        //                                    counter++;
        //                                    Followers += -1;
        //                                    isRepeated = true;
        //                                LoggerViewModel.Log($"State: Counter({counter}) Followers({Followers}) Followers has already been added({CollectionsHelper.Followers.Count})",TypeOfLog.questioncircle);



        //                            }
        //                        }
        //                        catch (Exception)
        //                        {
        //                            break;
        //                        }
        //                    }
        //                    try
        //                    {
        //                        if (observableCollectionCore.Count == Followers || isRepeated && observableCollectionCore.Count == Followers - 1 || counter == Followers)
        //                        {
        //                            LoggerViewModel.Log($"State: Counter({counter}) Followers({Followers}) Followers has already been added({CollectionsHelper.Followers.Count})", TypeOfLog.questioncircle);

        //                            break;
        //                        }
        //                    }
        //                    catch (Exception)
        //                    {


        //                    }
        //                    if (Cancel)
        //                    {
        //                        break;
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        LoggerViewModel.Log($"State:-", TypeOfLog.questioncircle);

        //        return;
        //    }

        //}

        #endregion

        public string GetFollowing()
        {
            Operations.CurrentOT = OperationsTypes.GetCurrentFollwings;
            string b = "";
            foreach (IWebElement itemm in KernalWeb.Driver.FindElements(By.TagName("a")))
            {
                if (itemm.Text != null && itemm.Text.Contains("following"))
                {
                    b = itemm.Text.Replace("following", "");
                    break;

                }

            }
            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
            return b;
        }

        public string Getname(string optionalname = null)
        {
            Operations.CurrentOT = OperationsTypes.GetCurrentName;
            string b = "";
            foreach (IWebElement itemm in KernalWeb.Driver.FindElements(By.TagName("h1")))
            {
                if (itemm.Text != null && itemm.Text.Contains((string.IsNullOrWhiteSpace(optionalname)) ? _username.Substring(0, 5)[0] : optionalname.Substring(0, optionalname.Length)[0]))
                {
                    b = itemm.Text;
                    break;

                }

            }
            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
            return b;
        }



    }
}
