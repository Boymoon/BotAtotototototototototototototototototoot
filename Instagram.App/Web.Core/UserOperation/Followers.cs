using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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


            var Service = ChromeDriverService.CreateDefaultService();
            Service.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("--user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25");
            options.AddArgument("--headless");

            using (var TestDriver = new ChromeDriver(Service, options))
            {
                TestDriver.Navigate().GoToUrl(uid);
                ReadOnlyCollection<OpenQA.Selenium.Cookie> cookie = new ReadOnlyCollection<OpenQA.Selenium.Cookie>(KernalWeb.Driver.Manage().Cookies.AllCookies);
                for (int i = 0; i < cookie.Count; i++)
                {
                    TestDriver.Manage().Cookies.AddCookie(cookie[i]);
                }
                Operations.CurrentOT = OperationsTypes.GetFollowers;
                AccountOperations LastItem = null;
                int Followers = 0;
                try
                {
                    TestDriver.Navigate().Refresh();
                    ///مقارنة في حجم الكولكشن قبل عملية الاضافة وبعد
                    int checkerForCountFollowerCollection = 0;
                    Cancel = false;
                    /*  في حالة ان المستخدم يريد جلب  متابعيه */
                    bool self = false;
                    /* في حالة ان المستخدم يريد جلب  متابعين حساب  هو من متابعيه */
                    bool IsFollowing = false;
                    bool isRepeated = false;
                    #region Settings
                    /* تأكد من حالة  الحساب  */
                    if (TestDriver.FindElement(By.ClassName("_ov9ai")).FindElement(By.TagName("button")).Text.ToLower().Contains("edit"))
                    {
                        self = true;
                    }
                    else
                    {
                        self = false;
                        if (TestDriver.FindElement(By.ClassName("_ov9ai")).FindElement(By.TagName("button")).Text.ToLower().Contains("requested")
                            ||
                            TestDriver.FindElement(By.ClassName("_ov9ai")).FindElement(By.TagName("button")).Text.ToLower().Contains("following"))
                        {
                            IsFollowing = true;
                        }
                        else
                        {
                            IsFollowing = false;
                        }
                    }
                    TestDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
                    TestDriver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 5);
                    #endregion
                    try
                    {
                        TestDriver.Manage().Window.Size = new System.Drawing.Size(550, 600);

                    }
                    catch (Exception SizeEX)
                    {
                        LoggerViewModel.Log($"SizeEX Class:Followers,Method:GetFollowers {SizeEX.Message}", TypeOfLog.exclamationcircle);
                    }
                    foreach (var item in TestDriver.FindElements(By.TagName("a")))
                    {
                        SessionId sessionId = ((IHasSessionId)TestDriver).SessionId;
                        Screenshot sgca = ((ITakesScreenshot)TestDriver).GetScreenshot();
                        sgca.SaveAsFile("sasfgc.png", ScreenshotImageFormat.Png);

                        if (item.Text != null && item.Text.Contains("followers"))
                        {

                            Screenshot sgc = ((ITakesScreenshot)TestDriver).GetScreenshot();
                            sgc.SaveAsFile("sasfgc.png", ScreenshotImageFormat.Png);
                            TestDriver.ExecuteScript("window.scrollBy(0,240);");


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

                            OpenQA.Selenium.Interactions.Actions a = new OpenQA.Selenium.Interactions.Actions(TestDriver);
                            a.MoveToElement(item).DoubleClick().Perform();
                            Screenshot sgac = ((ITakesScreenshot)TestDriver).GetScreenshot();
                            sgac.SaveAsFile("atest.png", ScreenshotImageFormat.Png);
                            SessionId sessionId_ = ((IHasSessionId)TestDriver).SessionId;
                            LoggerViewModel.Log($"S1 ID:{sessionId} S2 ID:{sessionId_}", TypeOfLog.questioncircle);
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
                                            TestDriver.ExecuteScript("window.scrollBy(0,500);");
                                            if (i == 4)
                                            {
                                                Thread.Sleep(500);
                                                i = 0;
                                            }
                                            if (Cancel)
                                            {
                                                //  TestDriver.Manage().Window.Size = new System.Drawing.Size(1200, 1200);
                                                // TestDriver.Navigate().GoToUrl(uid);
                                                // TestDriver.ExecuteScript("window.scrollBy(0,-5000);");
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
                                            Follower_name = TestDriver.FindElements(By.TagName("a"))[counter_names].GetAttribute("title");
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
                                            //       TestDriver.Manage().Window.Size = new System.Drawing.Size(1200, 1200);
                                            //     TestDriver.Navigate().GoToUrl(uid);
                                            TestDriver.ExecuteScript("window.scrollBy(0,-5000);");
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
                                                        Username = TestDriver.FindElements(By.TagName("li"))[counter].FindElements(By.TagName("a"))[1].GetAttribute("title")
                                                        ,
                                                        Uid = TestDriver.FindElements(By.TagName("li"))[counter].FindElements(By.TagName("a"))[1].GetAttribute("href")
                                                        ,
                                                        IsFollower = (TestDriver.FindElements(By.ClassName("_ov9ai"))[counter].FindElement(By.TagName("button")).Text == "Follow") ? TypeOfResponse.Follow :
                                                                     (TestDriver.FindElements(By.ClassName("_ov9ai"))[counter].FindElement(By.TagName("button")).Text == "Following") ? TypeOfResponse.Following : TypeOfResponse.Requested
                                                    };

                                                    /* ------- */
                                                    obs.Add(TempModel);
                                                    LastItem = obs[obs.Count - 1];
                                                    //CollectionsHelper.CheckRepeated(obs[obs.Count - 1]);

                                                }

                                            }
                                            catch (Exception WhileAdding)
                                            {
                                                var TempModel = new AccountOperations()
                                                {
                                                    Username = TestDriver.FindElements(By.TagName("li"))[counter].FindElement(By.ClassName("_2g7d5")).GetAttribute("title")
                                                    ,
                                                    Uid = TestDriver.FindElements(By.TagName("li"))[counter].FindElement(By.ClassName("_2g7d5")).GetAttribute("href")
                                                    ,
                                                    IsFollower = (TestDriver.FindElements(By.ClassName("_ov9ai"))[counter - 1].FindElement(By.TagName("button")).Text == "Follow") ? TypeOfResponse.Follow :
                                                                 (TestDriver.FindElements(By.ClassName("_ov9ai"))[counter - 1].FindElement(By.TagName("button")).Text == "Following") ? TypeOfResponse.Following : TypeOfResponse.Requested
                                                };
                                                /* ------- */
                                                obs.Add(TempModel);
                                                LastItem = obs[obs.Count - 1];

                                            }

                                        });

                                        SelectedItem_.Login = obs[obs.Count - 1];
                                        Thread.Sleep(40);
                                        if (checkerForCountFollowerCollection != obs.Count)
                                        {
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
                                        }


                                        checkerForCountFollowerCollection = obs.Count;
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
                                    //          TestDriver.Manage().Window.Size = new System.Drawing.Size(1200, 1200);
                                    //TestDriver.Navigate().GoToUrl(uid);
                                    // TestDriver.ExecuteScript("window.scrollBy(0,-5000);");
                                    break;
                                }
                            }
                            catch (Exception)
                            {
                            }
                            if (Cancel)
                            {
                                //    TestDriver.Manage().Window.Size = new System.Drawing.Size(900, 900);
                                //  TestDriver.Navigate().GoToUrl(uid);
                                //TestDriver.ExecuteScript("window.scrollBy(0,-5000);");
                                break;
                            }
                        }
                    }

                }
                catch (Exception Ex_Unkown)
                {
                    LoggerViewModel.Log("There's something wrong please if this message show's up again contact with the developer to look at this issue", TypeOfLog.Warning);
                    TestDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);
                    TestDriver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
                    LoggerViewModel.Log($"State:-", TypeOfLog.questioncircle);
                    Cancel = true;
                    //   TestDriver.Manage().Window.Size = new System.Drawing.Size(900, 900);
                    // TestDriver.Navigate().GoToUrl(uid);
                    //TestDriver.ExecuteScript("window.scrollBy(0,-5000);");
                    LoggerViewModel.Log($"State:-Finish- [Followers ({obs.Count})  Total Of Followers ({Followers})]", TypeOfLog.check);
                    Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                    return;
                }

            }
        }

        public void GetFollows(AccountOperations modelLogin_, string uid, ObservableCollection<AccountOperations> obs, ObservableCollection<int> Indexer, LoginViewModel SelectedItem_ = null)
        {
            var user = new User(uid);
            var Current_Cookie = KernalWeb.GetCookie();
            var command_text = @"https://www.instagram.com/graphql/query/?query_id=17851374694183129&variables={""id"":" + user.id + @",""first"":" + user.followed_by + "}";
            HttpWebRequest webRequest = ((HttpWebRequest)WebRequest.Create(command_text));
            webRequest.CookieContainer = Current_Cookie;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
            webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            webRequest.ContentType = "application/x-www-form-urlencoded";
            var resp = (WebResponse)webRequest.GetResponse();
            var reader = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            JObject jObject = JObject.Parse(reader.ReadToEnd());
            var User = new List<string[]>();
            User = new List<string[]>();
            modelLogin_.ContentbtnLoading = "جاري جلب المتابعين";
            for (int i = 0; i < int.Parse(user.followed_by) && !Cancel; i++)
            {
                try
                {
                    User.Add(new string[] {
                /* 0 */      (string)jObject["data"]["user"]["edge_followed_by"]["edges"][i]["node"]["id"],
                /* 1 */      (string)jObject["data"]["user"]["edge_followed_by"]["edges"][i]["node"]["username"],
                /* 2 */      (string)jObject["data"]["user"]["edge_followed_by"]["edges"][i]["node"]["full_name"],
                /* 3 */      (string)jObject["data"]["user"]["edge_followed_by"]["edges"][i]["node"]["profile_pic_url"],
                /* 4 */      ((bool)jObject["data"]["user"]["edge_followed_by"]["edges"][i]["node"]["followed_by_viewer"]).ToString(),
                /* 5 */      ((bool)jObject["data"]["user"]["edge_followed_by"]["edges"][i]["node"]["requested_by_viewer"]).ToString(),
                /* 6 */     $"https://www.instagram.com/{(string)jObject["data"]["user"]["edge_followed_by"]["edges"][i]["node"]["username"]}"
                });
                    var temp = new AccountOperations()
                    {
                        Username = (string)jObject["data"]["user"]["edge_followed_by"]["edges"][i]["node"]["username"],
                        IsFollower = (User[i][5] == "False" && User[i][4] == "False") ? TypeOfResponse.Follow :
                        (User[i][4].ToLower() == "true" && User[i][5].ToLower() == "false") ? TypeOfResponse.Following : TypeOfResponse.Requested,
                        Uid = User[i][6]
                    };
                    Application.Current.Dispatcher.Invoke(() => { obs.Add(temp);
                        if (temp.IsFollower == TypeOfResponse.Follow)
                        {
                            if (temp.FollowAll)
                            {
                                Indexer.Add(obs.Count - 1);
                            }
                            modelLogin_.AmountOfFollowers++;
                        }
                        else if (temp.IsFollower == TypeOfResponse.Following)
                        {
                            if (modelLogin_.UnFollowAll)
                            {
                                Indexer.Add(obs.Count - 1);
                            }
                            modelLogin_.AmountOfFollowing++;
                        }
                        else if (temp.IsFollower == TypeOfResponse.Requested)
                        {
                            if (modelLogin_.UnFollowAll)
                            {
                                Indexer.Add(obs.Count - 1);
                            }
                            modelLogin_.AmountOfRequested++;
                        }
                        modelLogin_.Amount = obs.Count;
                    });
                    CollectionsHelper.CheckRepeated(obs,obs[obs.Count - 1]);
                    SelectedItem_.Login = obs[obs.Count - 1];

               
                    LoggerViewModel.Log($"{User[i][0]} | {User[i][1]} | {User[i][2]}", TypeOfLog.questioncircle);
                }
                catch (Exception ex_)
                {
                    if (ex_.Message.ToLower().Contains(("Index was out of range").ToLower()))
                    {
                        break;
                    }
                }

            }
            reader.Close();
        }
        public void GetFollowings(AccountOperations modelLogin_, string uid, ObservableCollection<AccountOperations> obs, ObservableCollection<int> Indexer, LoginViewModel SelectedItem_ = null)
        {
            var user = new User(uid);
            var Current_Cookie = KernalWeb.GetCookie();
            var command_text = @"https://www.instagram.com/graphql/query/?query_id=17874545323001329&variables={""id"":" + user.id + @",""first"":" + user.follows + "}";
            
            HttpWebRequest webRequest = ((HttpWebRequest)WebRequest.Create(command_text));
            webRequest.CookieContainer = Current_Cookie;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
            webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            webRequest.ContentType = "application/x-www-form-urlencoded";
            var resp = (WebResponse)webRequest.GetResponse();
            var reader = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            JObject jObject = JObject.Parse(reader.ReadToEnd());
            var User = new List<string[]>();
            User = new List<string[]>();
            modelLogin_.ContentbtnLoading = "جاري جلب المتابعون";
            for (int i = 0; i < int.Parse(user.follows) && !Cancel; i++)
            {
                try
                {
                    User.Add(new string[] {
                /* 0 */      (string)jObject["data"]["user"]["edge_follow"]["edges"][i]["node"]["id"],
                /* 1 */      (string)jObject["data"]["user"]["edge_follow"]["edges"][i]["node"]["username"],
                /* 2 */      (string)jObject["data"]["user"]["edge_follow"]["edges"][i]["node"]["full_name"],
                /* 3 */      (string)jObject["data"]["user"]["edge_follow"]["edges"][i]["node"]["profile_pic_url"],
                /* 4 */      ((bool)jObject["data"]["user"]["edge_follow"]["edges"][i]["node"]["followed_by_viewer"]).ToString(),
                /* 5 */      ((bool)jObject["data"]["user"]["edge_follow"]["edges"][i]["node"]["requested_by_viewer"]).ToString(),
                /* 6 */     $"https://www.instagram.com/{(string)jObject["data"]["user"]["edge_follow"]["edges"][i]["node"]["username"]}"
                });
                    var temp = new AccountOperations()
                    {
                        Username = (string)jObject["data"]["user"]["edge_follow"]["edges"][i]["node"]["username"],
                        IsFollower = (User[i][5] == "False" && User[i][4] == "False") ? TypeOfResponse.Follow :
                        (User[i][4].ToLower() == "true" && User[i][5].ToLower() == "false") ? TypeOfResponse.Following : TypeOfResponse.Requested,
                        Uid = User[i][6]
                    };
                    Application.Current.Dispatcher.Invoke(() => { obs.Add(temp);

                        if (temp.IsFollower == TypeOfResponse.Follow)
                        {
                            if (temp.FollowAll)
                            {
                                Indexer.Add(obs.Count - 1);
                            }
                            modelLogin_.AmountOfFollowers++;
                        }
                        else if (temp.IsFollower == TypeOfResponse.Following)
                        {
                            if (modelLogin_.UnFollowAll)
                            {
                                Indexer.Add(obs.Count - 1);
                            }
                            modelLogin_.AmountOfFollowing++;
                        }
                        else if (temp.IsFollower == TypeOfResponse.Requested)
                        {
                            if (modelLogin_.UnFollowAll)
                            {
                                Indexer.Add(obs.Count - 1);
                            }
                            modelLogin_.AmountOfRequested++;
                        }
                        modelLogin_.Amount = obs.Count;
                    });
                    CollectionsHelper.CheckRepeated(obs,obs[obs.Count - 1]);
                    SelectedItem_.Login = obs[obs.Count - 1];


                    LoggerViewModel.Log($"{User[i][0]} | {User[i][1]} | {User[i][2]}", TypeOfLog.questioncircle);
                }
                catch (Exception ex_)
                {
                    if (ex_.Message.ToLower().Contains(("Index was out of range").ToLower()))
                    {
                        break;
                    }
                }

            }
            reader.Close();
        }

    }
}
