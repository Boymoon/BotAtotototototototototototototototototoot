using DevExpress.Xpf.Core;
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
    /// =+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+=
    /// هذه الفئة لاتختص بتسجيل الدخول فقط بل تجلب معلومات الحساب المدخل   
    /// مثل المتابعين والمتابعون واسم الحساب..
    /// ويتم البحث بواسطتها وتنفيذ الاوامر التالية  
    /// متابعة 
    /// الغاء متابعة ---> يتم العمل عليها 
    /// =+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+=
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        public ObservableCollection<AccountOperations> SelectedItems { get; set; } = new ObservableCollection<AccountOperations>();
        /// <summary>
        /// الاشخاص الغير متابعون
        /// </summary>
        ObservableCollection<int> indexer = new ObservableCollection<int>();

        /// <summary>
        /// متغير يحفظ رابط اخر عملية  
        /// </summary>
        private string CatchUidBeforeGetFollowers;

        private MainWindowViewModel mmMainWindowViewmodel;
        /// <summary>
        /// مجمع للمتابعين
        /// </summary>
        public ObservableCollectionCore<AccountOperations> Followers { get; set; }
        private AccountOperations AccountOperations_ = new AccountOperations();
        /// <summary>
        /// ارسال واستقبال الفئة  ModelLogin
        /// </summary>
        public AccountOperations AccountOperations
        {
            get => AccountOperations_;
            set => AccountOperations_ = value;
        }
        private AccountOperations Login_ = new AccountOperations();
        /// <summary>
        /// ارسال واستقبال الفئة  ModelLogin
        /// (خاصية محدودة اي انها ترتبط بعنصر جديد فور التحديد عليه في جدول (3
        /// (3):جدول عمليات الحساب المستهدف
        /// </summary>
        public AccountOperations Login
        {
            get => Login_;
            set
            {
                Login_ = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// اساس صفحة بيانات الحساب المدخل
        /// </summary>
        /// <param name="mainWindowViewModelm"></param>
        public LoginViewModel(MainWindowViewModel mainWindowViewModelm)
        {
            Followers = new ObservableCollectionCore<AccountOperations>();
            if (mainWindowViewModelm != null)
            {
                mmMainWindowViewmodel = mainWindowViewModelm;
            }
            SetInfoMember();
            AccountOperations.UnFollow_FollowCommand = new BaseCommand(Follow_UnFollow);
            AccountOperations.LogoutCommand = new BaseCommand((Logout));
            AccountOperations.SearchUsingOptionsCommand = new BaseCommand(SearchUsingOptionsCommand);
            AccountOperations.Clean = new BaseCommand(Clear);
            AccountOperations.CleanSelected = new BaseCommand(ClearSelected);
            AccountOperations.Follow = new BaseCommand(FollowSelected);
            AccountOperations.UnFollow = new BaseCommand(UnFollowSelected);
            Login = Login_;
            AccountOperations = AccountOperations_;


        }

        /// <summary>
        ///                                                    التعديل مهم       
        /// ***************************************************************************************************************
        /// دالة البحث والتنفيذ حسب الشروط
        /// الدالة ليست كاملة 
        /// تحتاج الى 
        /// 1-عمل متابعة-الغاء متابعة 
        /// زرين منفصلة من المذكور اعلاه 
        ///****************************************************************************************************************
        /// </summary>
        private void SearchUsingOptionsCommand()
        {
            LoggerViewModel.Log("Getting Started...", TypeOfLog.check);
            //تعريف فئة جلب البيانات
            var InfoMember = new InfoMember(mmMainWindowViewmodel.Selected.Username);
            var GetFollowers_ = new Followers(mmMainWindowViewmodel.Selected.Username);
            Task.Run(() => {
            GetFollowers_.GetFollowers(AccountOperations, AccountOperations.Uid, CollectionsHelper.Followers, indexer,this);
            });
            //جلب كل المتابعين و المُتابعون  على حسب  شروط المستخدم       
            bool t = true;
            if (!t)
            {

            Application.Current.Dispatcher.Invoke(() =>
            {

                Task b = Task.Run(() =>
                {
                    MessageBoxResult msgResult = new MessageBoxResult();
                    if (CatchUidBeforeGetFollowers != AccountOperations_.Uid || CollectionsHelper.Followers.Count == 0)
                    {

                        while (msgResult != MessageBoxResult.OK)
                        {
                            if (CatchUidBeforeGetFollowers == null || CatchUidBeforeGetFollowers != AccountOperations_.Uid 
                            ||msgResult==MessageBoxResult.OK 
                            )
                            {
                                CatchUidBeforeGetFollowers = AccountOperations_.Uid;
                                InfoMember.GetFollower(AccountOperations, CollectionsHelper.Followers, indexer, AccountOperations.Uid, Follow_UnFollow, this);
                                LoggerViewModel.Log(String.Format("Count of Followers {0}", CollectionsHelper.Followers.Count), TypeOfLog.check);
                                LoggerViewModel.Log("Finished", TypeOfLog.check);
                             //   HelperCollections<AccountOperations>.Add(CollectionsHelper.Followers);
                                break;
                            }
                            else
                            {
                                Application.Current.Dispatcher.Invoke(() => msgResult = DXMessageBox.Show("لديك نسخة من متابعين هذا الحساب ,هل تريد جلبهم من جديد؟", "اشعار", MessageBoxButton.OKCancel, MessageBoxImage.Information));

                            }
                        }
                    }
                    int indexer_ = 0;
                    //متغير للتحكم في الحلقة التالية
                    int RecheckForSpam = 0;
                    if (indexer.Count != 0)
                    {
                        for (int i = 0; i < indexer.Count;)
                        {
                            Task task_Async = Task.Run(() =>
                               {
                                   if (AccountOperations_.IsGetFollowup)
                                   {
                                       for (; indexer_ < CollectionsHelper.Followers.Count; indexer_++)
                                       {
                                           CollectionsHelper.Followers[indexer_].Followers = InfoMember.AsyncGetFollowers_(CollectionsHelper.Followers[indexer_].Uid, CollectionsHelper.Followers[indexer_].Username);
                                           if (Followers[indexer[i]].IsFollower.Equals(TypeOfResponse.Follow))
                                           {
                                               if (AccountOperations_.IsFollowWIthCondition)
                                               {
                                                   //اسناد قيمة الدالة Follow
                                                   CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, AccountOperations_, this);
                                                   AccountOperations_.IsFollower = CollectionsHelper.Followers[indexer[i]].IsFollower;
                                                   if (AccountOperations_.IsFollower == TypeOfResponse.Following)
                                                   {
                                                       //تنقيص من كمية المتابعين
                                                       AccountOperations_.AmountOfFollowers--;
                                                       //زيادة كمية المتابعون بمقدار 1 
                                                       AccountOperations_.AmountOfFollowing++;
                                                   }
                                                   else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                                   {
                                                       //تنقيص من كمية المتابعين
                                                       AccountOperations_.AmountOfFollowers--;
                                                       //زيادة كمية المتابعون بمقدار 1
                                                       AccountOperations_.AmountOfRequested++;
                                                   }
                                                   else if (AccountOperations_.IsFollower == TypeOfResponse.None)
                                                   {

                                                       while (RecheckForSpam == 0)
                                                       {
                                                           MessageBoxResult boxResult = new MessageBoxResult();
                                                           if (RecheckForSpam == 0)
                                                           {
                                                               LoggerViewModel.Log("Ops..! your Account Has been Bloocked", TypeOfLog.exclamationcircle);
                                                               Application.Current.Dispatcher.Invoke(() =>
                                                               {
                                                                   boxResult = DXMessageBox.Show("لقد تم حظر حسابك مؤقتاً,هل تريد الاستكمال بعد دقيقة؟", "تم حظر حسابك مؤقتاً", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                                               });
                                                               switch (boxResult)
                                                               {
                                                                   case MessageBoxResult.None:
                                                                       break;
                                                                   case MessageBoxResult.OK:
                                                                       {
                                                                           //تنويم البرنامج لمدة 5 دقائق لتفادي الحظر
                                                                           Thread.Sleep(1 * (60 * 1000));
                                                                           CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, CollectionsHelper.Followers[indexer[i]], this);
                                                                           switch (CollectionsHelper.Followers[indexer[i]].IsFollower)
                                                                           {
                                                                               case TypeOfResponse.Following:
                                                                                   RecheckForSpam = 1;
                                                                                   //تنقيص من كمية المتابعين
                                                                                   AccountOperations_.AmountOfFollowers--;
                                                                                   //زيادة كمية المتابعون بمقدار 1 
                                                                                   AccountOperations_.AmountOfFollowing++;
                                                                                   break;
                                                                               case TypeOfResponse.Requested:
                                                                                   //تنقيص من كمية المتابعين
                                                                                   AccountOperations_.AmountOfFollowers--;
                                                                                   //زيادة كمية المتابعون بمقدار 1
                                                                                   AccountOperations_.AmountOfRequested++;
                                                                                   RecheckForSpam = 1;
                                                                                   break;
                                                                           }
                                                                           break;
                                                                       }
                                                                   case MessageBoxResult.Cancel:
                                                                       //تنقيص  من كمية المتابعين
                                                                       AccountOperations_.AmountOfFollowers--;
                                                                       //زيادة في كمية الذين تعذر متابعتهم
                                                                       AccountOperations_.AmountOfNone++;
                                                                       RecheckForSpam = 1;
                                                                       break;
                                                                   default:
                                                                       break;
                                                               }

                                                           }
                                                       }

                                                   }
                                               }
                                               ///الفاصل الزمني بين كل عملية واخرى
                                               if (AccountOperations_.IsSleep)
                                               {
                                                   switch (AccountOperations_.Unit_Sleep)
                                                   {
                                                       case "ثواني":
                                                           {
                                                               Thread.Sleep(AccountOperations_.Sleep * 1000);
                                                               break;
                                                           }
                                                       case "دقائق":
                                                           {
                                                               Thread.Sleep(AccountOperations_.Sleep * (60 * 1000));
                                                               break;
                                                           }
                                                       case "ساعات":
                                                           {
                                                               Thread.Sleep(AccountOperations_.Sleep * (60 * 60 * 1000));
                                                               break;
                                                           }
                                                   }
                                               }
                                           }
                                       }

                                   }
                                   else
                                   {
                                       if (AccountOperations_.IsFollowWIthCondition)
                                       {
                                           if (CollectionsHelper.Followers[indexer[i]].IsFollower.Equals(TypeOfResponse.Follow))
                                           {

                                               CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, CollectionsHelper.Followers[indexer[i]], this);
                                               AccountOperations_.IsFollower =CollectionsHelper.Followers[indexer[i]].IsFollower;
                                               if (AccountOperations_.IsFollower == TypeOfResponse.Following)
                                               {
                                                   //تنقيص من كمية المتابعين
                                                   AccountOperations_.AmountOfFollowers--;
                                                   //زيادة كمية المتابعون بمقدار 1 
                                                   AccountOperations_.AmountOfFollowing++;
                                               }
                                               else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                               {
                                                   //تنقيص من كمية المتابعين
                                                   AccountOperations_.AmountOfFollowers--;
                                                   //زيادة كمية المتابعون بمقدار 1
                                                   AccountOperations_.AmountOfRequested++;
                                               }
                                               else if (AccountOperations_.IsFollower == TypeOfResponse.None)
                                               {

                                                   while (RecheckForSpam == 0)
                                                   {
                                                       MessageBoxResult boxResult = new MessageBoxResult();
                                                       if (RecheckForSpam == 0)
                                                       {
                                                           LoggerViewModel.Log("Ops..! your Account Has been Bloocked", TypeOfLog.exclamationcircle);
                                                           Application.Current.Dispatcher.Invoke(() =>
                                                           {
                                                               boxResult = DXMessageBox.Show("لقد تم حظر حسابك مؤقتاً,هل تريد الاستكمال بعد دقيقة؟", "تم حظر حسابك مؤقتاً", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                                           });
                                                           switch (boxResult)
                                                           {
                                                               case MessageBoxResult.None:
                                                                   break;
                                                               case MessageBoxResult.OK:
                                                                   {
                                                                       //تنويم البرنامج لمدة 5 دقائق لتفادي الحظر
                                                                       Thread.Sleep(1 * (60 * 1000));
                                                                       CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, CollectionsHelper.Followers[indexer[i]], this);
                                                                       switch (CollectionsHelper.Followers[indexer[i]].IsFollower)
                                                                       {
                                                                           case TypeOfResponse.Following:
                                                                               RecheckForSpam = 1;
                                                                               //تنقيص من كمية المتابعين
                                                                               AccountOperations_.AmountOfFollowers--;
                                                                               //زيادة كمية المتابعون بمقدار 1 
                                                                               AccountOperations_.AmountOfFollowing++;
                                                                               break;
                                                                           case TypeOfResponse.Requested:
                                                                               //تنقيص من كمية المتابعين
                                                                               AccountOperations_.AmountOfFollowers--;
                                                                               //زيادة كمية المتابعون بمقدار 1
                                                                               AccountOperations_.AmountOfRequested++;
                                                                               RecheckForSpam = 1;
                                                                               break;
                                                                       }
                                                                       break;
                                                                   }
                                                               case MessageBoxResult.Cancel:
                                                                   //تنقيص  من كمية المتابعين
                                                                   AccountOperations_.AmountOfFollowers--;
                                                                   //زيادة في كمية الذين تعذر متابعتهم
                                                                   AccountOperations_.AmountOfNone++;
                                                                   RecheckForSpam = 1;
                                                                   break;
                                                               default:
                                                                   break;
                                                           }

                                                       }
                                                   }

                                               }
                                               //الفاصل الزمني بين كل عملية واخرى
                                               if (AccountOperations_.IsSleep)
                                               {
                                                   switch (AccountOperations_.Unit_Sleep)
                                                   {
                                                       case "ثواني":
                                                           {
                                                               Thread.Sleep(AccountOperations_.Sleep * 1000);
                                                               break;
                                                           }
                                                       case "دقائق":
                                                           {
                                                               Thread.Sleep(AccountOperations_.Sleep * (60 * 1000));
                                                               break;
                                                           }
                                                       case "ساعات":
                                                           {
                                                               Thread.Sleep(AccountOperations_.Sleep * (60 * 60 * 1000));
                                                               break;
                                                           }
                                                   }
                                               }
                                           }
                                       }
                                   }
                               });
                            task_Async.Wait();
                            i++;
                        }
                    }
                    else
                    {
                        if (AccountOperations_.IsGetFollowup)
                        {

                            for (; indexer_ < CollectionsHelper.Followers.Count; indexer_++)
                            {
                                CollectionsHelper.Followers[indexer_].Followers = InfoMember.AsyncGetFollowers_(CollectionsHelper.Followers[indexer_].Uid, CollectionsHelper.Followers[indexer_].Username);
                                if (CollectionsHelper.Followers[indexer[indexer_]].IsFollower.Equals(TypeOfResponse.Follow))
                                {
                                    if (AccountOperations_.IsFollowWIthCondition)
                                    {
                                        //اسناد قيمة الدالة Follow
                                        CollectionsHelper.Followers[indexer[indexer_]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[indexer_]].Username, CollectionsHelper.Followers[indexer[indexer_]].Uid, AccountOperations_, this);
                                        AccountOperations_.IsFollower = CollectionsHelper.Followers[indexer[indexer_]].IsFollower;
                                        if (AccountOperations_.IsFollower == TypeOfResponse.Following)
                                        {
                                            //تنقيص من كمية المتابعين
                                            AccountOperations_.AmountOfFollowers--;
                                            //زيادة كمية المتابعون بمقدار 1 
                                            AccountOperations_.AmountOfFollowing++;
                                        }
                                        else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                        {
                                            //تنقيص من كمية المتابعين
                                            AccountOperations_.AmountOfFollowers--;
                                            //زيادة كمية المتابعون بمقدار 1
                                            AccountOperations_.AmountOfRequested++;
                                        }
                                        else if (AccountOperations_.IsFollower == TypeOfResponse.None)
                                        {

                                            while (RecheckForSpam == 0)
                                            {
                                                MessageBoxResult boxResult = new MessageBoxResult();
                                                if (RecheckForSpam == 0)
                                                {
                                                    LoggerViewModel.Log("Ops..! your Account Has been Bloocked", TypeOfLog.exclamationcircle);
                                                    Application.Current.Dispatcher.Invoke(() =>
                                                    {
                                                        boxResult = DXMessageBox.Show("لقد تم حظر حسابك مؤقتاً,هل تريد الاستكمال بعد دقيقة؟", "تم حظر حسابك مؤقتاً", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                                    });
                                                    switch (boxResult)
                                                    {
                                                        case MessageBoxResult.None:
                                                            break;
                                                        case MessageBoxResult.OK:
                                                            {
                                                                //تنويم البرنامج لمدة 1 دقائق لتفادي الحظر
                                                                Thread.Sleep(1 * (60 * 1000));
                                                                CollectionsHelper.Followers[indexer[indexer_]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[indexer_]].Username, CollectionsHelper.Followers[indexer[indexer_]].Uid, CollectionsHelper.Followers[indexer[indexer_]], this);
                                                                switch (CollectionsHelper.Followers[indexer[indexer_]].IsFollower)
                                                                {
                                                                    case TypeOfResponse.Following:
                                                                        RecheckForSpam = 1;
                                                                        //تنقيص من كمية المتابعين
                                                                        AccountOperations_.AmountOfFollowers--;
                                                                        //زيادة كمية المتابعون بمقدار 1 
                                                                        AccountOperations_.AmountOfFollowing++;
                                                                        break;
                                                                    case TypeOfResponse.Requested:
                                                                        //تنقيص من كمية المتابعين
                                                                        AccountOperations_.AmountOfFollowers--;
                                                                        //زيادة كمية المتابعون بمقدار 1
                                                                        AccountOperations_.AmountOfRequested++;
                                                                        RecheckForSpam = 1;
                                                                        break;
                                                                }
                                                                break;
                                                            }
                                                        case MessageBoxResult.Cancel:
                                                            //تنقيص  من كمية المتابعين
                                                            AccountOperations_.AmountOfFollowers--;
                                                            //زيادة في كمية الذين تعذر متابعتهم
                                                            AccountOperations_.AmountOfNone++;
                                                            RecheckForSpam = 1;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                }
                                            }

                                        }
                                    }
                                    ///الفاصل الزمني بين كل عملية واخرى
                                    if (AccountOperations_.IsSleep)
                                    {
                                        switch (AccountOperations_.Unit_Sleep)
                                        {
                                            case "ثواني":
                                                {
                                                    Thread.Sleep(AccountOperations_.Sleep * 1000);
                                                    break;
                                                }
                                            case "دقائق":
                                                {
                                                    Thread.Sleep(AccountOperations_.Sleep * (60 * 1000));
                                                    break;
                                                }
                                            case "ساعات":
                                                {
                                                    Thread.Sleep(AccountOperations_.Sleep * (60 * 60 * 1000));
                                                    break;
                                                }
                                        }
                                    }
                                }
                            }

                        }
                    }
                    if (AccountOperations_.IsGetFollowup)
                    {
                        Application.Current.Dispatcher.Invoke(() => LoggerViewModel.Log("Finished", TypeOfLog.check));
                        indexer.Clear();

                    }
                    //حفظ الرابط للعملية الحالية
                    CatchUidBeforeGetFollowers = AccountOperations_.Uid;
                });

            });
            }

        }

        /// <summary>
        /// دالة متابعة\الغاء متابعة
        /// </summary>
        private void Follow_UnFollow() => Task.Run(() => Follow_UnFollowTask());
        /// <summary>
        /// تاسك لدالة متابعة والغاء متابعة
        /// </summary>
        /// <returns></returns>
        private void Follow_UnFollowTask()
        {
            var waitingToFininsh = new TaskCompletionSource<bool>();
            //حالة الحساب قبل تنفيذ العملية
            var Before = CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].IsFollower;
            //تعريف متغير من اجل اسناد قيمة الدالة Follow
            var TypeOfRespone_ = new InfoMember(null).Follow(Login_.Username, Login_.Uid, null, this);

            if (TypeOfRespone_ == TypeOfResponse.Follow)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].IsFollower = TypeOfResponse.Follow;
                    switch (Before)
                    {
                        case TypeOfResponse.Follow:
                            AccountOperations_.AmountOfFollowers--;
                            AccountOperations_.AmountOfNone++;
                            LoggerViewModel.Log(String.Format("you have recently followed => {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.check);
                            break;
                        case TypeOfResponse.Following:
                            AccountOperations_.AmountOfFollowers++;
                            AccountOperations_.AmountOfFollowing--;
                            LoggerViewModel.Log(String.Format("you have been canceled => {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.check);
                            break;
                        case TypeOfResponse.Requested:
                            AccountOperations_.AmountOfFollowers++;
                            AccountOperations_.AmountOfRequested--;
                            LoggerViewModel.Log(String.Format("you have to wait your request to follow => {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.questioncircle);
                            break;
                        case TypeOfResponse.None:
                            AccountOperations_.AmountOfFollowers++;
                            AccountOperations_.AmountOfNone--;
                            LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);
                            break;

                    }
                    ////التعديل بعد كل عملية
                    //HelperCollections<AccountOperations>.Edit(CollectionsHelper.Followers, CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username, CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Uid);
                    waitingToFininsh.TrySetCanceled();

                });
            }
            else if (TypeOfRespone_ == TypeOfResponse.Following)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {

                    CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].IsFollower = TypeOfResponse.Following;
                    switch (Before)
                    {
                        case TypeOfResponse.Follow:
                            AccountOperations_.AmountOfFollowers++;
                            AccountOperations_.AmountOfFollowing--;
                            LoggerViewModel.Log(String.Format("you have recently followed {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                            break;
                        case TypeOfResponse.Following:
                            AccountOperations_.AmountOfNone++;
                            AccountOperations_.AmountOfFollowing--;
                            LoggerViewModel.Log(String.Format("you have been canceled {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                            break;
                        case TypeOfResponse.Requested:
                            AccountOperations_.AmountOfFollowing++;
                            AccountOperations_.AmountOfRequested--;
                            LoggerViewModel.Log(String.Format("you have to wait your request to follow {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.questioncircle);

                            break;
                        case TypeOfResponse.None:
                            AccountOperations_.AmountOfFollowing++;
                            AccountOperations_.AmountOfNone--;
                            LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);

                            break;

                    }
                    ////التعديل بعد كل عملية
                    //HelperCollections<AccountOperations>.Edit(CollectionsHelper.Followers, CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username, CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Uid);
                    waitingToFininsh.TrySetCanceled();

                });
            }
            else if (TypeOfRespone_ == TypeOfResponse.Requested)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Task.Run(() =>
                    {
                        CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].IsFollower = TypeOfResponse.Requested;
                        switch (Before)
                        {
                            case TypeOfResponse.Follow:
                                AccountOperations_.AmountOfFollowers--;
                                AccountOperations_.AmountOfRequested++;
                                LoggerViewModel.Log(String.Format("you have recently followed {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                                break;
                            case TypeOfResponse.Following:
                                AccountOperations_.AmountOfFollowing--;
                                AccountOperations_.AmountOfRequested++;
                                LoggerViewModel.Log(String.Format("you have been canceled {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                                break;
                            case TypeOfResponse.Requested:
                                AccountOperations_.AmountOfNone++;
                                AccountOperations_.AmountOfRequested--;
                                LoggerViewModel.Log(String.Format("you have to wait your request to follow {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.questioncircle);

                                break;
                            case TypeOfResponse.None:
                                AccountOperations_.AmountOfRequested++;
                                AccountOperations_.AmountOfNone--;
                                LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);

                                break;

                        }
                        ////التعديل بعد كل عملية
                        //HelperCollections<AccountOperations>.Edit(CollectionsHelper.Followers, CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username, CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Uid);
                        waitingToFininsh.TrySetCanceled();
                    });
                });
            }
            else if (TypeOfRespone_ == TypeOfResponse.None)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Task.Run(() =>
                    {
                        CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].IsFollower = TypeOfResponse.None;
                        switch (Before)
                        {
                            case TypeOfResponse.Follow:
                                AccountOperations_.AmountOfFollowers--;
                                AccountOperations_.AmountOfNone++;
                                LoggerViewModel.Log(String.Format("you have recently followed {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                                break;
                            case TypeOfResponse.Following:
                                AccountOperations_.AmountOfFollowers--;
                                AccountOperations_.AmountOfNone++;
                                LoggerViewModel.Log(String.Format("you have been canceled {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                                break;
                            case TypeOfResponse.Requested:
                                AccountOperations_.AmountOfNone++;
                                AccountOperations_.AmountOfRequested--;
                                LoggerViewModel.Log(String.Format("you have to wait your request to follow {0}", CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username), TypeOfLog.questioncircle);

                                break;
                            case TypeOfResponse.None:
                                AccountOperations_.AmountOfNone++;
                                LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);

                                break;

                        }
                        ////التعديل بعد كل عملية
                        //HelperCollections<AccountOperations>.Edit(CollectionsHelper.Followers, CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Username, CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(Login_)].Uid);
                        waitingToFininsh.TrySetCanceled();
                    });
                });
            }

            LoggerViewModel.Log("Finished", TypeOfLog.check);


        }
        /// <summary>
        /// دالة جلب بيانات الحساب المدخل 
        /// </summary>
        private void SetInfoMember()
        {

            //انشاء تاسك منفصلة لجلب بيانات الحساب المدخل
            Task.Run(() =>
            {
                //حلقة لانهائية تدور حتى تجد بيانات الحساب المدخل
                while (true)
                {
                    try
                    {
                    //التحقق من الحساب
                    if (mmMainWindowViewmodel.ModelMainWindow.IsLogedin)
                    {
                        //تعريف فئة جلب البيانات
                        var InfoMember = new InfoMember(mmMainWindowViewmodel.Selected.Username);
                        //التحقق من حقل المتابعين 
                        if (!String.IsNullOrEmpty(AccountOperations_.Follower))
                        {
                            //اسناد اسم الحساب
                            AccountOperations_.Username = InfoMember.Getname();
                            //اسناد المُتابعون
                            AccountOperations_.Following = InfoMember.GetFollowing();
                            //الخروج من الحلقة
                            break;
                        }
                        else
                        {
                            AccountOperations_.Follower = InfoMember.GetFollower();
                        }
                    }
                    }
                    catch (Exception) { }
                }
                if (String.IsNullOrEmpty(AccountOperations_.Follower))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LoggerViewModel.Log("Failed to login ):", TypeOfLog.exclamationcircle);
                    });
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LoggerViewModel.Log("You have LogIn Successfully", TypeOfLog.check);
                    });
                }
            });
        }
        /// <summary>
        /// دالة تسجيل الخروج
        /// </summary>
        private void Logout()
        {
            LoggerViewModel.Log("Getting Started To Logout..!", TypeOfLog.Warning);

            try
            {
                //نٌعلم البرنامج اننا خرجنا من الحساب كي يرجع صفحة تسجيل الدخول
                mmMainWindowViewmodel.ModelMainWindow.IsLogedin = false;
                //حذف كامل البيانات للدخول السابق
                AccountOperations_.Username = String.Empty;
                AccountOperations_.Follower = String.Empty;
                AccountOperations_.Following = String.Empty;
                KernalWeb.Driver.Manage().Cookies.DeleteAllCookies();
                InfoMember.Cancel = true;
                mmMainWindowViewmodel.ModelMainWindow.StateOfLogin = "تسجيل الدخول";
                KernalWeb.Driver.Navigate().Refresh();
                LoggerViewModel.Log("You have loged out Successfully", TypeOfLog.check);
                //نخبر البرنامج ان يرجع الى دالة جلب البيانات  حتى يتحقق من البيانات للدخول التالي
                SetInfoMember();

            }
            catch (Exception)
            {
                LoggerViewModel.Log("Ops..! something went wrong", TypeOfLog.exclamationcircle);
            }
        }
        /// <summary>
        /// دالة  حذف عناصر  جدول المتابعين
        /// </summary>
        private void Clear()
        {
            CollectionsHelper.Followers.Clear();
        }
        /// <summary>
        /// TODO:<see cref="SelectedItems"/> الغاء متابعة المتابعين المحددين في    
        /// </summary>
        private void UnFollowSelected()
        {
            Task.Run(() => {
                if (SelectedItems.Count == 0)
                {
                    return;
                }
                var listOfAccounts = new List<AccountOperations>(SelectedItems.Where(t => t.IsFollower == TypeOfResponse.Following|| t.IsFollower == TypeOfResponse.Requested).ToList());
                for (int i = 0; i < listOfAccounts.Count; i++)
                {
                    Login_ = listOfAccounts[i];
                    Follow_UnFollow();
                    Task.Run(() => {
                        Refresh();

                    });
                }
            });
        }
        /// <summary>
        /// TODO:<see cref="SelectedItems"/> متابعة المتابعين المحددين في
        /// </summary>
        private void FollowSelected()
        {
            Task.Run(() => {
            if (SelectedItems.Count == 0)
            {
                return;
            }
            var listOfAccounts = new List<AccountOperations>(SelectedItems.Where(t => t.IsFollower == TypeOfResponse.Follow).ToList());
            for (int i = 0; i < listOfAccounts.Count; i++)
            {
                Login_ = listOfAccounts[i];
                Follow_UnFollow();
                    Task.Run(() => {
               Refresh();

                    });
            }
            });

        }
        /// <summary>
        /// مسح المتابعين المحددين
        /// </summary>
        private void ClearSelected()
        {
            
            Task.Run(() => 
            {
            var ListOfAccount = new List<AccountOperations>(from parent in SelectedItems
                                                            where (CollectionsHelper.Followers.IndexOf(parent) != -1)                                                           
                                                            select parent).ToList();
            for (int i = 0; i < ListOfAccount.Count; i++)
            {
                    Application.Current.Dispatcher.Invoke(() => {
                       LoggerViewModel.Log($"#Deleted:{CollectionsHelper.Followers.Remove(ListOfAccount[i])}", TypeOfLog.check);
                    });
            }
                Refresh();
            });
          
        }
        /// <summary>
        /// تحديث الاحصائيات
        /// </summary>
         private void Refresh()
        {
            AccountOperations.AmountOfRequested = (from Accounts_ in CollectionsHelper.Followers
                                                   where (Accounts_.IsFollower == TypeOfResponse.Requested)
                                                   select Accounts_).ToList().Count;
            AccountOperations.AmountOfFollowers = (from Accounts_ in CollectionsHelper.Followers
                                                   where (Accounts_.IsFollower == TypeOfResponse.Follow)
                                                   select Accounts_).ToList().Count;
            AccountOperations.AmountOfFollowing = (from Accounts_ in CollectionsHelper.Followers
                                                   where (Accounts_.IsFollower == TypeOfResponse.Following)
                                                   select Accounts_).ToList().Count;
            AccountOperations.AmountOfNone      = (from Accounts_ in CollectionsHelper.Followers
                                                   where (Accounts_.IsFollower == TypeOfResponse.None)
                                                   select Accounts_).ToList().Count;
            AccountOperations.Amount = CollectionsHelper.Followers.Count;
        }

    }
}
