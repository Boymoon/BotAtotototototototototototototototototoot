using DevExpress.Xpf.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Instagram.App
{
    /// <summary>
    /// =+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+=
    /// هذه الفئة لاتختص بتسجيل الدخول فقط بل تجلب معلومات الحساب المدخل   -> FIXED
    /// مثل المتابعين والمتابعون واسم الحساب.. -> FIXED
    /// ويتم البحث بواسطتها وتنفيذ الاوامر التالية   -> FIXED
    /// متابعة -> FIXED
    /// الغاء متابعة ---> يتم العمل عليها -> FIXED
    /// =================================================
    ///  -------------------- Things needs to be fix or add ---------------------
    ///  1-اضافة لودنج للحذف
    ///  2-اضافة لودنج للمتابعة\الغاء المتابعة عبر الجدول
    /// =+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+==+=+=+=+=+=+=+=+=+=
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// كونتكست لتحميل تسجيل الخروج
        /// </summary>
        public LoadingModel LoadingOfLogout { get; set; }

        private ModelTable selectedtablee_ = new ModelTable();
        /// <summary>
        /// معلومات الجداول
        /// </summary>
        public ModelTable SelectedTable_
        {
            get { return selectedtablee_; }
            set
            {
                if (value != null)
                {
                    selectedtablee_ = value; selectedtable = value.NameOfTheTable;
                    DataContextOfModelTable.NameOfTheTable = value.NameOfTheTable;

                }
            }
        }
        public ObservableCollection<ModelTable> Tables
        {
            get
            {
                  return new ObservableCollection<ModelTable>(HelperSelector.regestirTables.Where(item_type => item_type.typessections == TypesSections.FollowersSection));
           
            }
        }
        /// <summary>
        /// كونتكست للجداول
        /// </summary>
        public ModelTable DataContextOfModelTable { get; set; }
        /// <summary>
        /// حالة العملية
        /// </summary>
        public static bool CancelCurrentOperation { get; private set; }
        /// <summary>
        /// العناصر المحددة
        /// </summary>
        public ObservableCollection<AccountOperations> SelectedItems { get; set; } = new ObservableCollection<AccountOperations>();
        /// <summary>
        /// الاشخاص الغير متابعون
        /// </summary>
        ObservableCollection<int> indexer = new ObservableCollection<int>();

        /// <summary>
        /// متغير يحفظ رابط اخر عملية  
        /// </summary>
        private string CatchUidBeforeGetFollowers;
        private ObservableCollection<AccountOperations> Followers_;
        private MainWindowViewModel mmMainWindowViewmodel;
        /// <summary>
        /// مجمع للمتابعين
        /// </summary>
        public ObservableCollection<AccountOperations> Followers { get { Task.Run(() => Refresh()); return Followers_;  } set { Followers_ = value; } }
        private string selectedtable_;
        /// <summary>
        /// الجدول المحدد
        /// </summary>
        public string selectedtable
        {
            get { return selectedtable_; }
            set
            {
                selectedtable_ = value;
                try
                {
                    if (value != null && HelperSelector.regestirTables.IndexOf(HelperSelector.regestirTables.Where(item => item.NameOfTheTable == value).First()) != -1)
                    {

                        Followers = new ObservableCollection<AccountOperations>(HelperSelector.ParentOfFollowersTable[HelperSelector.regestirTables.IndexOf(HelperSelector.regestirTables.Where(item => item.NameOfTheTable == value).First())]);
                    }

                }
                catch (Exception ex)
                {

                }
                OnPropertyChanged("Followers");
            }
        }

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
            DataContextOfModelTable = new ModelTable();
            LoadingOfLogout = new LoadingModel();
            SelectedTable_ = new ModelTable();
            Followers = new ObservableCollection<AccountOperations>();
            if (mainWindowViewModelm != null)
            {
                mmMainWindowViewmodel = mainWindowViewModelm;
            }
            SetInfoMember();
            AccountOperations.UnFollow_FollowCommand = new BaseCommand(Follow_UnFollow);
            AccountOperations.LogoutCommand = new BaseCommand((Logout));
            AccountOperations.SearchUsingOptionsCommand = new BaseCommand(SearchUsingOptionsCommand);
            AccountOperations.Clean = new BaseCommand(Clear);
            AccountOperations.Cancel = new BaseCommand(Cancel);
            AccountOperations.CleanSelected = new BaseCommand(ClearSelected);
            AccountOperations.Follow = new BaseCommand(FollowSelected);
            AccountOperations.UnFollow = new BaseCommand(UnFollowSelected);
            DataContextOfModelTable.EditCurrentTable = new BaseCommand(EditCurrentTable);
            DataContextOfModelTable.DeleteCurrentTable = new BaseCommand(DeleteCurrentTable);
            DataContextOfModelTable.AddNewTable = new BaseCommand(AddNewTable);
            OnPropertyChanged("Tables");

            Login = Login_;
            AccountOperations = AccountOperations_;
        }
        /// <summary>
        /// اضافة جدول جديد
        /// </summary>
        private void AddNewTable()
        {
            HelperSelector.AddTable(new ObservableCollection<AccountOperations>(), DataContextOfModelTable.NameOfTheTable);
            OnPropertyChanged("Tables");
        }
        /// <summary>
        /// حذف الجدول الحالي
        /// </summary>
        private void DeleteCurrentTable()
        {
            HelperSelector.DeleteTable(SelectedTable_, SelectedTable_.NameOfTheTable, TypesSections.FollowersSection);
            OnPropertyChanged("Tables");
            OnPropertyChanged("Followers");
        }
        /// <summary>
        /// التعديل على الجدول الحالي
        /// </summary>
        private void EditCurrentTable()
        {
            HelperSelector.EditTable(SelectedTable_.NameOfTheTable, DataContextOfModelTable.NameOfTheTable);
            OnPropertyChanged("Tables");
        }

        /// <summary>
        /// الغاء العمليات الخاصة بواجهة الحسابات -جلب المتابعين وعملياتها 
        /// <![CDATA[يتم الغاء نوعين  من العمليات فقط ,جلب  المتابعين,متابعة-الغاء متابعة -جلب عدد المتابعين ]]>
        /// </summary>
        private void Cancel()
        {
            /* الغاء العملية الحالية */
            Instagram.App.Followers.Cancel = true;
            AccountOperations.IsRunning = false;
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

            if (AccountOperations_.IsRunning)
            {
                Cancel();
                return;
            }
            /* اعدادات البحث السريع عن المتابعين */
            #region Settings_BeforeBeginSearchForFollowers
            Instagram.App.Followers.Cancel = false;
            AccountOperations.ContentbtnLoading = "جاري الاتصال";
            AccountOperations.IsRunning = true;
            LoggerViewModel.Log("Getting Started...", TypeOfLog.check);
            #endregion
            //تعريف فئة جلب البيانات
            var InfoMember = new InfoMember(mmMainWindowViewmodel.Selected.Username);
            var GetFollowers_ = new Followers(mmMainWindowViewmodel.Selected.Username);
            //GetFollowers_.GetFollowers(AccountOperations, AccountOperations.Uid, CollectionsHelper.Followers, indexer, this);

            //جلب كل المتابعين و المُتابعون  على حسب  شروط المستخدم       
            bool t = true;
            if (t)
            {

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Task b = Task.Run(() =>
                    {
                        MessageBoxResult msgResult = new MessageBoxResult();
                        if (CatchUidBeforeGetFollowers != AccountOperations_.Uid || CollectionsHelper.Followers.Count == 0 && AccountOperations_.IsRunning || AccountOperations_.IsRunning)
                        {

                            while (msgResult != MessageBoxResult.Cancel && AccountOperations_.IsRunning)
                            {
                                if (CatchUidBeforeGetFollowers == null || CatchUidBeforeGetFollowers != AccountOperations_.Uid
                                || msgResult == MessageBoxResult.OK
                                )
                                {
                                    CatchUidBeforeGetFollowers = AccountOperations_.Uid;
                                    if (AccountOperations_.GetFollowers && AccountOperations_.GetFollowings)
                                    {
                                        GetFollowers_.GetFollows(AccountOperations, AccountOperations.Uid, Followers, indexer, this);
                                        GetFollowers_.GetFollowings(AccountOperations, AccountOperations.Uid, Followers, indexer, this);
                                    }
                                    else if (AccountOperations_.GetFollowings)
                                    {
                                        GetFollowers_.GetFollowings(AccountOperations, AccountOperations.Uid, Followers, indexer, this);
                                    }
                                    else
                                    {
                                        GetFollowers_.GetFollows(AccountOperations, AccountOperations.Uid, Followers, indexer, this);
                                    }

                                    CollectionsHelper.Followers = new ObservableCollection<AccountOperations>(Followers_);
                                    string testnamefortable = null;

                                    try
                                    {
                                        if (selectedtable == null || HelperSelector.regestirTables.IndexOf(HelperSelector.regestirTables.Where(item => item.NameOfTheTable == selectedtable).First()) == -1)
                                        {
                                            var newtbl = $"ttable{HelperSelector.regestirTables.Count}";
                                            testnamefortable = newtbl;

                                            HelperSelector.Insert(new ObservableCollection<AccountOperations>(CollectionsHelper.Followers), newtbl);
                                        }
                                        else
                                        {
                                            Application.Current.Dispatcher.Invoke(() => {

                                                HelperSelector.Insert(new ObservableCollection<AccountOperations>(CollectionsHelper.Followers), selectedtable);
                                                OnPropertyChanged("Tables");
                                                selectedtable = selectedtable_;
                                            });

                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    CollectionsHelper.Push(selectedtable, CollectionsHelper.Followers[1], null, null, CollectionsHelper.Followers.ToList());
                                    OnPropertyChanged("Tables");
                                    for (int i = 0; i < CollectionsHelper.Followers.Count; i++)
                                    {
                                        if (selectedtable != null)
                                        {

                                            CollectionsHelper.Push(selectedtable, CollectionsHelper.Followers[i], null, null,CollectionsHelper.Followers.ToList());
                                            OnPropertyChanged("Tables");
                                            
                                        }
                                        else
                                        {

                                            CollectionsHelper.Push(testnamefortable, CollectionsHelper.Followers[i], null, null);
                                            OnPropertyChanged("Tables");

                                        }
                                    }

                                    AccountOperations_.IsRunning = true;
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

                            for (int i = 0; i < indexer.Count && AccountOperations_.IsRunning;)
                            {
                                Task task_Async = Task.Run(() =>
                                   {
                                       if (AccountOperations_.IsGetFollowup && AccountOperations_.IsRunning)
                                       {
                                           AccountOperations.ContentbtnLoading = "جاري جلب عدد المتابعين";
                                           AccountOperations.IsRunning = true;
                                           for (; indexer_ < CollectionsHelper.Followers.Count; indexer_++)
                                           {
                                               CollectionsHelper.Followers[indexer_].Followers = InfoMember.AsyncGetFollowers_(CollectionsHelper.Followers[indexer_].Uid, CollectionsHelper.Followers[indexer_].Username);
                                               if (Followers[indexer[i]].IsFollower.Equals(TypeOfResponse.Follow))
                                               {
                                                   if (AccountOperations_.IsFollowWIthCondition)
                                                   {
                                                       /*   UNDER TEST !@#$%^&*(^()*$*(%))^&*($&%*^_&*(%_$^%   */

                                                       #region UnderTest
                                                       /* متابعة */
                                                       if (AccountOperations_.FollowAll)
                                                       {
                                                           if (CollectionsHelper.Followers[indexer[i]].IsFollower.Equals(TypeOfResponse.Follow))
                                                           {

                                                               CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, CollectionsHelper.Followers[indexer[i]], this);
                                                               AccountOperations_.IsFollower = CollectionsHelper.Followers[indexer[i]].IsFollower;
                                                               if (AccountOperations_.IsFollower == TypeOfResponse.Following)
                                                               {
                                                                   Refresh();

                                                               }
                                                               else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                                               {
                                                                   Refresh();

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
                                                                                       //تنويم البرنامج لمدة دقيقة لتفادي الحظر
                                                                                       Thread.Sleep(1 * (60 * 1000));
                                                                                       CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, CollectionsHelper.Followers[indexer[i]], this);
                                                                                       switch (CollectionsHelper.Followers[indexer[i]].IsFollower)
                                                                                       {
                                                                                           case TypeOfResponse.Following:
                                                                                               RecheckForSpam = 1;
                                                                                               Refresh();

                                                                                               break;
                                                                                           case TypeOfResponse.Requested:
                                                                                               Refresh();

                                                                                               RecheckForSpam = 1;
                                                                                               break;
                                                                                       }
                                                                                       break;
                                                                                   }
                                                                               case MessageBoxResult.Cancel:
                                                                                   Refresh();

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
                                                       /* الغاء المتابعة */
                                                       else if (AccountOperations_.UnFollowAll)
                                                       {
                                                           if (CollectionsHelper.Followers[indexer_] != CollectionsHelper.Followers[indexer[i]]
                                                           && !CollectionsHelper.Followers[indexer_].IsFollower.Equals(TypeOfResponse.Follow))
                                                           {

                                                               CollectionsHelper.Followers[indexer_].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer_].Username, CollectionsHelper.Followers[indexer_].Uid, CollectionsHelper.Followers[indexer_], this);
                                                               AccountOperations_.IsFollower = CollectionsHelper.Followers[indexer_].IsFollower;
                                                               if (AccountOperations_.IsFollower == TypeOfResponse.Following)
                                                               {
                                                                   Refresh();

                                                               }
                                                               else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                                               {
                                                                   Refresh();

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
                                                                                       CollectionsHelper.Followers[indexer_].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer_].Username, CollectionsHelper.Followers[indexer_].Uid, CollectionsHelper.Followers[indexer_], this);
                                                                                       switch (CollectionsHelper.Followers[indexer_].IsFollower)
                                                                                       {
                                                                                           case TypeOfResponse.Following:
                                                                                               RecheckForSpam = 1;
                                                                                               Refresh();

                                                                                               break;
                                                                                           case TypeOfResponse.Requested:
                                                                                               Refresh();

                                                                                               RecheckForSpam = 1;
                                                                                               break;
                                                                                       }
                                                                                       break;
                                                                                   }
                                                                               case MessageBoxResult.Cancel:
                                                                                   Refresh();

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
                                                       #endregion

                                                       #region OldCode

                                                       /*   ORIGINAL -IMPORTANT- !@#$%^&*(^()*$*(%))^&*($&%*^_&*(%_$^%   */
                                                       //#region Original

                                                       ////اسناد قيمة الدالة Follow
                                                       //CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, AccountOperations_, this);
                                                       //AccountOperations_.IsFollower = CollectionsHelper.Followers[indexer[i]].IsFollower;
                                                       //if (AccountOperations_.IsFollower == TypeOfResponse.Following)
                                                       //{
                                                       //    //تنقيص من كمية المتابعين
                                                       //    AccountOperations_.AmountOfFollowers--;
                                                       //    //زيادة كمية المتابعون بمقدار 1 
                                                       //    AccountOperations_.AmountOfFollowing++;
                                                       //}
                                                       //else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                                       //{
                                                       //    //تنقيص من كمية المتابعين
                                                       //    AccountOperations_.AmountOfFollowers--;
                                                       //    //زيادة كمية المتابعون بمقدار 1
                                                       //    AccountOperations_.AmountOfRequested++;
                                                       //}
                                                       //else if (AccountOperations_.IsFollower == TypeOfResponse.None)
                                                       //{

                                                       //    while (RecheckForSpam == 0)
                                                       //    {
                                                       //        MessageBoxResult boxResult = new MessageBoxResult();
                                                       //        if (RecheckForSpam == 0)
                                                       //        {
                                                       //            LoggerViewModel.Log("Ops..! your Account Has been Bloocked", TypeOfLog.exclamationcircle);
                                                       //            Application.Current.Dispatcher.Invoke(() =>
                                                       //            {
                                                       //                boxResult = DXMessageBox.Show("لقد تم حظر حسابك مؤقتاً,هل تريد الاستكمال بعد دقيقة؟", "تم حظر حسابك مؤقتاً", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                                       //            });
                                                       //            switch (boxResult)
                                                       //            {
                                                       //                case MessageBoxResult.None:
                                                       //                    break;
                                                       //                case MessageBoxResult.OK:
                                                       //                    {
                                                       //                        //تنويم البرنامج لمدة 5 دقائق لتفادي الحظر
                                                       //                        Thread.Sleep(1 * (60 * 1000));
                                                       //                        CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, CollectionsHelper.Followers[indexer[i]], this);
                                                       //                        switch (CollectionsHelper.Followers[indexer[i]].IsFollower)
                                                       //                        {
                                                       //                            case TypeOfResponse.Following:
                                                       //                                RecheckForSpam = 1;
                                                       //                                //تنقيص من كمية المتابعين
                                                       //                                AccountOperations_.AmountOfFollowers--;
                                                       //                                //زيادة كمية المتابعون بمقدار 1 
                                                       //                                AccountOperations_.AmountOfFollowing++;
                                                       //                                break;
                                                       //                            case TypeOfResponse.Requested:
                                                       //                                //تنقيص من كمية المتابعين
                                                       //                                AccountOperations_.AmountOfFollowers--;
                                                       //                                //زيادة كمية المتابعون بمقدار 1
                                                       //                                AccountOperations_.AmountOfRequested++;
                                                       //                                RecheckForSpam = 1;
                                                       //                                break;
                                                       //                        }
                                                       //                        break;
                                                       //                    }
                                                       //                case MessageBoxResult.Cancel:
                                                       //                    //تنقيص  من كمية المتابعين
                                                       //                    AccountOperations_.AmountOfFollowers--;
                                                       //                    //زيادة في كمية الذين تعذر متابعتهم
                                                       //                    AccountOperations_.AmountOfNone++;
                                                       //                    RecheckForSpam = 1;
                                                       //                    break;
                                                       //                default:
                                                       //                    break;
                                                       //            }

                                                       //        }
                                                       //    }

                                                       //}
                                                       #endregion
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
                                           if (AccountOperations_.IsFollowWIthCondition && AccountOperations_.IsRunning)
                                           {
                                               /* متابعة */
                                               if (AccountOperations_.FollowAll && AccountOperations_.IsRunning)
                                               {
                                                   AccountOperations.ContentbtnLoading = $"{CollectionsHelper.Followers[indexer[i]].Username} جاري متابعة";
                                                   AccountOperations.IsRunning = true;
                                                   if (CollectionsHelper.Followers[indexer[i]].IsFollower.Equals(TypeOfResponse.Follow))
                                                   {

                                                       CollectionsHelper.Followers[indexer[i]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[i]].Username, CollectionsHelper.Followers[indexer[i]].Uid, CollectionsHelper.Followers[indexer[i]], this);
                                                       AccountOperations_.IsFollower = CollectionsHelper.Followers[indexer[i]].IsFollower;
                                                       if (AccountOperations_.IsFollower == TypeOfResponse.Following)
                                                       {
                                                           Refresh();

                                                       }
                                                       else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                                       {
                                                           Refresh();

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
                                                                                       Refresh();

                                                                                       break;
                                                                                   case TypeOfResponse.Requested:
                                                                                       Refresh();

                                                                                       RecheckForSpam = 1;
                                                                                       break;
                                                                               }
                                                                               break;
                                                                           }
                                                                       case MessageBoxResult.Cancel:
                                                                           Refresh();

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
                                               /* الغاء المتابعة */
                                               else if (AccountOperations_.UnFollowAll && AccountOperations_.IsRunning)
                                               {
                                                   indexer_ = indexer[i];
                                                   AccountOperations.ContentbtnLoading = $"{CollectionsHelper.Followers[indexer[i]].Username} جاري الغاء متابعة";
                                                   AccountOperations.IsRunning = true;
                                                   if (CollectionsHelper.Followers[indexer_] == CollectionsHelper.Followers[indexer[i]]
                                                   && !CollectionsHelper.Followers[indexer_].IsFollower.Equals(TypeOfResponse.Follow)
                                                   && AccountOperations_.IsRunning)
                                                   {
                                                       CollectionsHelper.Followers[indexer_].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer_].Username, CollectionsHelper.Followers[indexer_].Uid, CollectionsHelper.Followers[indexer_], this);
                                                       AccountOperations_.IsFollower = CollectionsHelper.Followers[indexer_].IsFollower;
                                                       if (AccountOperations_.IsFollower == TypeOfResponse.Following
                                                       )
                                                       {
                                                           Refresh();

                                                       }
                                                       else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                                       {
                                                           Refresh();

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
                                                                               CollectionsHelper.Followers[indexer_].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer_].Username, CollectionsHelper.Followers[indexer_].Uid, CollectionsHelper.Followers[indexer_], this);
                                                                               switch (CollectionsHelper.Followers[indexer_].IsFollower)
                                                                               {
                                                                                   case TypeOfResponse.Following:
                                                                                       RecheckForSpam = 1;
                                                                                       break;
                                                                                   case TypeOfResponse.Requested:
                                                                                       RecheckForSpam = 1;
                                                                                       break;
                                                                               }
                                                                               Refresh();

                                                                               break;

                                                                           }
                                                                       case MessageBoxResult.Cancel:

                                                                           RecheckForSpam = 1;
                                                                           Refresh();

                                                                           break;
                                                                       default:
                                                                           break;
                                                                   }

                                                               }
                                                           }

                                                       }
                                                       //الفاصل الزمني بين كل عملية واخرى
                                                       if (AccountOperations_.IsSleep && AccountOperations_.IsRunning)
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
                                   });
                                task_Async.Wait();
                                i++;
                            }
                        }
                        else
                        {
                            if (AccountOperations_.IsGetFollowup && AccountOperations_.IsRunning)
                            {

                                for (; indexer_ < CollectionsHelper.Followers.Count && AccountOperations_.IsRunning; indexer_++)
                                {
                                    CollectionsHelper.Followers[indexer_].Followers = InfoMember.AsyncGetFollowers_(CollectionsHelper.Followers[indexer_].Uid, CollectionsHelper.Followers[indexer_].Username);
                                    if (CollectionsHelper.Followers[indexer[indexer_]].IsFollower.Equals(TypeOfResponse.Follow) && AccountOperations_.IsRunning)
                                    {
                                        if (AccountOperations_.IsFollowWIthCondition && AccountOperations_.IsRunning)
                                        {
                                            //اسناد قيمة الدالة Follow
                                            CollectionsHelper.Followers[indexer[indexer_]].IsFollower = InfoMember.Follow(CollectionsHelper.Followers[indexer[indexer_]].Username, CollectionsHelper.Followers[indexer[indexer_]].Uid, AccountOperations_, this);
                                            AccountOperations_.IsFollower = CollectionsHelper.Followers[indexer[indexer_]].IsFollower;
                                            if (AccountOperations_.IsFollower == TypeOfResponse.Following)
                                            {
                                                Refresh();

                                            }
                                            else if (AccountOperations_.IsFollower == TypeOfResponse.Requested)
                                            {
                                                Refresh();

                                            }
                                            else if (AccountOperations_.IsFollower == TypeOfResponse.None)
                                            {

                                                while (RecheckForSpam == 0 && AccountOperations_.IsRunning)
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
                                                                            break;
                                                                        case TypeOfResponse.Requested:

                                                                            RecheckForSpam = 1;

                                                                            break;
                                                                    }
                                                                    Refresh();
                                                                    break;
                                                                }
                                                            case MessageBoxResult.Cancel:
                                                                Refresh();

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
                                        if (AccountOperations_.IsSleep && AccountOperations_.IsRunning)
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
                        }
                        //حفظ الرابط للعملية الحالية
                        CatchUidBeforeGetFollowers = AccountOperations_.Uid;
                        AccountOperations_.IsRunning = false;
                        AccountOperations_.ContentbtnLoading = "جاري الاتصال";
                        indexer.Clear();
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
            var Before = Followers[Followers.IndexOf(Login_)].IsFollower;
            //تعريف متغير من اجل اسناد قيمة الدالة Follow
            var TypeOfRespone_ = new InfoMember(null).Follow(Login_.Username, Login_.Uid, null, this);

            if (TypeOfRespone_ == TypeOfResponse.Follow)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Followers[Followers.IndexOf(Login_)].IsFollower = TypeOfResponse.Follow;
                    switch (Before)
                    {
                        case TypeOfResponse.Follow:
                            Refresh();
                            LoggerViewModel.Log(String.Format("you have recently followed => {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.check);
                            break;
                        case TypeOfResponse.Following:
                            Refresh();
                            LoggerViewModel.Log(String.Format("you have been canceled => {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.check);
                            break;
                        case TypeOfResponse.Requested:
                            Refresh();
                            LoggerViewModel.Log(String.Format("you have to wait your request to follow => {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.questioncircle);
                            break;
                        case TypeOfResponse.None:
                            Refresh();
                            LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);
                            break;

                    }
                    ////التعديل بعد كل عملية
                    //HelperCollections<AccountOperations>.Edit(Followers, Followers[Followers.IndexOf(Login_)].Username, Followers[Followers.IndexOf(Login_)].Uid);
                    waitingToFininsh.TrySetCanceled();

                });
            }
            else if (TypeOfRespone_ == TypeOfResponse.Following)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {

                    Followers[Followers.IndexOf(Login_)].IsFollower = TypeOfResponse.Following;
                    switch (Before)
                    {
                        case TypeOfResponse.Follow:
                            Refresh();
                            LoggerViewModel.Log(String.Format("you have recently followed {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                            break;
                        case TypeOfResponse.Following:
                            Refresh();
                            LoggerViewModel.Log(String.Format("you have been canceled {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                            break;
                        case TypeOfResponse.Requested:
                            Refresh();
                            LoggerViewModel.Log(String.Format("you have to wait your request to follow {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.questioncircle);

                            break;
                        case TypeOfResponse.None:
                            Refresh();
                            LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);

                            break;

                    }
                    ////التعديل بعد كل عملية
                    //HelperCollections<AccountOperations>.Edit(Followers, Followers[Followers.IndexOf(Login_)].Username, Followers[Followers.IndexOf(Login_)].Uid);
                    waitingToFininsh.TrySetCanceled();

                });
            }
            else if (TypeOfRespone_ == TypeOfResponse.Requested)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Task.Run(() =>
                    {
                        Followers[Followers.IndexOf(Login_)].IsFollower = TypeOfResponse.Requested;
                        switch (Before)
                        {
                            case TypeOfResponse.Follow:
                                Refresh();
                                LoggerViewModel.Log(String.Format("you have recently followed {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                                break;
                            case TypeOfResponse.Following:
                                Refresh();
                                LoggerViewModel.Log(String.Format("you have been canceled {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                                break;
                            case TypeOfResponse.Requested:
                                Refresh();
                                LoggerViewModel.Log(String.Format("you have to wait your request to follow {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.questioncircle);

                                break;
                            case TypeOfResponse.None:
                                Refresh();
                                LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);

                                break;

                        }
                        ////التعديل بعد كل عملية
                        //HelperCollections<AccountOperations>.Edit(Followers, Followers[Followers.IndexOf(Login_)].Username, Followers[Followers.IndexOf(Login_)].Uid);
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
                        Followers[Followers.IndexOf(Login_)].IsFollower = TypeOfResponse.None;
                        switch (Before)
                        {
                            case TypeOfResponse.Follow:
                                Refresh();
                                LoggerViewModel.Log(String.Format("you have recently followed {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                                break;
                            case TypeOfResponse.Following:
                                Refresh();
                                LoggerViewModel.Log(String.Format("you have been canceled {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.check);

                                break;
                            case TypeOfResponse.Requested:
                                Refresh();
                                LoggerViewModel.Log(String.Format("you have to wait your request to follow {0}", Followers[Followers.IndexOf(Login_)].Username), TypeOfLog.questioncircle);

                                break;
                            case TypeOfResponse.None:
                                Refresh();
                                LoggerViewModel.Log("Ops..! your account has been Blocked ", TypeOfLog.exclamationcircle);

                                break;

                        }
                        ////التعديل بعد كل عملية
                        //HelperCollections<AccountOperations>.Edit(Followers, Followers[Followers.IndexOf(Login_)].Username, Followers[Followers.IndexOf(Login_)].Uid);
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
                            var InfoMember = new User("https://www.instagram.com/" + mmMainWindowViewmodel.Selected.Username.Split('@')[0] + "/");
                            //تعريف فئة جلب البيانات
                            //التحقق من حقل المتابعين 
                            if (!String.IsNullOrEmpty(AccountOperations_.Follower))
                            {
                                //اسناد اسم الحساب
                                AccountOperations_.Username = InfoMember.username;
                                //اسناد المُتابعون
                                AccountOperations_.Following = InfoMember.follows;
                                //الخروج من الحلقة
                                break;
                            }
                            else
                            {
                                AccountOperations_.Follower = InfoMember.followed_by;
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
            Cancel();
            LoadingOfLogout.IsRunning = true;
            LoggerViewModel.Log("Getting Started To Logout..!", TypeOfLog.Warning);
            try
            {
               
                    MessageBoxResult messageBoxResult = DXMessageBox.Show("هل تريد حذف جميع بيانات هذه الجلسة؟", "رسالة تحذيرية", MessageBoxButton.YesNoCancel, MessageBoxImage.Hand);
                    switch (messageBoxResult)
                    {
                        case MessageBoxResult.None:
                            LoadingOfLogout.IsRunning = false;
                        
                            return;
                        case MessageBoxResult.OK:
                            break;
                        case MessageBoxResult.Cancel:
                            LoadingOfLogout.IsRunning = false;
                            return;
                        /* تحتاج مراجعة */
                        case MessageBoxResult.Yes:
                            Followers.Clear();
                        break;
                        case MessageBoxResult.No:
                            break;
                        default:
                            break;
                    }

                Task.Run(() => {

                    try
                    {
                        if (messageBoxResult==MessageBoxResult.Yes)
                        {
                           HelperSelector.ClearCurrentSession();
                        }
                        KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
                        KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 5);

                        AccountOperations_.Username = "-";
                        AccountOperations_.Follower = "";
                        AccountOperations_.Following = "";
                        foreach (Cookie item in KernalWeb.Driver.Manage().Cookies.AllCookies)
                        {
                            try
                            {

                            KernalWeb.Driver.Manage().Cookies.DeleteCookie(item);
                            }
                            catch (Exception)
                            {

                                
                            }
                        }
                        InfoMember.Cancel = true;
                        mmMainWindowViewmodel.ModelMainWindow.StateOfLogin = "تسجيل الدخول";
                        KernalWeb.Driver.Navigate().Refresh();
                        try
                        {

                        HelperSelector.ClearCurrentSession();
                        }
                        catch (Exception ex)
                        {

                            LoggerViewModel.Log($"Line 1169 Error:{ex.Message}", TypeOfLog.exclamationcircle);

                        }
                        LoggerViewModel.Log("You have loged out Successfully", TypeOfLog.check);
                        
                        OnPropertyChanged("Tables");
                        mmMainWindowViewmodel.ModelMainWindow.IsLogedin = false;
                        LoadingOfLogout.IsRunning = false;
                    }
                    catch (Exception ex)
                    {

                        LoggerViewModel.Log($"There's something went wrong => {ex.Message}", TypeOfLog.exclamationcircle);
                        mmMainWindowViewmodel.ModelMainWindow.IsLogedin = true;
                        LoadingOfLogout.IsRunning = false;
                    }
             
                //نخبر البرنامج ان يرجع الى دالة جلب البيانات  حتى يتحقق من البيانات للدخول التالي
                });
                Task.Run(() =>
                {
                while (mmMainWindowViewmodel.ModelMainWindow.IsLogedin) { }
                SetInfoMember();
                });


            }
            catch (Exception)
            {
                LoggerViewModel.Log("Ops..! something went wrong", TypeOfLog.exclamationcircle);
                LoadingOfLogout.IsRunning = false;
            }
            KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 1, 0);
            KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
        }
        /// <summary>
        /// دالة  حذف عناصر  جدول المتابعين
        /// </summary>
        private void Clear()
        {
          MessageBoxResult _MsgRslt=DXMessageBox.Show("هل انت متاكد من رغبتك بحذف عناصر هذا الجدول؟","تحذير",MessageBoxButton.YesNoCancel,MessageBoxImage.Question);
            switch (_MsgRslt)
            {
                case MessageBoxResult.Yes:
                    {
                        Followers.Clear();

                        new FollowersDB().ResetTable(selectedtablee_.NameOfTheTable);

                        break;
                    }
                default:
                    {
                        return;
                    }
            }
        }
        /// <summary>
        /// TODO:<see cref="SelectedItems"/> الغاء متابعة المتابعين المحددين في    
        /// </summary>
        private void UnFollowSelected()
        {
            Task.Run(() =>
            {
                if (SelectedItems.Count == 0)
                {
                    return;
                }

                var listOfAccounts = new List<AccountOperations>(SelectedItems.Where(t => t.IsFollower == TypeOfResponse.Following || t.IsFollower == TypeOfResponse.Requested).ToList());
                for (int i = 0; i < listOfAccounts.Count; i++)
                {
                    Login_ = listOfAccounts[i];
                    Follow_UnFollowTask();
                    Task.Run(() =>
                    {
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
            Task.Run(() =>
            {
                if (SelectedItems.Count == 0)
                {
                    return;
                }
                var listOfAccounts = new List<AccountOperations>(SelectedItems.Where(t => t.IsFollower == TypeOfResponse.Follow).ToList());
                for (int i = 0; i < listOfAccounts.Count; i++)
                {
                    Login_ = listOfAccounts[i];
                    Follow_UnFollowTask();
                    Task.Run(() =>
                    {
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
            if (SelectedItems.Count == 1)
            {
                MessageBoxResult msgrslt = DXMessageBox.Show($"هل انت متاكد  من رغبتك بحذف العنصر الحالي؟", "تحذير", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (msgrslt)
                {
                    case MessageBoxResult.Yes: { break; }
                    default:
                        {
                            return;
                        }
                }
            }
            else if (SelectedItems.Count > 1)
            {
                MessageBoxResult msgrslt = DXMessageBox.Show($"هل انت متاكد  من رغبتك بحذف العناصر الحالية؟", "تحذير", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (msgrslt)
                {
                    case MessageBoxResult.Yes: { break; }
                    default:
                        {
                            return;
                        }
                }
            }

            Task.Run(() =>
            {
                var ListOfAccount = new List<AccountOperations>(from parent in SelectedItems
                                                                where (Followers.IndexOf(parent) != -1)
                                                                select parent).ToList();
                for (int i = 0; i < ListOfAccount.Count; i++)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LoggerViewModel.Log($"#Deleted:{Followers.Remove(ListOfAccount[i])}", TypeOfLog.check);
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
            try
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
            AccountOperations.AmountOfNone = (from Accounts_ in CollectionsHelper.Followers
                                              where (Accounts_.IsFollower == TypeOfResponse.None)
                                              select Accounts_).ToList().Count;
            AccountOperations.Amount = CollectionsHelper.Followers.Count;

            }
            catch (Exception)
            {

            }
        }
     



    }
}
