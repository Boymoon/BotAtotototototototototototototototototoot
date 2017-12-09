
using DevExpress.Xpf.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
#region TopSecret

/// <summary>
/// https://www.pornhub.com/view_video.php?viewkey=ph573fc896bfaf6
/// </summary>
/// 
#endregion
///https://www.instagram.com/mxao76/
namespace Instagram.App
{
    public class Comment
    {
        private ModelComment mModelComment;
        public bool StateOfTask = false;
        public Comment(ModelComment modelComment_)
        {
            mModelComment = modelComment_;
        }
        public void SendComment_UnderTest(ObservableCollection<ModelPost> PostsContainer_,string TableName) => sendComment((Posts_) =>
                                              {
                                                  Operations.CurrentOT = OperationsTypes.GetPosts;
                                                  var containerOfPosts = new ObservableCollection<ModelPost>();
                                                  int CountOfposts = 0;
                                                 /* Temp_ = المتصفح  المؤقت */
                                                  KernalWeb.TemporaryDriver.Navigate().GoToUrl(mModelComment.Target);
                                                  Thread.Sleep(1000);
                                                 /* الضغط على زر المزيد  من المنشورات  */
                                                  try
                                                  {
                                                      KernalWeb.TemporaryDriver.ExecuteScript("document.getElementsByClassName('_1cr2e')[0].click();");
                                                      Task.Run(() =>
                                                      {
                                                          try
                                                          {
                                                              while (!StateOfTask)
                                                              {
                                                                  Thread.Sleep(1000);
                                                                  KernalWeb.TemporaryDriver.ExecuteScript("window.scrollBy(0,1000);");
                                                                  LoggerViewModel.Log($"{StateOfTask}", TypeOfLog.questioncircle);
                                                              }

                                                          }
                                                          catch (Exception) { }
                                                      });
                                                  }
                                                  catch (Exception) { }
                                                  foreach (var item in KernalWeb.TemporaryDriver.FindElements(By.TagName("span")))
                                                  {
                                                      if (item.GetAttribute("class") == "_fd86t")
                                                      {
                                                          CountOfposts = int.Parse(item.Text.Replace(",", "").Replace(".", ""));
                                                          break;
                                                      }
                                                  }
                                                  while (CountOfposts != Posts_.Count)
                                                  {
                                                      foreach (var _currentpost in KernalWeb.TemporaryDriver.FindElements(By.TagName("a")))
                                                      {
                                                          try
                                                          {
                                                              if (_currentpost.GetAttribute("href").Contains("/p/") && Posts_.IndexOf(_currentpost.GetAttribute("href")) == -1)
                                                              {
                                                                  Posts_.Add(_currentpost.GetAttribute("href"));
                                                                  LoggerViewModel.Log($"Index:{Posts_.Count}", TypeOfLog.Warning);
                                                                  LoggerViewModel.Log($"Text:{_currentpost.Text}", TypeOfLog.Warning);
                                                                  LoggerViewModel.Log($"Posts:{CountOfposts}", TypeOfLog.check);

                                                              }
                                                          }
                                                          catch (Exception ex)
                                                          {
                                                              LoggerViewModel.Log($"{ex.Message} |Line:37|Method:SendComment|Class:Web.Core->UserOperation->Comment ", TypeOfLog.exclamationcircle);

                                                          }
                                                      }

                                                  }
                                                  if (CountOfposts == Posts_.Count)
                                                  {
                                                      KernalWeb.AddCookiesToTemporaryDriver(KernalWeb.TemporaryDriver);
                                                      for (int i = 0; i < Posts_.Count; i++)
                                                      {
                                                          KernalWeb.TemporaryDriver.Navigate().GoToUrl(Posts_[i]);
                                                          Thread.Sleep(1000);
                                                          var Views = "-";
                                                          var Likes = "-";
                                                          var context = "null";
                                                          var Publisher = "null";
                                                          var UidofPublisher = "null";
                                                          var Uidofpost = "null";
                                                          var ContextMedia = "null";
                                                          var publishedAT = "null";
                                                          #region GetPost_INFO
                                                          try
                                                          {
                                                              Uidofpost = Posts_[i];
                                                              /* Time */
                                                              if (string.IsNullOrEmpty(publishedAT) || publishedAT == "null" && !string.IsNullOrEmpty(KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.TagName("time")).Text))
                                                              {
                                                                  publishedAT = KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.TagName("time")).Text;
                                                                  /* تحتاج مراجعة */
                                                                  #region need to review
                                                                  //if (CurrentModel.IsGetPosts)
                                                                  //{
                                                                  //    if (publishedAT.Contains("SECONDS"))
                                                                  //    {
                                                                  //        if (CurrentModel.unitOfGetPosts == "ثواني")
                                                                  //        {
                                                                  //            if (!(double.Parse(publishedAT.Replace("SECONDS AGO", "")) >= CurrentModel.fromOfGetPosts
                                                                  //               && double.Parse(publishedAT.Replace("SECONDS AGO", "")) <= CurrentModel.ToOfGetPosts))
                                                                  //            {
                                                                  //                break;

                                                                  //            }


                                                                  //        }

                                                                  //    }
                                                                  //    else if (publishedAT.Contains("MINUTES"))
                                                                  //    {
                                                                  //        if (CurrentModel.unitOfGetPosts == "دقائق")
                                                                  //        {
                                                                  //            if (!(double.Parse(publishedAT.Replace("MINUTES AGO", "")) >= CurrentModel.fromOfGetPosts
                                                                  //                && double.Parse(publishedAT.Replace("MINUTES AGO", "")) <= CurrentModel.ToOfGetPosts))
                                                                  //            {
                                                                  //                break;
                                                                  //            }

                                                                  //        }

                                                                  //    }
                                                                  //    else if (publishedAT.Contains("HOUR"))
                                                                  //    {
                                                                  //        if (CurrentModel.unitOfGetPosts == "ساعات")
                                                                  //        {
                                                                  //            if (!(double.Parse(publishedAT.Replace("HOURS AGO", "").Replace("HOUR AGO", "")) >= CurrentModel.fromOfGetPosts
                                                                  //                && double.Parse(publishedAT.Replace("HOURS AGO", "").Replace("HOUR AGO", "")) <= CurrentModel.ToOfGetPosts))
                                                                  //            {
                                                                  //                break;

                                                                  //            }
                                                                  //        }
                                                                  //        else
                                                                  //        {
                                                                  //            break;
                                                                  //        }

                                                                  //    }
                                                                  //    else
                                                                  //    {
                                                                  //        break;
                                                                  //    }
                                                                  //}
#endregion
                                                              }
                                                              try
                                                              {
                                                              //اعجاب
                                                              if (KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Text == "Like")
                                                              {
                                                                  KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Click();
                                                                 /* تحتاج مراجعة */
                                                                  // CurrentModel.CountOfLikes++;
                                                              }
                                                              //الغاء اعجاب
                                                              if ( KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Text == "Unlike")
                                                              {
                                                                  KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Click();

                                                              }

                                                              }
                                                              catch (Exception) { }
                                                              if (!string.IsNullOrEmpty(KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.TagName("video")).GetAttribute("src")))
                                                              {
                                                                  ContextMedia = KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.TagName("video")).GetAttribute("src");
                                                                  try
                                                                  {
                                                                      if (KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("ul")).Count != 0)
                                                                      {
                                                                          context = KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("ul"))[0].FindElement(By.TagName("span")).Text;
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
                                                                      Views = KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_m5zti")).Text.Replace("views", "");
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
                                                                      KernalWeb.TemporaryDriver.ExecuteScript("document.getElementsByClassName('_m5zti')[0].click();");
                                                                      var LikesCount_ = KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_m10kk")).Text;
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

                                                              foreach (var item in KernalWeb.TemporaryDriver.FindElements(By.TagName("a")))
                                                              {
                                                                  try
                                                                  {
                                                                      if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_nzn1h")).Text.Contains("likes"))
                                                                      {
                                                                          //get likes -1
                                                                          Likes = KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_nzn1h")).Text.Replace("likes", "");
                                                                      }
                                                                  }
                                                                  catch (Exception ex)
                                                                  {
                                                                      if (ex.Message.Contains("_nzn1h"))
                                                                      {

                                                                          if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).Text.Contains("this")
                                                                             && !KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                                                          {

                                                                              //get likes -2
                                                                              int counterlikes = 0;
                                                                              foreach (var GetLikes in KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                                                              {
                                                                                  counterlikes++;
                                                                              }
                                                                              Likes = counterlikes.ToString();

                                                                          }
                                                                          else if (KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
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
                                                                      && !string.IsNullOrEmpty(KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].Text))
                                                                  {
                                                                      try
                                                                      {
                                                                          Publisher = KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].FindElements(By.TagName("a"))[1].GetAttribute("title");
                                                                          UidofPublisher = KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].FindElement(By.TagName("a")).GetAttribute("href");

                                                                      }
                                                                      catch (Exception ex)
                                                                      {
                                                                          if (ex.Message.Contains("range"))
                                                                          {
                                                                              Publisher = KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].FindElements(By.TagName("a"))[0].GetAttribute("title");
                                                                              UidofPublisher = KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].FindElement(By.TagName("a")).GetAttribute("href");
                                                                          }
                                                                      }
                                                                  }


                                                                  else if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).Text.Contains("this"))
                                                                  {
                                                                      //get likes -2
                                                                      int counterlikes = 0;
                                                                      foreach (var GetLikes in KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                                                      {
                                                                          counterlikes++;
                                                                      }
                                                                      Likes = counterlikes.ToString();

                                                                  }
                                                              }
                                                              foreach (var GetContext in KernalWeb.TemporaryDriver.FindElements(By.TagName("span")))
                                                              {
                                                                  if (string.IsNullOrEmpty(context) && GetContext.GetAttribute("title") == "Edited")
                                                                  {
                                                                      context = GetContext.Text;
                                                                      break;
                                                                  }
                                                              }
                                                             

                                                          }

                                                          catch (Exception ex)
                                                          {
                                                              if (ex.Message.Contains("no"))
                                                              {
                                                                  LoggerViewModel.Log(ex.Message, TypeOfLog.questioncircle);

                                                                  var ccccccccccc = KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Text;
                                                                  LoggerViewModel.Log(ccccccccccc, TypeOfLog.questioncircle);
                                                                  //اعجاب
                                                                  if (KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Text == "Like")
                                                                  {
                                                                      KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Click();
                                                                    /* تحتاج مراجعة +==================================================================================== */
                                                                      //  mModelComment.CountOfLikes++;
                                                                  }
                                                                  //الغاء اعجاب
                                                                  if (KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Text == "Unlike")
                                                                  {
                                                                      KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("section"))[1].FindElement(By.TagName("a")).Click();

                                                                  }
                                                                  foreach (var item in KernalWeb.TemporaryDriver.FindElements(By.TagName("a")))
                                                                  {
                                                                      try
                                                                      {
                                                                          if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_nzn1h")).Text.Contains("likes")

                                                                          )
                                                                          {
                                                                              //get likes -1
                                                                              Likes = KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_nzn1h")).Text.Replace("likes", "");
                                                                          }
                                                                      }
                                                                      catch (Exception exx)
                                                                      {
                                                                          if (exx.Message.Contains("_nzn1h"))
                                                                          {

                                                                              if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).Text.Contains("this")
                                                                                 && !KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
                                                                              {
                                                                                  //get likes -2
                                                                                  int counterlikes = 0;
                                                                                  foreach (var GetLikes in KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                                                                  {
                                                                                      counterlikes++;
                                                                                  }
                                                                                  Likes = counterlikes.ToString();

                                                                              }
                                                                              else if (KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).Text.Contains("Be the first to "))
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
                                                                          && !string.IsNullOrEmpty(KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].Text))
                                                                      {
                                                                          try
                                                                          {
                                                                              Publisher = KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].FindElements(By.TagName("a"))[1].GetAttribute("title");
                                                                              UidofPublisher = KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].FindElement(By.TagName("a")).GetAttribute("href");
                                                                          }
                                                                          catch (Exception)
                                                                          {
                                                                              Publisher = KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].FindElements(By.TagName("a"))[0].GetAttribute("title");
                                                                              UidofPublisher = KernalWeb.TemporaryDriver.FindElements(By.TagName("header"))[0].FindElement(By.TagName("a")).GetAttribute("href");
                                                                          }
                                                                      }
                                                                      else if (string.IsNullOrEmpty(Likes) || Likes == "-" && KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).Text.Contains("this"))
                                                                      {
                                                                          //get likes -2
                                                                          int counterlikes = 0;
                                                                          foreach (var GetLikes in KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElement(By.ClassName("_3gwk6")).FindElements(By.TagName("a")))
                                                                          {
                                                                              counterlikes++;
                                                                          }
                                                                          Likes = counterlikes.ToString();
                                                                      }
                                                                  }
                                                                  Thread.Sleep(500);
                                                                  foreach (var GetImg in KernalWeb.TemporaryDriver.FindElements(By.TagName("article"))[0].FindElements(By.TagName("img")))
                                                                  {
                                                                      if (!string.IsNullOrEmpty(GetImg.GetAttribute("src")))
                                                                      {
                                                                          ContextMedia = GetImg.GetAttribute("src");
                                                                          context = GetImg.GetAttribute("alt");
                                                                          // break;

                                                                      }
                                                                  }
                                                                  Thread.Sleep(500);
                                                              }
                                                          }
                                                          #endregion
                                                          Application.Current.Dispatcher.Invoke(() => 
                                                          {
                                                              containerOfPosts.Add(new ModelPost()
                                                              {
                                                                  Views=Views,
                                                                  Context=context,
                                                                  ContextMedia=ContextMedia,
                                                                  Likes=Likes,
                                                                  publishedat=publishedAT,
                                                                  publisher=Publisher,
                                                                  UidOfpublisher=UidofPublisher,
                                                                  UidOfpost=Uidofpost
                                                              });
                                                              HelperSelector.Insert(containerOfPosts,TableName);
                                                             
                                                          });
                                                      }
                                                      }
                                                  /* جلب معلومات المنشور */

                                                  Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                                  try
                                                  {
                                                      garbage.Kill((long)KernalWeb._PID[1]);
                                                  }
                                                  catch (Exception) { }
                                              });
        /// <summary>
        /// *********************************  || *********************************
        /// دالة ارسال  تعليقات تحت الاختبار  ||  دالة ارسال  تعليقات تحت الاختبار 
        /// *********************************  ||*********************************
        /// 
        /// </summary>
        /// <param name="GetPost"></param>
        private void sendComment(Action<List<string>> GetPost)
        {
            Operations.CurrentOT = OperationsTypes.DoComment;
            #region Settings
            KernalWeb.Driver.Manage().Window.Size = new System.Drawing.Size(4000, 4000);
            KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);
            KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            #endregion

            if (string.IsNullOrEmpty(mModelComment.Target))
            {
                return;
            }
            KernalWeb.CreateTemporaryDriver(mModelComment.Target);
            using (KernalWeb.TemporaryDriver)
            {
                var sendComments = Task.Factory.StartNew(() =>

                {
                    var Posts = new List<string>();
                    while (!StateOfTask)
                    {
                        /* جلب المنشورات */
                        Task.Run(() =>
                        {
                            GetPost(Posts);
                        });
                        /* الانتظار  حتى يتم تعبئة  قائمة المنشورات */
                        while (!(Posts.Count >= 1))
                        {

                        }
                        #region Old
                        ///* التحقق  من زر المزيد  من المنشورات  */
                        //foreach (var button in Temp.FindElements(By.TagName("a")))
                        //{
                        //    try
                        //    {
                        //        while (button.GetAttribute("href").Contains("?max_id"))
                        //        {
                        //            button.Click();
                        //        }

                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        LoggerViewModel.Log($"{ex.Message} |Line:48|Method:SendComment|Class:Web.Core->UserOperation->Comment ", TypeOfLog.exclamationcircle);
                        //    }
                        //}

                        #endregion
                        /* اعادة ارسال التعليق */
                        bool isReapet = false;
                        /* عداد الاخطاء  الخاصة  بإرسال التعليقات */
                        int CounterOfErrors = 0;
                        /* في حالة عدم  وجود منشن */
                        if (string.IsNullOrEmpty(mModelComment.Tag))
                        {
                            Actions DoActionsOnBrowser = new Actions(KernalWeb.Driver);
                            /* متغير لحساب التعليقات المرسلة */
                            int AntiBanned = 0;
                            for (int i = 0; i < Posts.Count; i++)
                            {
                                LoggerViewModel.Log($"{Posts.Count} I={i}", TypeOfLog.Warning);
                                int spell = new Random().Next(0, mModelComment.Text.Length);
                                Thread.Sleep(3 * 1000);
                                KernalWeb.Driver.Navigate().GoToUrl(Posts[i]);
                                Thread.Sleep(2 * 1000);
                                KernalWeb.Driver.ExecuteScript("window.scrollBy(0,2000);");
                                KernalWeb.Driver.FindElement(By.XPath("//*[@id='react-root']/section/main/div/div/article/div[2]/section[3]/form/textarea")).Click();
                                /* تقطيع التعليق جزئين وارسالهم بأوقات مختلفة */
                                for (int ii = 0; ii < 2; ii++)
                                {
                                    Thread.Sleep(500);

                                    /* Needs to be fix  */

                                    //KernalWeb.Driver.FindElement(By.XPath("//*[@id='react-root']/section/main/div/div/article/div[2]/section[3]/form/textarea")).
                                    //        SendKeys(mModelComment.Text.Substring((ii == 1) ? 0 : spell, ((ii == 1) ? spell : mModelComment.Text.Length - spell)));
                                    Screenshot sc = KernalWeb.Driver.GetScreenshot();
                                    sc.SaveAsFile($"img_of_postsAndCommentsSection{ii}.png", ScreenshotImageFormat.Png);
                                    DoActionsOnBrowser.SendKeys(KernalWeb.Driver.FindElement(By.XPath("//*[@id='react-root']/section/main/div/div/article/div[2]/section[3]/form/textarea")),
                                        mModelComment.Text.Substring((ii == 1) ? 0 : spell, ((ii == 1) ? spell : mModelComment.Text.Length - spell))).Perform();


                                }
                                try
                                {

                                    /* Needs to be fix  */

                                    //KernalWeb.Driver.FindElement(By.XPath("//*[@id='react-root']/section/main/div/div/article/div[2]/section[3]/form/textarea")).SendKeys(Keys.Enter);
                                    DoActionsOnBrowser.SendKeys(KernalWeb.Driver.FindElement(By.XPath("//*[@id='react-root']/section/main/div/div/article/div[2]/section[3]/form/textarea")), Keys.Enter).Perform();
                                    Thread.Sleep(100);
                                    Screenshot sc = KernalWeb.Driver.GetScreenshot();
                                    sc.SaveAsFile($"img_of_postsAndCommentsSection_After_Submit_what_the_user_wrote.png", ScreenshotImageFormat.Png);

                                    AntiBanned++;
                                    if (AntiBanned == 3)
                                    {
                                        Thread.Sleep(30 * 1000);
                                        AntiBanned = 0;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LoggerViewModel.Log($"{ex.Message} |Line:118|Method:SendComment|Class:Web.Core->UserOperation->Comment ", TypeOfLog.exclamationcircle);
                                }
                                try
                                {
                                    int beforeChecking = CounterOfErrors;
                                    Thread.Sleep(5000);
                                    /* التحقق  من وجود اخطاء */
                                    while (KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Displayed && KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Text.Contains("Couldn't post comment."))
                                    {
                                        CounterOfErrors++;
                                        mModelComment.UnableToSend++;
                                        /* في حال  حدوث الخطأ مرة اخرى */
                                        if (isReapet)
                                        {
                                            isReapet = false;
                                            /*   
                                           وعليه فانه سيتم ايقاف ارسال التعليقات لمدة  دقيقتان ' المؤقت  ' يبدو ان حسابك قد  تعرض للحظر 
                                             */
                                            Application.Current.Dispatcher.Invoke(() =>
                                            {
                                                try
                                                {
                                                    //DXMessageBox.Show($".يبدو ان حسابك قد تعرض للحظر المؤقت  وعليه فانه سيتم تعليق ارسال التعليقات  حتى دقيقة");
                                                    /* تحقق  من حالة قسم  ارسال التعليقات */
                                                    bool IsCompleted = false;
                                                    Task.Run(() =>
                                                    {
                                                        while (!IsCompleted)
                                                        {
                                                            if (StateOfTask)
                                                            {
                                                                Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                                                                return;
                                                            }
                                                        }

                                                    });

                                                    IsCompleted = true;
                                                }
                                                catch (Exception ex)
                                                {
                                                    LoggerViewModel.Log($"{ex.Message} |Line:173|Method:SendComment|Class:Web.Core->UserOperation->Comment ", TypeOfLog.exclamationcircle);

                                                }
                                            });
                                            Thread.Sleep((2 * 30) * (1000));
                                            LoggerViewModel.Log("unfortunately your account has been blocked", TypeOfLog.Warning);

                                        }
                                        else { break; }
                                    }
                                    if (!(CounterOfErrors > beforeChecking))
                                    {
                                        mModelComment.SentSuccess++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LoggerViewModel.Log($"{ex.Message} |Line:160|Method:SendComment|Class:Web.Core->UserOperation->Comment ", TypeOfLog.exclamationcircle);
                                    bool try_ = KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Displayed;
                                }
                                if (!isReapet && CounterOfErrors >= 1)
                                {
                                    /* اعادة ضبط اعدادات الانتقال  بين المنشورات */
                                    i--;
                                    /* الغاء التوقف  عند منشور معين  حال  حدوث خطأ */
                                    isReapet = true;
                                    /* تصفير عداد الاخطاء */
                                    CounterOfErrors = 0;
                                }

                            }
                        }
                        LoggerViewModel.Log($"{Posts.Count}", TypeOfLog.Warning);

                        StateOfTask = true;
                    }

                });
                while (!StateOfTask)
                {
                    while (StateOfTask)
                    {
                        Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
                        LoggerViewModel.Log("Finished", TypeOfLog.check);
                        break;
                    }

                }

                Operations.CurrentOT = OperationsTypes.CancelCurrentOperation;
            }

         
        }
        /// <summary>
        ///  دالة لإرسال التعليقات
        /// <![CDATA[****************بحاجة الى  تعديل  طريقة  ارسال التعليق ****************]]>
        /// </summary>
        /// <returns></returns>
        public void SendComment()
        {
            var Tags = new List<string>();
            var Target = new List<string>();
            KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 6);
            KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 6);
            if (!String.IsNullOrEmpty(mModelComment.Text))
            {
                KernalWeb.Driver.Navigate().GoToUrl(mModelComment.Target);
                KernalWeb.Driver.ExecuteScript("window.scrollBy(0,2000);");

                foreach (var item in KernalWeb.Driver.FindElements(By.TagName("a")))
                {
                    if (item.GetAttribute("href").Contains("?max_id"))
                    {
                        item.Click();
                    }
                }
                foreach (var item in KernalWeb.Driver.FindElements(By.TagName("a")))
                {


                    if (item.GetAttribute("href").Contains("/p/"))
                    {
                        Target.Add(item.GetAttribute("href"));
                    }

                }

                if (Target.Count != 0)
                {
                    for (int i = 0; i < Target.Count; i++)
                    {
                        KernalWeb.Driver.Navigate().GoToUrl(Target[i]);
                        KernalWeb.Driver.ExecuteScript("window.scrollBy(0,200);");
                        foreach (var comment_ in KernalWeb.Driver.FindElements(By.XPath("//*[@id='react-root']/section/main/div/div/article/div[2]/section[3]/form/textarea")))
                        {
                            comment_.Click();
                            Thread.Sleep(1000);
                            KernalWeb.Driver.FindElements(By.XPath("//*[@id='react-root']/section/main/div/div/article/div[2]/section[3]/form/textarea"))[0].SendKeys("gfdgfd");
                            KernalWeb.Driver.ExecuteScript($"document.getElementsByTagName('textarea')[0].innerText='{mModelComment.Text}';");


                            if (!String.IsNullOrEmpty(mModelComment.Tag))
                            {
                                int counterofMentions = 0;
                                int counter = 0;
                                var virtualTag = mModelComment.Tag;
                                foreach (Match Tag_ in Regex.Matches(virtualTag, "[A-Za-z0-9.-=)(*&^%$#!?><,_-؛÷‘=}{:|/ ~]+[^@]"))
                                {
                                    #region OldCodeThatWeMybeUseLater
                                    //if (Regex.Matches(virtualTag, "[A-Za-z0-9.-=)(*&^%$#!?><,_-؛÷‘=}{:|/ ~]+[^@]").Count >= 5)
                                    //{
                                    //    comment_.SendKeys(" " + "@" + Tag_.Value + " ");
                                    //    counterofMentions++;
                                    //    counter++;
                                    //    if (counter == 5)
                                    //    {
                                    //        //اعداد التهيئة للمنشور التالي
                                    //        comment_.SendKeys(Keys.Enter);
                                    //        Thread.Sleep(2000);
                                    //        var error = KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Text;
                                    //        if (error.Contains("Couldn't post comment."))
                                    //        {
                                    //            MessageBoxResult msg = new MessageBoxResult();
                                    //            Application.Current.Dispatcher.Invoke(() =>
                                    //            {
                                    //                msg = DXMessageBox.Show("يبدو ان حسابك قد تعرض للحظر المؤقت,هل تود بالمحاولة مرة اخرى بعد 5 دقائق؟", "سبام", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
                                    //            });
                                    //            switch (msg)
                                    //            {
                                    //                case MessageBoxResult.Cancel:
                                    //                    return;
                                    //                case MessageBoxResult.Yes:
                                    //                    Thread.Sleep(5 * (60 * 1000));
                                    //                    break;
                                    //                case MessageBoxResult.No:
                                    //                    return;
                                    //                default:
                                    //                    break;
                                    //            }
                                    //            if (mModelComment.IsSleep)
                                    //            {
                                    //                switch (mModelComment.Unit)
                                    //                {
                                    //                    case "ثواني":
                                    //                        {
                                    //                            Thread.Sleep(mModelComment.Sleep * 1000);
                                    //                            break;
                                    //                        }
                                    //                    case "دقائق":
                                    //                        {
                                    //                            Thread.Sleep(mModelComment.Sleep * (60 * 1000));
                                    //                            break;
                                    //                        }
                                    //                    case "ساعات":
                                    //                        {
                                    //                            Thread.Sleep(mModelComment.Sleep * (60 * 60 * 1000));
                                    //                            break;
                                    //                        }
                                    //                }
                                    //            }

                                    //        }

                                    //        mModelComment.SentSuccess++;
                                    //        mModelComment.SendMentionSuccess += counterofMentions;
                                    //        counter = 0;
                                    //        virtualTag = mModelComment.Tag.Remove(0, mModelComment.Tag.IndexOf(Tag_.Value)).Replace(Tag_.Value, "");
                                    //        comment_.SendKeys(mModelComment.Text);
                                    //        //break;
                                    //    }

                                    //}
                                    //else
                                    //{

                                    //    comment_.SendKeys(" " + "@" + Tag_.Value + " ");
                                    //    comment_.SendKeys(Keys.Enter);
                                    //    mModelComment.SentSuccess++;
                                    //    mModelComment.SendMentionSuccess += counterofMentions;
                                    //    counterofMentions++;
                                    //}
                                    #endregion
                                    if (Regex.Matches(virtualTag, "[A-Za-z0-9.-=)(*&^%$#!?><,_-؛÷‘=}{:|/ ~]+[^@]").Count >= 5)
                                    {
                                        comment_.SendKeys(" " + "@" + Tag_.Value + " ");

                                        counterofMentions++;
                                        counter++;
                                        if (counter == 5)
                                        {


                                            //اعداد التهيئة للمنشور التالي
                                            comment_.SendKeys(Keys.Enter);

                                            var error = KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Text;
                                            Thread.Sleep(5 * 1000);
                                            if (KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Displayed && error.Contains("Couldn't post comment."))
                                            {
                                                mModelComment.UnableToSend++;
                                                MessageBoxResult msg = new MessageBoxResult();
                                                Application.Current.Dispatcher.Invoke(() =>
                                                {
                                                    LoggerViewModel.Log("Ops..! your Account Has been Bloocked", TypeOfLog.exclamationcircle);
                                                    msg = DXMessageBox.Show("يبدو ان حسابك قد تعرض للحظر المؤقت,هل ترغب بالمحاولة مرة اخرى بعد 5 دقائق؟", "سبام", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
                                                });
                                                switch (msg)
                                                {
                                                    case MessageBoxResult.Cancel:
                                                        return;
                                                    case MessageBoxResult.Yes:
                                                        Thread.Sleep(5 * (60 * 1000));
                                                        break;
                                                    case MessageBoxResult.No:
                                                        return;
                                                    default:
                                                        break;
                                                }

                                            }
                                            else
                                            {
                                                LoggerViewModel.Log(String.Format("Comment Posted With {0} Mentions", counterofMentions), TypeOfLog.check);
                                                mModelComment.SentSuccess++;
                                                mModelComment.SendMentionSuccess += counterofMentions;
                                                counterofMentions = 0;
                                                counter = 0;
                                                virtualTag = mModelComment.Tag.Remove(0, mModelComment.Tag.IndexOf(Tag_.Value)).Replace(Tag_.Value, "");
                                                if (mModelComment.IsSleep)
                                                {
                                                    switch (mModelComment.Unit)
                                                    {
                                                        case "ثواني":
                                                            {
                                                                Thread.Sleep(mModelComment.Sleep * 1000);
                                                                break;
                                                            }
                                                        case "دقائق":
                                                            {
                                                                Thread.Sleep(mModelComment.Sleep * (60 * 1000));
                                                                break;
                                                            }
                                                        case "ساعات":
                                                            {
                                                                Thread.Sleep(mModelComment.Sleep * (60 * 60 * 1000));
                                                                break;
                                                            }
                                                    }
                                                }
                                                //انتظار حتى يتم الارسال يمكننا الكتابة من جديد
                                                Thread.Sleep(3000);
                                                KernalWeb.Driver.ExecuteScript($"document.getElementsByTagName('textarea')[0].innerText='{mModelComment.Text}';");
                                                //break;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        //انتظار حتى يتم الارسال يمكننا الكتابة من جديد
                                        Thread.Sleep(3000);
                                        KernalWeb.Driver.ExecuteScript($"document.getElementsByTagName('textarea')[0].innerText='{mModelComment.Text}';");
                                        for (int ii = 0; ii < Regex.Matches(virtualTag, "[A-Za-z0-9.-=)(*&^%$#!?><,_-؛÷‘=}{ط:|/ ~]+[^@]").Count; ii++)
                                        {
                                            /*
                                            !)@($&%&*^$&(^656     بحاجة للتعديل
                                             */
                                            comment_.SendKeys(" " + "@" + Tag_.Value + " ");
                                            counterofMentions++;
                                        }

                                        comment_.SendKeys(Keys.Enter);
                                        var error = KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Text;
                                        Thread.Sleep(2 * 1000);
                                        if (KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Displayed && error.Contains("Couldn't post comment."))
                                        {
                                            MessageBoxResult msag = new MessageBoxResult();
                                            Application.Current.Dispatcher.Invoke(() =>
                                            {
                                                LoggerViewModel.Log("Ops..! your Account Has been Bloocked", TypeOfLog.exclamationcircle);
                                                msag = DXMessageBox.Show("يبدو ان حسابك قد تعرض للحظر المؤقت,هل تود بالمحاولة مرة اخرى بعد 5 دقائق؟", "سبام", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
                                            });
                                            switch (msag)
                                            {
                                                case MessageBoxResult.Cancel:
                                                    return;
                                                case MessageBoxResult.Yes:
                                                    Thread.Sleep(5 * (60 * 1000));
                                                    break;
                                                case MessageBoxResult.No:
                                                    return;
                                                default:
                                                    break;
                                            }

                                        }
                                        else
                                        {
                                            LoggerViewModel.Log(String.Format("Comment Posted With {0} Mentions", counterofMentions), TypeOfLog.check);
                                            mModelComment.SentSuccess++;
                                            mModelComment.SendMentionSuccess += counterofMentions;
                                            counterofMentions = 0;
                                            if (mModelComment.IsSleep)
                                            {
                                                switch (mModelComment.Unit)
                                                {
                                                    case "ثواني":
                                                        {
                                                            Thread.Sleep(mModelComment.Sleep * 1000);
                                                            break;
                                                        }
                                                    case "دقائق":
                                                        {
                                                            Thread.Sleep(mModelComment.Sleep * (60 * 1000));
                                                            break;
                                                        }
                                                    case "ساعات":
                                                        {
                                                            Thread.Sleep(mModelComment.Sleep * (60 * 60 * 1000));
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            break;
                        }


                    }
                }
            }





            LoggerViewModel.Log("Finished..!", TypeOfLog.check);








        }
        /// <summary>
        /// دالة ارسال  تعليق لمنشور محدد
        /// <![CDATA[****************بحاجة الى  تعديل  طريقة  ارسال التعليق ****************]]>
        /// </summary>
        /// <param name="TargetComment"></param>
        /// <returns></returns>
        public void SendComment(string TargetComment)
        {
            KernalWeb.Driver.Manage().Window.Maximize();
            KernalWeb.Driver.Navigate().GoToUrl(TargetComment);
            foreach (var comment_ in KernalWeb.Driver.FindElements(By.TagName("textarea")))
            {
                if (comment_.GetAttribute("placeholder").Contains("comment"))
                {
                    comment_.Click();
                    comment_.SendKeys("gfdgfd");
                    KernalWeb.Driver.ExecuteScript($"document.getElementsByTagName('textarea')[0].innerText='{mModelComment.Text}';");


                    if (!String.IsNullOrEmpty(mModelComment.Tag))
                    {
                        int counterofMentions = 0;
                        int counter = 0;
                        var virtualTag = mModelComment.Tag;
                        foreach (Match Tag_ in Regex.Matches(virtualTag, "[A-Za-z0-9.-=)(*&^%$#!?><,_-؛÷‘=}{:|/ ~]+[^@]"))
                        {
                            if (Regex.Matches(virtualTag, "[A-Za-z0-9.-=)(*&^%$#!?><,_-؛÷‘=}{:|/ ~]+[^@]").Count >= 5)
                            {
                                comment_.SendKeys(" " + "@" + Tag_.Value + " ");

                                counterofMentions++;
                                counter++;
                                if (counter == 5)
                                {


                                    //اعداد التهيئة للمنشور التالي
                                    comment_.SendKeys(Keys.Enter);

                                    var error = KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Text;
                                    Thread.Sleep(5 * 1000);
                                    if (KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Displayed && error.Contains("Couldn't post comment."))
                                    {
                                        mModelComment.UnableToSend++;
                                        MessageBoxResult msg = new MessageBoxResult();
                                        Application.Current.Dispatcher.Invoke(() =>
                                        {
                                            LoggerViewModel.Log("Ops..! your Account Has been Bloocked", TypeOfLog.exclamationcircle);
                                            msg = DXMessageBox.Show("يبدو ان حسابك قد تعرض للحظر المؤقت,هل ترغب بالمحاولة مرة اخرى بعد 5 دقائق؟", "سبام", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
                                        });
                                        switch (msg)
                                        {
                                            case MessageBoxResult.Cancel:
                                                return;
                                            case MessageBoxResult.Yes:
                                                Thread.Sleep(5 * (60 * 1000));
                                                break;
                                            case MessageBoxResult.No:
                                                return;
                                            default:
                                                break;
                                        }

                                    }
                                    else
                                    {
                                        LoggerViewModel.Log(String.Format("Comment Posted With {0} Mentions", counterofMentions), TypeOfLog.check);
                                        mModelComment.SentSuccess++;
                                        mModelComment.SendMentionSuccess += counterofMentions;
                                        counterofMentions = 0;
                                        counter = 0;
                                        virtualTag = mModelComment.Tag.Remove(0, mModelComment.Tag.IndexOf(Tag_.Value)).Replace(Tag_.Value, "");
                                        if (mModelComment.IsSleep)
                                        {
                                            switch (mModelComment.Unit)
                                            {
                                                case "ثواني":
                                                    {
                                                        Thread.Sleep(mModelComment.Sleep * 1000);
                                                        break;
                                                    }
                                                case "دقائق":
                                                    {
                                                        Thread.Sleep(mModelComment.Sleep * (60 * 1000));
                                                        break;
                                                    }
                                                case "ساعات":
                                                    {
                                                        Thread.Sleep(mModelComment.Sleep * (60 * 60 * 1000));
                                                        break;
                                                    }
                                            }
                                        }
                                        //انتظار حتى يتم الارسال يمكننا الكتابة من جديد
                                        Thread.Sleep(3000);
                                        comment_.SendKeys(mModelComment.Text);
                                        //break;
                                    }

                                }
                            }
                            else
                            {
                                //انتظار حتى يتم الارسال يمكننا الكتابة من جديد
                                Thread.Sleep(3000);
                                KernalWeb.Driver.ExecuteScript($"document.getElementsByTagName('textarea')[0].innerText='{mModelComment.Text}';");
                                for (int i = 0; i < Regex.Matches(virtualTag, "[A-Za-z0-9.-=)(*&^%$#!?><,_-؛÷‘=}{ط:|/ ~]+[^@]").Count; i++)
                                {
                                    comment_.SendKeys(" " + "@" + Tag_.Value + " ");
                                    counterofMentions++;
                                }

                                comment_.SendKeys(Keys.Enter);
                                var error = KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Text;
                                Thread.Sleep(2 * 1000);
                                if (KernalWeb.Driver.FindElement(By.ClassName("_162ov")).Displayed && error.Contains("Couldn't post comment."))
                                {
                                    MessageBoxResult msag = new MessageBoxResult();
                                    Application.Current.Dispatcher.Invoke(() =>
                                    {
                                        LoggerViewModel.Log("Ops..! your Account Has been Bloocked", TypeOfLog.exclamationcircle);
                                        msag = DXMessageBox.Show("يبدو ان حسابك قد تعرض للحظر المؤقت,هل تود بالمحاولة مرة اخرى بعد 5 دقائق؟", "سبام", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
                                    });
                                    switch (msag)
                                    {
                                        case MessageBoxResult.Cancel:
                                            return;
                                        case MessageBoxResult.Yes:
                                            Thread.Sleep(5 * (60 * 1000));
                                            break;
                                        case MessageBoxResult.No:
                                            return;
                                        default:
                                            break;
                                    }

                                }
                                else
                                {
                                    LoggerViewModel.Log(String.Format("Comment Posted With {0} Mentions", counterofMentions), TypeOfLog.check);
                                    mModelComment.SentSuccess++;
                                    mModelComment.SendMentionSuccess += counterofMentions;
                                    counterofMentions = 0;
                                    if (mModelComment.IsSleep)
                                    {
                                        switch (mModelComment.Unit)
                                        {
                                            case "ثواني":
                                                {
                                                    Thread.Sleep(mModelComment.Sleep * 1000);
                                                    break;
                                                }
                                            case "دقائق":
                                                {
                                                    Thread.Sleep(mModelComment.Sleep * (60 * 1000));
                                                    break;
                                                }
                                            case "ساعات":
                                                {
                                                    Thread.Sleep(mModelComment.Sleep * (60 * 60 * 1000));
                                                    break;
                                                }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            LoggerViewModel.Log("Finished..!", TypeOfLog.check);

        }

        public void SendComment_UNDERTEST()
        {
            var req = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/web/comments/1664931684115611920/add/");
            byte[] data = Encoding.UTF8.GetBytes("comment_text=hhhhhd");
            req.CookieContainer = KernalWeb.GetCookie();
            req.Referer = "https://www.instagram.com/p/BcVJwRTFDgA/?taken-by=dana14230002";
            req.Headers["X-Instagram-AJAX"] = "1";
            req.Headers["X-Requested-With"] = "XMLHttpRequest";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
            req.Method = "POST";
            req.ContentLength = data.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            string json = new StreamReader(req.GetResponse().GetResponseStream()).ReadToEnd();
            var respone = (HttpWebResponse)req.GetResponse();
            LoggerViewModel.Log(json, TypeOfLog.Warning);
            respone.Close();
        }
    }
}
