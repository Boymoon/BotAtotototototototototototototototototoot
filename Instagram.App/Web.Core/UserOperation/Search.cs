using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;

namespace Instagram.App
{
    public class Search
    {
        public bool canceled = false;
        private ModelSearch CurrentModel;
        public Search(ModelSearch _modelSearch)
        {
            if (_modelSearch != null)
            {
                CurrentModel = _modelSearch;
            }
        }
        /// <summary>
        /// بحث بالموقع
        /// </summary>
        public string FindByLocation()
        {
            Operations.CurrentOT = OperationsTypes.DoSearchUsingLocation;
            string url = "";
            var web = KernalWeb.Driver;
            web.Navigate().GoToUrl("https://www.instagram.com/explore/");
            foreach (var item in web.FindElements(By.TagName("span")))
            {
                if (item.Text != null & item.Text == "Search")
                {
                    item.Click();
                    foreach (var GetSearch in KernalWeb.Driver.FindElements(By.TagName("input")))
                    {
                        if (GetSearch.GetAttribute("placeholder") == "Search")
                        {
                            GetSearch.SendKeys(CurrentModel.Text);

                        }

                    }
                }
            }
            Thread.Sleep(4000);
            foreach (var item in KernalWeb.Driver.FindElements(By.ClassName("_gimca")))
            {
                var attr = item.GetAttribute("href");
                url = attr;
                break;
            }
            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
            return url;
        }
        /// <summary>
        /// بحث بالتاق
        /// </summary>
        public string FindByTag()
        {
            Operations.CurrentOT = OperationsTypes.DoSearchUsingHastag;
            string url = "";
            var web = KernalWeb.Driver;
            KernalWeb.Driver.Navigate().GoToUrl($"https://www.instagram.com/explore/tags/{CurrentModel.Text.Replace("#", "")}");
            url = $"https://www.instagram.com/explore/tags/{CurrentModel.Text.Replace("#", "")}";
            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
            return url;
        }
        /// <summary>
        /// جلب اعلى المنشورات اعجاباً او نشاطاً
        /// </summary>
        /// <param name="Post">قائمة لتخزين المنشورات</param>
        public void GetTopPosts(ObservableCollection<ModelPost> Post, string url_, CancellationTokenSource cts)
        {
            Operations.CurrentOT = OperationsTypes.GetPosts;
            try
            {
                if (!string.IsNullOrEmpty(url_))
                {
                    KernalWeb.Driver.Navigate().GoToUrl(url_);
                    Thread.Sleep(5 * 1000);
                }
            }
            catch (Exception) { }
            int range__ = -1;

            try
            {



                Task.Run(() =>
                {
                    while (!canceled)
                    {
                        try
                        {
                            Thread.Sleep(3000);
                            KernalWeb.Driver.ExecuteScript("scrollBy(0,1200);");
                        }
                        catch (Exception ex) { }
                    }
                });


                var Views = "-";
                var Likes = "-";
                var context = "null";
                var Publisher = "null";
                var UidofPublisher = "null";
                var Uidofpost = "null";
                var ContextMedia = "null";
                var publishedAT = "null";
                while (!canceled)
                {
                    if (CurrentModel.IsMaximumEnabled && Post.Count == CurrentModel.MaximumPosts)
                    {
                        cts.Cancel();
                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                        return;
                    }
                    range__++;
                    try
                    {
                        if (range__ == 9)
                        {
                            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                            return;
                        }
                        Thread.Sleep(1000);
                        KernalWeb.Driver.ExecuteScript($"document.getElementsByTagName('a')[{range__}].click();");
                        try
                        {
                            Thread.Sleep(1000);
                            Uidofpost = KernalWeb.Driver.FindElements(By.TagName("a"))[range__].GetAttribute("href");
                        }
                        catch (Exception) { }
                        Thread.Sleep(2 * 1000);
                        if (KernalWeb.Driver.FindElement(By.TagName("h2")).Text.Contains("Sorry, this page isn't available."))
                        {

                            Console.WriteLine("problem has been found ");
                            KernalWeb.Driver.Navigate().GoToUrl(url_);
                            //dont leave until finish
                            GetTopPosts(Post, url_, cts);
                        }
                    }
                    catch (Exception ex) { }
                    //Get the current Post 
                    KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 1);
                    foreach (var CopyOfPost in KernalWeb.Driver.FindElements(By.TagName("article")))
                    {
                        Thread.Sleep(500);
                        if (CurrentModel.IsSleep)
                        {
                            try
                            {
                                Thread.Sleep(new Random()
                                    .Next(
                                    CurrentModel.from + 1,
                                    CurrentModel.To
                                    ) * 1000);
                            }
                            catch (Exception) { }
                        }
                        try
                        {
                            /* Time */
                            if (string.IsNullOrEmpty(publishedAT) || publishedAT == "null" && !string.IsNullOrEmpty(KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.TagName("time")).Text))
                            {
                                publishedAT = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.TagName("time")).Text;
                                if (CurrentModel.IsGetPosts)
                                {
                                    if (publishedAT.Contains("SECONDS"))
                                    {
                                        if (CurrentModel.unitOfGetPosts == "ثواني")
                                        {
                                            if (!(double.Parse(publishedAT.Replace("SECONDS AGO", "")) >= CurrentModel.fromOfGetPosts
                                               && double.Parse(publishedAT.Replace("SECONDS AGO", "")) <= CurrentModel.ToOfGetPosts))
                                            {
                                                break;

                                            }


                                        }

                                    }
                                    else if (publishedAT.Contains("MINUTES"))
                                    {
                                        if (CurrentModel.unitOfGetPosts == "دقائق")
                                        {
                                            if (!(double.Parse(publishedAT.Replace("MINUTES AGO", "")) >= CurrentModel.fromOfGetPosts
                                                && double.Parse(publishedAT.Replace("MINUTES AGO", "")) <= CurrentModel.ToOfGetPosts))
                                            {
                                                break;
                                            }

                                        }

                                    }
                                    else if (publishedAT.Contains("HOUR"))
                                    {
                                        if (CurrentModel.unitOfGetPosts == "ساعات")
                                        {
                                            if (!(double.Parse(publishedAT.Replace("HOURS AGO", "").Replace("HOUR AGO", "")) >= CurrentModel.fromOfGetPosts
                                                && double.Parse(publishedAT.Replace("HOURS AGO", "").Replace("HOUR AGO", "")) <= CurrentModel.ToOfGetPosts))
                                            {
                                                break;

                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            //اعجاب
                            if (CurrentModel.Like && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Text == "Like")
                            {
                                KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Click();
                                CurrentModel.CountOfLikes++;
                            }
                            //الغاء اعجاب
                            if (CurrentModel.UnLike && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Text == "Unlike")
                            {
                                KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Click();

                            }
                            if (!string.IsNullOrEmpty(KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.TagName("video")).GetAttribute("src")))
                            {
                                ContextMedia = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.TagName("video")).GetAttribute("src");
                                try
                                {
                                    if (KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("ul")).Count != 0)
                                    {
                                        context = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("ul"))[0].FindElement(By.TagName("span")).Text;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.Contains("no"))
                                    {
                                        context = "";
                                    }
                                }
                                try
                                {
                                    Views = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_m5zti")).Text.Replace("views", "");
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.Contains("_m5zti"))
                                    {
                                        Views = "0";
                                    }
                                }
                                try
                                {
                                    KernalWeb.Driver.ExecuteScript("document.getElementsByClassName('_m5zti')[0].click();");
                                    var LikesCount_ = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_m10kk")).Text;
                                    Thread.Sleep(1000);

                                    if (!LikesCount_.Contains("likes"))
                                    {
                                        Likes = LikesCount_.Replace("like", string.Empty);
                                    }
                                    else
                                    {
                                        Likes = LikesCount_.Replace("likes", string.Empty);
                                    }
                                }

                                catch (Exception ex)
                                {

                                    if (ex.Message.Contains("no"))
                                    {
                                        Likes = "0";
                                    }
                                }

                            }

                            foreach (var item in CopyOfPost.FindElements(By.TagName("a")))
                            {
                                try
                                {
                                    if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_nzn1h")).Text.Contains("likes"))
                                    {
                                        //get likes -1
                                        Likes = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_nzn1h")).Text.Replace("likes", "");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.Contains("_nzn1h"))
                                    {

                                        if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("this")
                                           && !KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                        {

                                            //get likes -2
                                            int counterlikes = 0;
                                            foreach (var GetLikes in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                            {
                                                counterlikes++;
                                            }
                                            Likes = counterlikes.ToString();

                                        }
                                        else if (KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                        {
                                            Likes = "0";
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(Publisher) && Publisher != "null" && !string.IsNullOrEmpty(publishedAT) && publishedAT != "null" && !string.IsNullOrEmpty(UidofPublisher) && UidofPublisher != "null" && !string.IsNullOrEmpty(Likes) && Likes != "-")
                                {
                                    break;
                                }

                                else if (!string.IsNullOrEmpty(item.GetAttribute("title")) && item.GetAttribute("href").Contains(item.GetAttribute("title")) ||
                                    Publisher == "null" || string.IsNullOrEmpty(Publisher) && UidofPublisher == "null" || string.IsNullOrEmpty(UidofPublisher)
                                    && !string.IsNullOrEmpty(KernalWeb.Driver.FindElements(By.TagName("header"))[2].Text))
                                {
                                    try
                                    {
                                        Publisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElements(By.TagName("a"))[1].GetAttribute("title");
                                        UidofPublisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElement(By.TagName("a")).GetAttribute("href");

                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex.Message.Contains("range"))
                                        {
                                            Publisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElements(By.TagName("a"))[0].GetAttribute("title");
                                            UidofPublisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElement(By.TagName("a")).GetAttribute("href");
                                        }
                                    }
                                }


                                else if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("this"))
                                {
                                    //get likes -2
                                    int counterlikes = 0;
                                    foreach (var GetLikes in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                    {
                                        counterlikes++;
                                    }
                                    Likes = counterlikes.ToString();

                                }
                            }
                            foreach (var GetContext in CopyOfPost.FindElements(By.TagName("span")))
                            {
                                if (string.IsNullOrEmpty(context) && GetContext.GetAttribute("title") == "Edited")
                                {
                                    context = GetContext.Text;
                                    break;
                                }
                            }
                            foreach (var ChildofPost in KernalWeb.Driver.FindElements(By.TagName("button")))
                            {
                                if (ChildofPost.Text != null && ChildofPost.Text.Contains("Close"))
                                {

                                    ChildofPost.Click();
                                }
                            }

                            break;
                        }

                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("no"))
                            {
                                //اعجاب
                                if (CurrentModel.Like && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Text == "Like")
                                {
                                    KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Click();
                                    CurrentModel.CountOfLikes++;
                                }
                                //الغاء اعجاب
                                if (CurrentModel.UnLike && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Text == "Unlike")
                                {
                                    KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Click();

                                }
                                foreach (var item in CopyOfPost.FindElements(By.TagName("a")))
                                {
                                    try
                                    {
                                        if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_nzn1h")).Text.Contains("likes")

                                        )
                                        {
                                            //get likes -1
                                            Likes = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_nzn1h")).Text.Replace("likes", "");
                                        }
                                    }
                                    catch (Exception exx)
                                    {
                                        if (exx.Message.Contains("_nzn1h"))
                                        {

                                            if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("this")
                                               && !KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                            {
                                                //get likes -2
                                                int counterlikes = 0;
                                                foreach (var GetLikes in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                                {
                                                    counterlikes++;
                                                }
                                                Likes = counterlikes.ToString();

                                            }
                                            else if (KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                            {
                                                Likes = "0";
                                            }
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(Publisher) && Publisher != "null" && !string.IsNullOrEmpty(publishedAT) && publishedAT != "null" && !string.IsNullOrEmpty(UidofPublisher) && UidofPublisher != "null" && !string.IsNullOrEmpty(Likes) && Likes != "-")
                                    {
                                        break;
                                    }


                                    else if (!string.IsNullOrEmpty(item.GetAttribute("title")) && item.GetAttribute("href").Contains(item.GetAttribute("title")) ||
                                        Publisher == "null" || string.IsNullOrEmpty(Publisher) && UidofPublisher == "null" || string.IsNullOrEmpty(UidofPublisher)
                                        && !string.IsNullOrEmpty(KernalWeb.Driver.FindElements(By.TagName("header"))[2].Text))
                                    {
                                        try
                                        {
                                            Publisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElements(By.TagName("a"))[1].GetAttribute("title");
                                            UidofPublisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElement(By.TagName("a")).GetAttribute("href");
                                        }
                                        catch (Exception)
                                        {
                                            Publisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElements(By.TagName("a"))[0].GetAttribute("title");
                                            UidofPublisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElement(By.TagName("a")).GetAttribute("href");
                                        }
                                    }
                                    else if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("this"))
                                    {
                                        //get likes -2
                                        int counterlikes = 0;
                                        foreach (var GetLikes in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                        {
                                            counterlikes++;
                                        }
                                        Likes = counterlikes.ToString();

                                    }
                                }
                                Thread.Sleep(500);
                                foreach (var GetImg in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("img")))
                                {
                                    if (!string.IsNullOrEmpty(GetImg.GetAttribute("src")))
                                    {
                                        ContextMedia = GetImg.GetAttribute("src");
                                        context = GetImg.GetAttribute("alt");
                                        // break;

                                    }
                                }
                                Thread.Sleep(500);
                                foreach (var GetContext in CopyOfPost.FindElements(By.TagName("span")))
                                {
                                    if (string.IsNullOrEmpty(context) && GetContext.GetAttribute("title") == "Edited")
                                    {
                                        context = GetContext.Text;
                                        break;
                                    }
                                }

                                break;
                            }
                        }

                    }
                    try
                    {
                        try
                        {

                            //close current post
                            KernalWeb.Driver.ExecuteScript("document.getElementsByTagName('button')[document.getElementsByTagName('button').length-1].click();");
                        }
                        catch (Exception) { }

                        //Index was out of range
                        var _Check = Post[Post.IndexOf(new ModelPost()
                        {
                            ContextMedia = ContextMedia,
                            Context = context,
                            publisher = Publisher,
                            Likes = Likes,
                            UidOfpublisher = UidofPublisher,
                            Views = Views,
                            publishedat = publishedAT
                        })];
                        if (_Check == null)
                        {
                            if (Publisher != "null")
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    Post.Add(new ModelPost()
                                    {
                                        ContextMedia = ContextMedia,
                                        Context = context,
                                        publisher = Publisher,
                                        Likes = Likes,
                                        UidOfpublisher = UidofPublisher,
                                        UidOfpost = Uidofpost,
                                        Views = Views,
                                        publishedat = publishedAT
                                    });
                                    if (ContextMedia.Contains("mp4"))
                                    {
                                        CurrentModel.CountOfVideos++;
                                    }
                                    else
                                    {
                                        CurrentModel.CountOfImgs++;

                                    }
                                });
                                Console.WriteLine($"====================================================>\n Count=> {Post.Count.ToString()}");
                                Console.WriteLine($"-------------> m=> {Post[Post.Count - 1].ContextMedia} \n c=> {Post[Post.Count - 1].Context} \n p=> {Post[Post.Count - 1].publisher} \n l=> {Post[Post.Count - 1].Likes} \n u=> {Post[Post.Count - 1].UidOfpublisher} \n v=> {Post[Post.Count - 1].Views} \n PublishedAT=> {Post[Post.Count - 1].publishedat}");
                                Console.WriteLine("\n ====================================================>");
                                LoggerViewModel.Log($" Puplisher=> {Post[Post.Count - 1].publisher}  Likes=> {Post[Post.Count - 1].Likes}  Views=> {Post[Post.Count - 1].Views} PublishedAT=> {Post[Post.Count - 1].publishedat}", TypeOfLog.check);
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    CurrentModel.CountOfPosts = Post.Count;
                                });

                            }
                            context = "null";
                            ContextMedia = "null";
                            Publisher = "null";
                            publishedAT = "null";
                            Uidofpost = "null";
                            Likes = "-";
                            UidofPublisher = "null";
                            Views = "-";
                        }
                    }
                    catch (Exception ex_)
                    {

                        if (ex_.Message.Contains("Index was out of range"))
                        {
                            if (Publisher != "null")
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {

                                    Post.Add(new ModelPost()
                                    {
                                        ContextMedia = ContextMedia,
                                        Context = context,
                                        publisher = Publisher,
                                        Likes = Likes,
                                        UidOfpublisher = UidofPublisher,
                                        UidOfpost=Uidofpost,
                                        Views = Views,
                                        publishedat = publishedAT
                                    });
                                    
                                    if (ContextMedia.Contains("mp4"))
                                    {
                                        CurrentModel.CountOfVideos++;
                                    }
                                    else
                                    {
                                        CurrentModel.CountOfImgs++;

                                    }
                                });
                                Console.WriteLine($"====================================================>\n Count=> {Post.Count.ToString()}");
                                Console.WriteLine($"-------------> m=> {Post[Post.Count - 1].ContextMedia} \n c=> {Post[Post.Count - 1].Context} \n p=> {Post[Post.Count - 1].publisher} \n l=> {Post[Post.Count - 1].Likes} \n u=> {Post[Post.Count - 1].UidOfpublisher} \n v=> {Post[Post.Count - 1].Views} \n PublishedAT=> {Post[Post.Count - 1].publishedat}");
                                Console.WriteLine("\n ====================================================>");
                                LoggerViewModel.Log($" Puplisher=> {Post[Post.Count - 1].publisher}  Likes=> {Post[Post.Count - 1].Likes}  Views=> {Post[Post.Count - 1].Views} PublishedAT=> {Post[Post.Count - 1].publishedat}", TypeOfLog.check);
                                CurrentModel.CountOfPosts = Post.Count;


                            }
                            context = "null";
                            ContextMedia = "null";
                            Publisher = "null";
                            publishedAT = "null";
                            Uidofpost = "null";
                            Likes = "-";
                            UidofPublisher = "null";
                            Views = "-";
                        }
                    }


                }
            }
            catch (Exception eeex)
            {
                if (eeex.Message.Contains("Index was out of range. Must be non-negative and less than the size of the collection."))
                {
                    LoggerViewModel.Log(eeex.Message, TypeOfLog.exclamationcircle);
                    Thread.Sleep(4 * 1000);
                    GetTopPosts(Post, url_, cts);
                }


            }
            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
        }
        /// <summary>
        /// جلب احدث المنشورات
        /// </summary>
        /// <param name="Post">قائمة لتخزين المنشورات</param>
        public void GetMostRecentPosts(ObservableCollection<ModelPost> Post, string url_, CancellationTokenSource cts)
        {
            Operations.CurrentOT = OperationsTypes.GetPosts;
            try
            {
                if (!string.IsNullOrEmpty(url_))
                {
                    KernalWeb.Driver.Navigate().GoToUrl(url_);
                }
            }
            catch (Exception) { }
            int range__ = -1;

            try
            {
                if (Post.Count == 0)
                {
                    Task.Run(() =>
                    {
                        while (!canceled)
                        {
                            try
                            {
                                KernalWeb.Driver.ExecuteScript("scrollBy(0,1200);");
                            }
                            catch (Exception) { }
                        }
                    });
                }
                else
                {
                    KernalWeb.Driver.ExecuteScript("scrollBy(0,380);");
                }


                var Views = "-";
                var Likes = "-";
                var context = "null";
                var Publisher = "null";
                var UidofPublisher = "null";
                var Uidofpost = "null";
                var ContextMedia = "null";
                var publishedAT = "null";
                while (!canceled)
                {
                    if (CurrentModel.IsMaximumEnabled && Post.Count == CurrentModel.MaximumPosts)
                    {
                        cts.Cancel();
                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                        return;
                    }
                    range__++;
                    try
                    {
                        KernalWeb.Driver.ExecuteScript($"document.getElementsByTagName('a')[{range__ + 9}].click();");
                        try
                        {
                            Uidofpost = KernalWeb.Driver.FindElements(By.TagName("a"))[range__+9].GetAttribute("href");
                        }
                        catch (Exception) { }
                        Thread.Sleep(2 * 1000);
                        if (KernalWeb.Driver.FindElement(By.TagName("h2")).Text.Contains("Sorry, this page isn't available."))
                        {

                            Console.WriteLine("problem has been found ");
                            KernalWeb.Driver.Navigate().GoToUrl(url_);
                            //dont leave until finish
                            GetMostRecentPosts(Post, url_, cts);
                        }
                    }
                    catch (Exception ex) { }
                    //Get the current Post 
                    foreach (var CopyOfPost in KernalWeb.Driver.FindElements(By.TagName("article")))
                    {
                        Thread.Sleep(500);
                        if (CurrentModel.IsSleep)
                        {
                            try
                            {
                                Thread.Sleep(new Random()
                                    .Next(
                                    CurrentModel.from + 1,
                                    CurrentModel.To
                                    ) * 1000);
                            }
                            catch (Exception) { }
                        }
                        try
                        {
                            /* Time */
                            if (string.IsNullOrEmpty(publishedAT) || publishedAT == "null" && !string.IsNullOrEmpty(KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.TagName("time")).Text))
                            {
                                publishedAT = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.TagName("time")).Text;
                                if (CurrentModel.IsGetPosts)
                                {
                                    if (publishedAT.Contains("SECOND"))
                                    {
                                        if (CurrentModel.unitOfGetPosts == "ثواني")
                                        {
                                            if (!(double.Parse(publishedAT.Replace("SECONDS AGO", "").Replace("SECOND AGO", "")) >= CurrentModel.fromOfGetPosts
                                               && double.Parse(publishedAT.Replace("SECONDS AGO", "").Replace("SECOND AGO", "")) <= CurrentModel.ToOfGetPosts))
                                            {
                                                cts.Cancel();
                                                Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                                return;
                                            }


                                        }

                                    }
                                    else if (publishedAT.Contains("MINUTE"))
                                    {
                                        if (CurrentModel.unitOfGetPosts == "دقائق")
                                        {
                                            if (!(double.Parse(publishedAT.Replace("MINUTES AGO", "").Replace("MINUTE AGO", "")) >= CurrentModel.fromOfGetPosts
                                                && double.Parse(publishedAT.Replace("MINUTES AGO", "").Replace("MINUTE AGO", "")) <= CurrentModel.ToOfGetPosts))
                                            {
                                                cts.Cancel();
                                                Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                                return;
                                            }

                                        }

                                    }
                                    else if (publishedAT.Contains("HOUR"))
                                    {
                                        if (CurrentModel.unitOfGetPosts == "ساعات")
                                        {
                                            if (!(double.Parse(publishedAT.Replace("HOURS AGO", "").Replace("HOUR AGO", "")) >= CurrentModel.fromOfGetPosts
                                                && double.Parse(publishedAT.Replace("HOURS AGO", "").Replace("HOUR AGO", "")) <= CurrentModel.ToOfGetPosts))
                                            {
                                                cts.Cancel();
                                                Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                                return;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        cts.Cancel();
                                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                        return;
                                    }
                                }
                            }

                            //اعجاب
                            if (CurrentModel.Like && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Text == "Like")
                            {
                                KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Click();
                                CurrentModel.CountOfLikes++;
                            }
                            //الغاء اعجاب
                            if (CurrentModel.UnLike && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Text == "Unlike")
                            {
                                KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Click();

                            }
                            if (!string.IsNullOrEmpty(KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.TagName("video")).GetAttribute("src")))
                            {
                                ContextMedia = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.TagName("video")).GetAttribute("src");
                                try
                                {
                                    if (KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("ul")).Count != 0)
                                    {
                                        context = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("ul"))[0].FindElement(By.TagName("span")).Text;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.Contains("no"))
                                    {
                                        context = "";
                                    }
                                }
                                try
                                {
                                    Views = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_m5zti")).Text.Replace("views", "");
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.Contains("_m5zti"))
                                    {
                                        Views = "0";
                                    }
                                }
                                try
                                {
                                    KernalWeb.Driver.ExecuteScript("document.getElementsByClassName('_m5zti')[0].click();");
                                    var LikesCount_ = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_m10kk")).Text;
                                    Thread.Sleep(1000);

                                    if (!LikesCount_.Contains("likes"))
                                    {
                                        Likes = LikesCount_.Replace("like", string.Empty);
                                    }
                                    else
                                    {
                                        Likes = LikesCount_.Replace("likes", string.Empty);
                                    }
                                }

                                catch (Exception ex)
                                {

                                    if (ex.Message.Contains("no"))
                                    {
                                        Likes = "0";
                                    }
                                }

                            }

                            foreach (var item in CopyOfPost.FindElements(By.TagName("a")))
                            {
                                try
                                {
                                    if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_nzn1h")).Text.Contains("likes"))
                                    {
                                        //get likes -1
                                        Likes = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_nzn1h")).Text.Replace("likes", "");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.Contains("_nzn1h"))
                                    {

                                        if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("this")
                                           && !KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                        {

                                            //get likes -2
                                            int counterlikes = 0;
                                            foreach (var GetLikes in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                            {
                                                counterlikes++;
                                            }
                                            Likes = counterlikes.ToString();

                                        }
                                        else if (KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                        {
                                            Likes = "0";
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(Publisher) && Publisher != "null" && !string.IsNullOrEmpty(publishedAT) && publishedAT != "null" && !string.IsNullOrEmpty(UidofPublisher) && UidofPublisher != "null" && !string.IsNullOrEmpty(Likes) && Likes != "-")
                                {
                                    break;
                                }

                                else if (!string.IsNullOrEmpty(item.GetAttribute("title")) && item.GetAttribute("href").Contains(item.GetAttribute("title")) ||
                                    Publisher == "null" || string.IsNullOrEmpty(Publisher) && UidofPublisher == "null" || string.IsNullOrEmpty(UidofPublisher)
                                    && !string.IsNullOrEmpty(KernalWeb.Driver.FindElements(By.TagName("header"))[2].Text))
                                {
                                    try
                                    {

                                        Publisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElements(By.TagName("a"))[1].GetAttribute("title");
                                        UidofPublisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElement(By.TagName("a")).GetAttribute("href");
                                    }
                                    catch (Exception)
                                    {

                                        Publisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElements(By.TagName("a"))[0].GetAttribute("title");
                                        UidofPublisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElement(By.TagName("a")).GetAttribute("href");
                                    }
                                }

                                else if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("this"))
                                {
                                    //get likes -2
                                    int counterlikes = 0;
                                    foreach (var GetLikes in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                    {
                                        counterlikes++;
                                    }
                                    Likes = counterlikes.ToString();

                                }
                            }
                            foreach (var GetContext in CopyOfPost.FindElements(By.TagName("span")))
                            {
                                if (string.IsNullOrEmpty(context) && GetContext.GetAttribute("title") == "Edited")
                                {
                                    context = GetContext.Text;
                                    break;
                                }
                            }
                            foreach (var ChildofPost in KernalWeb.Driver.FindElements(By.TagName("button")))
                            {
                                if (ChildofPost.Text != null && ChildofPost.Text.Contains("Close"))
                                {

                                    ChildofPost.Click();
                                }
                            }

                            break;
                        }

                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("no"))
                            {

                                foreach (var item in CopyOfPost.FindElements(By.TagName("a")))
                                {
                                    try
                                    {
                                        if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_nzn1h")).Text.Contains("likes")

                                        )
                                        {
                                            //get likes -1
                                            Likes = KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_nzn1h")).Text.Replace("likes", "");
                                        }
                                    }
                                    catch (Exception exx)
                                    {
                                        if (exx.Message.Contains("_nzn1h"))
                                        {

                                            if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("this")
                                               && !KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                            {
                                                //get likes -2
                                                int counterlikes = 0;
                                                foreach (var GetLikes in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                                {
                                                    counterlikes++;
                                                }
                                                Likes = counterlikes.ToString();

                                            }
                                            else if (KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                            {
                                                Likes = "0";
                                            }
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(Publisher) && Publisher != "null" && !string.IsNullOrEmpty(publishedAT) && publishedAT != "null" && !string.IsNullOrEmpty(UidofPublisher) && UidofPublisher != "null" && !string.IsNullOrEmpty(Likes) && Likes != "-")
                                    {
                                        break;
                                    }
                                    //اعجاب
                                    else if (CurrentModel.Like && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Text == "Like")
                                    {
                                        KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Click();
                                        CurrentModel.CountOfLikes++;
                                    }
                                    //الغاء اعجاب
                                    else if (CurrentModel.UnLike && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Text == "Unlike")
                                    {
                                        KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("section"))[0].FindElement(By.TagName("a")).Click();

                                    }
                                    else if (!string.IsNullOrEmpty(item.GetAttribute("title")) && item.GetAttribute("href").Contains(item.GetAttribute("title")) ||
                                        Publisher == "null" || string.IsNullOrEmpty(Publisher) && UidofPublisher == "null" || string.IsNullOrEmpty(UidofPublisher)
                                        && !string.IsNullOrEmpty(KernalWeb.Driver.FindElements(By.TagName("header"))[2].Text))
                                    {
                                        try
                                        {
                                            Publisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElements(By.TagName("a"))[1].GetAttribute("title");
                                            UidofPublisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElement(By.TagName("a")).GetAttribute("href");
                                        }
                                        catch (Exception)
                                        {

                                            Publisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElements(By.TagName("a"))[0].GetAttribute("title");
                                            UidofPublisher = KernalWeb.Driver.FindElements(By.TagName("header"))[2].FindElement(By.TagName("a")).GetAttribute("href");
                                        }
                                    }
                                    else if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).Text.Contains("this"))
                                    {
                                        //get likes -2
                                        int counterlikes = 0;
                                        foreach (var GetLikes in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                        {
                                            counterlikes++;
                                        }
                                        Likes = counterlikes.ToString();

                                    }
                                }
                                Thread.Sleep(500);
                                foreach (var GetImg in KernalWeb.Driver.FindElements(By.TagName("article"))[1].FindElements(By.TagName("img")))
                                {
                                    if (!string.IsNullOrEmpty(GetImg.GetAttribute("src")))
                                    {
                                        ContextMedia = GetImg.GetAttribute("src");
                                        context = GetImg.GetAttribute("alt");
                                        // break;

                                    }
                                }
                                Thread.Sleep(500);
                                foreach (var GetContext in CopyOfPost.FindElements(By.TagName("span")))
                                {
                                    if (string.IsNullOrEmpty(context) && GetContext.GetAttribute("title") == "Edited")
                                    {
                                        context = GetContext.Text;
                                        break;
                                    }
                                }

                                break;
                            }
                        }

                    }
                    try
                    {
                        try
                        {

                            //close current post
                            KernalWeb.Driver.ExecuteScript("document.getElementsByTagName('button')[document.getElementsByTagName('button').length-1].click();");
                        }
                        catch (Exception) { }

                        //Index was out of range
                        var _Check = Post[Post.IndexOf(new ModelPost()
                        {
                            ContextMedia = ContextMedia,
                            Context = context,
                            publisher = Publisher,
                            Likes = Likes,
                            UidOfpublisher = UidofPublisher,
                            Views = Views,
                            publishedat = publishedAT
                        })];
                        if (_Check == null)
                        {
                            if (Publisher != "null")
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    Post.Add(new ModelPost()
                                    {
                                        ContextMedia = ContextMedia,
                                        Context = context,
                                        publisher = Publisher,
                                        Likes = Likes,
                                        UidOfpublisher = UidofPublisher,
                                        UidOfpost = Uidofpost,
                                        Views = Views,
                                        publishedat = publishedAT
                                    });
                                    if (ContextMedia.Contains("mp4"))
                                    {
                                        CurrentModel.CountOfVideos++;
                                    }
                                    else
                                    {
                                        CurrentModel.CountOfImgs++;

                                    }
                                });
                                LoggerViewModel.Log($" Puplisher=> {Post[Post.Count - 1].publisher}  Likes=> {Post[Post.Count - 1].Likes}  Views=> {Post[Post.Count - 1].Views} PublishedAT=> {Post[Post.Count - 1].publishedat}", TypeOfLog.check);
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    CurrentModel.CountOfPosts = Post.Count;
                                });

                            }
                            Console.WriteLine($"====================================================>\n Count=> {Post.Count.ToString()}");
                            Console.WriteLine($"-------------> m=> {Post[Post.Count - 1].ContextMedia} \n c=> {Post[Post.Count - 1].Context} \n p=> {Post[Post.Count - 1].publisher} \n l=> {Post[Post.Count - 1].Likes} \n u=> {Post[Post.Count - 1].UidOfpublisher} \n v=> {Post[Post.Count - 1].Views} \n PublishedAT=> {Post[Post.Count - 1].publishedat}");
                            Console.WriteLine("\n ====================================================>");
                            context = "null";
                            ContextMedia = "null";
                            Publisher = "null";
                            Uidofpost = "null";
                            Likes = "-";
                            UidofPublisher = "null";
                            Views = "-";
                        }
                    }
                    catch (Exception ex_)
                    {

                        if (ex_.Message.Contains("Index was out of range"))
                        {
                            if (Publisher != "null")
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {

                                    Post.Add(new ModelPost()
                                    {
                                        ContextMedia = ContextMedia,
                                        Context = context,
                                        publisher = Publisher,
                                        Likes = Likes,
                                        UidOfpublisher = UidofPublisher,
                                        UidOfpost = Uidofpost,
                                        Views = Views,
                                        publishedat = publishedAT
                                    });
                                    if (ContextMedia.Contains("mp4"))
                                    {
                                        CurrentModel.CountOfVideos++;
                                    }
                                    else
                                    {
                                        CurrentModel.CountOfImgs++;

                                    }
                                });
                                LoggerViewModel.Log($" Puplisher=> {Post[Post.Count - 1].publisher}  Likes=> {Post[Post.Count - 1].Likes}  Views=> {Post[Post.Count - 1].Views} PublishedAT=> {Post[Post.Count - 1].publishedat}", TypeOfLog.check);
                                CurrentModel.CountOfPosts = Post.Count;

                            }
                            Console.WriteLine($"====================================================>\n Count=> {Post.Count.ToString()}");
                            Console.WriteLine($"-------------> m=> {Post[Post.Count - 1].ContextMedia} \n c=> {Post[Post.Count - 1].Context} \n p=> {Post[Post.Count - 1].publisher} \n l=> {Post[Post.Count - 1].Likes} \n u=> {Post[Post.Count - 1].UidOfpublisher} \n v=> {Post[Post.Count - 1].Views} \n PublishedAT=> {Post[Post.Count - 1].publishedat}");
                            Console.WriteLine("\n ====================================================>");
                            context = "null";
                            ContextMedia = "null";
                            Publisher = "null";
                            Uidofpost = "null";
                            Likes = "-";
                            UidofPublisher = "null";
                            publishedAT = "null";
                            Views = "-";
                        }
                    }


                }
            }
            catch (Exception eeex)
            {
                if (eeex.Message.Contains("Index was out of range. Must be non-negative and less than the size of the collection."))
                {
                    LoggerViewModel.Log(eeex.Message, TypeOfLog.exclamationcircle);
                    GetMostRecentPosts(Post, url_, cts);
                }


            }
            Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
        }
    }
}
