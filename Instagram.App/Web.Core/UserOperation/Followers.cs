using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Instagram.App
{
    /// <summary>
    /// فئة للتعامل  مع المتابعين والمتابعون وعملياتهم
    /// </summary>
    public class Followers
    {
        public static bool Cancel = false;
        string name_ = "";
        public Followers(string CurrentID)
        {
            name_ = CurrentID;
        }
        /// <summary>
        /// جلب المتابعين
        /// </summary>
        public void GetFollowers(AccountOperations modelLogin_, string uid, ObservableCollection<AccountOperations> obs, ObservableCollection<int> Indexer, LoginViewModel SelectedItem_ = null)
        {
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(name_))
            {
                return;
            }
            CollectionsHelper.NameOfSelectedTableOfFollowers = "testtabe";
            Operations.CurrentOT = OperationsTypes.GetFollowers;
            AccountOperations LastItem=null;
            int Followers = 0;
            try
            {
                Cancel = false;
                /*  في حالة ان المستخدم يريد جلب  متابعيه */
                bool self = false;
                /* في حالة ان المستخدم يريد جلب  متابعين حساب  هو من متابعيه */
                bool IsFollowing = false;
                bool isRepeated = false;
                #region Settings
                KernalWeb.Driver.Navigate().GoToUrl(uid);
                /* تأكد من حالة  الحساب  */
                if (KernalWeb.Driver.FindElement(By.ClassName("_ov9ai")).FindElement(By.TagName("button")).Text.ToLower().Contains("edit"))
                {
                    self = true;
                }
                else
                {
                    self = false;
                    if (KernalWeb.Driver.FindElement(By.ClassName("_ov9ai")).FindElement(By.TagName("button")).Text.ToLower().Contains("requested")
                        ||
                        KernalWeb.Driver.FindElement(By.ClassName("_ov9ai")).FindElement(By.TagName("button")).Text.ToLower().Contains("following"))
                    {
                        IsFollowing = true;
                    }
                    else
                    {
                        IsFollowing = false;
                    }
                }
                KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
                KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 5);
                #endregion
                try
                {
                    KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(5, 400);
                }
                catch (Exception SizeEX)
                {
                    LoggerViewModel.Log($"SizeEX Class:Followers,Method:GetFollowers {SizeEX.Message}", TypeOfLog.exclamationcircle);
                }
                foreach (var item in KernalWeb.Driver.FindElements(By.TagName("a")))
                {
                    if (item.Text != null && item.Text.Contains("followers"))
                    {
                        KernalWeb.Driver.ExecuteScript("window.scrollBy(0,240);");
                        if (Followers == 0)
                        {
                            if (obs.Count > 0)
                            {
                                Followers = obs.Count + int.Parse(item.FindElement(By.TagName("span")).GetAttribute("title").Replace(",", "").Replace("followers", ""));
                            }
                            else
                            {
                                Followers = int.Parse(item.FindElement(By.TagName("span")).GetAttribute("title").Replace(",", "").Replace("followers", ""));
                            }
                        }
                        item.Click();
                        Thread.Sleep(1000);
                        int counter = 0;
                        int counter_names = 1;
                        /* بحاجة للمراجعة */
                        Task.Run(() =>
                        {
                            while (!Cancel)
                            {
                                try
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        KernalWeb.Driver.ExecuteScript("window.scrollBy(0,500);");
                                        if (i == 4)
                                        {
                                            Thread.Sleep(500);
                                            i = 0;
                                        }
                                        if (Cancel)
                                        {
                                            KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(900, 900);
                                            KernalWeb.Driver.Navigate().GoToUrl(uid);
                                            KernalWeb.Driver.ExecuteScript("window.scrollBy(0,-5000);");
                                            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                            break;
                                        }
                                    }
                                }
                                catch (Exception _Ex_Normal)
                                {


                                }
                            }

                        });
                        modelLogin_.ContentbtnLoading = "جاري جلب المتابعين";
                        while (!Cancel)
                        {
                            try
                            {
                                var Follower_name = "";
                                if (!self && IsFollowing)
                                {
                                    try
                                    {
                                        Follower_name = KernalWeb.Driver.FindElements(By.TagName("a"))[counter_names].GetAttribute("title");
                                    }
                                    catch (Exception Ex_GetName)
                                    {
                                        LoggerViewModel.Log($"Getting Error While trying to get Name {Ex_GetName.Message}", TypeOfLog.exclamationcircle);
                                    }
                                }
                                if (self || !Follower_name.Contains(name_.Substring(0, name_.IndexOf(name_.Contains("@") ? '@' : name_.Substring(0, name_.Length)[1]))))
                                {
                                    if (Followers > 0 && obs.Count == Followers || Followers > 0 && isRepeated && IsFollowing && obs.Count == Followers - 1 || Followers > 0 && counter == Followers)
                                    {
                                        Cancel = true;
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(900, 900);
                                        KernalWeb.Driver.Navigate().GoToUrl(uid);
                                        KernalWeb.Driver.ExecuteScript("window.scrollBy(0,-5000);");
                                        LoggerViewModel.Log("State:Finish", TypeOfLog.check);
                                        break;
                                    }
                                    Application.Current.Dispatcher.Invoke(() =>
                                    {
                                        try
                                        {
                                        if (!Cancel)
                                        {
                                            var TempModel = new AccountOperations()
                                            {
                                                Username = KernalWeb.Driver.FindElements(By.TagName("li"))[counter].FindElements(By.TagName("a"))[1].GetAttribute("title")
                                                ,
                                                Uid = KernalWeb.Driver.FindElements(By.TagName("li"))[counter].FindElements(By.TagName("a"))[1].GetAttribute("href")
                                                ,
                                                IsFollower = (KernalWeb.Driver.FindElements(By.ClassName("_ov9ai"))[counter].FindElement(By.TagName("button")).Text == "Follow") ? TypeOfResponse.Follow :
                                                             (KernalWeb.Driver.FindElements(By.ClassName("_ov9ai"))[counter].FindElement(By.TagName("button")).Text == "Following") ? TypeOfResponse.Following : TypeOfResponse.Requested
                                            };

                                                /* ------- */

                                                CollectionsHelper.Followers.Add(TempModel);
                                                LastItem = obs[obs.Count - 1];
                                                CollectionsHelper.CheckRepeated(CollectionsHelper.Followers[CollectionsHelper.Followers.Count-1]);
                                            }

                                        }
                                        catch (Exception WhileAdding)
                                        {
                                            var TempModel = new AccountOperations()
                                            {
                                                Username = KernalWeb.Driver.FindElements(By.TagName("li"))[counter].FindElement(By.ClassName("_2g7d5")).GetAttribute("title")
                                                ,
                                                Uid = KernalWeb.Driver.FindElements(By.TagName("li"))[counter].FindElement(By.ClassName("_2g7d5")).GetAttribute("href")
                                                ,
                                                IsFollower = (KernalWeb.Driver.FindElements(By.ClassName("_ov9ai"))[counter - 1].FindElement(By.TagName("button")).Text == "Follow") ? TypeOfResponse.Follow :
                                                             (KernalWeb.Driver.FindElements(By.ClassName("_ov9ai"))[counter - 1].FindElement(By.TagName("button")).Text == "Following") ? TypeOfResponse.Following : TypeOfResponse.Requested
                                            };
                                            /* ------- */

                                            CollectionsHelper.Followers.Add(TempModel);
                                            LastItem = obs[obs.Count - 1];
                                            CollectionsHelper.CheckRepeated(CollectionsHelper.Followers[CollectionsHelper.Followers.Count - 1]);

                                        }

                                    });

                                    SelectedItem_.Login = obs[obs.Count - 1];
                                    Thread.Sleep(40);
                                 
                                    if (LastItem.IsFollower == TypeOfResponse.Follow)
                                    {
                                        if (modelLogin_.FollowAll)
                                        {
                                        Indexer.Add(obs.Count - 1);
                                        }
                                        modelLogin_.AmountOfFollowers++;
                                    }
                                    else if (LastItem.IsFollower == TypeOfResponse.Following)
                                    {
                                        if (modelLogin_.UnFollowAll)
                                        {
                                            Indexer.Add(obs.Count - 1);
                                        }
                                        modelLogin_.AmountOfFollowing++;
                                    }
                                    else if (LastItem.IsFollower == TypeOfResponse.Requested)
                                    {
                                        if (modelLogin_.UnFollowAll)
                                        {
                                            Indexer.Add(obs.Count - 1);
                                        }
                                        modelLogin_.AmountOfRequested++;
                                    }
                                    modelLogin_.Amount = obs.Count;


                                    counter++;
                                    counter_names += 2;
                                }
                                else if (!self && !isRepeated && Follower_name.Contains(name_.Substring(0, name_.IndexOf(name_.Contains("@") ? '@' : name_.Substring(0, name_.Length)[1]))))
                                {

                                    counter++;
                                    counter_names += 2;
                                    Follower_name = "";
                                    isRepeated = true;
                                    LoggerViewModel.Log($"State: Counter({counter}) Followers({Followers}) Followers has already been added({CollectionsHelper.Followers.Count})", TypeOfLog.questioncircle);
                                }
                            }

                            catch (Exception ex) { break; }
                        }
                        try
                        {
                            if (obs.Count == Followers || isRepeated && IsFollowing && obs.Count == Followers - 1 || counter == Followers)
                            {
                                LoggerViewModel.Log($"State:-Finish- Counter({counter}) Followers({Followers}) Followers has already been added({CollectionsHelper.Followers.Count})", TypeOfLog.check);
                                Cancel = true;
                                KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(900, 900);
                                KernalWeb.Driver.Navigate().GoToUrl(uid);
                                KernalWeb.Driver.ExecuteScript("window.scrollBy(0,-5000);");
                                break;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        if (Cancel)
                        {
                            KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(900, 900);
                            KernalWeb.Driver.Navigate().GoToUrl(uid);
                            KernalWeb.Driver.ExecuteScript("window.scrollBy(0,-5000);");
                            break;
                        }
                    }
                }

            }
            catch (Exception Ex_Unkown)
            {
                LoggerViewModel.Log($"State:-", TypeOfLog.questioncircle);
                Cancel = true;
                KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(900, 900);
                KernalWeb.Driver.Navigate().GoToUrl(uid);
                KernalWeb.Driver.ExecuteScript("window.scrollBy(0,-5000);");
                KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);
                KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
                LoggerViewModel.Log($"State:-Finish- [Followers ({obs.Count})  Total Of Followers ({Followers})]", TypeOfLog.check);
                Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                return;
            }
        }
    }
}
