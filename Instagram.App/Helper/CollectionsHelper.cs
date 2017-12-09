using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instagram.App
{
    public static class CollectionsHelper
    {
        /// <summary>
        /// قاعدة البيانات الحالية المراد التعامل معها
        /// </summary>
        private static PostsDB PostsDB_;
        /// <summary>
        /// قاعدة البيانات الحالية المراد التعامل معها
        /// </summary>
        private static FollowersDB FollowersDB_=new FollowersDB();
        /// <summary>
        /// قاعدة البيانات الحالية المراد التعامل معها
        /// </summary>
        private static SearchDB SearchDB_;
        private static string NameOfSelectedTableOfPosts_;
        private static string NameOfSelectedTableOfComments_;
        private static string NameOfSelectedTableOfFollowers_;
        /// <summary>
        /// الجدول المختار  من قسم المنشورات
        /// </summary>
        public static string NameOfSelectedTableOfPosts
        {
            get
            {
               
                return NameOfSelectedTableOfPosts_;
            }
            set { NameOfSelectedTableOfPosts_ = value; }
        }
        /// <summary>
        /// الان مقتصر على المنشورات فقط 
        /// يلزم له اضافة جدول المنشنز المرسلة 
        /// +
        /// جدول التعليقات المرسلة
        /// الجدول المختار  من قسم التعليقات والمنشورات والمنشن
        /// </summary>
        public static string NameOfSelectedTableOfComments
        {
            get
            {
               
                return NameOfSelectedTableOfComments_;
            }
            set { NameOfSelectedTableOfComments_ = value; }
        }
        /// <summary>
        /// الجدول المختار  من قسم عمليات الحساب
        /// </summary>
        public static string NameOfSelectedTableOfFollowers
        {
            get
            {

                return NameOfSelectedTableOfFollowers_;
            }
            set
            {
                
                NameOfSelectedTableOfFollowers_ = value;
            }
        }
        private static ObservableCollection<AccountOperations> Followers_;
        private static ObservableCollection<ModelPost> Posts_;
        private static ObservableCollection<ModelComment> Comments_;
        /// <summary>
        /// جدول المتابعين للحساب المستهدف
        /// </summary>
        public static ObservableCollection<AccountOperations> Followers
        {
            //get
            //{

            //    if (Followers_ == null || Followers_.Count == 0)
            //    {
            //        return Followers_;
            //    }
            //    HelperSelector.Insert(Followers_);
            //    return Followers_;
            //}
            //private set {
            //    try
            //    {

            //    Followers_ = HelperSelector.ParentOfFollowersTable[HelperSelector.Tables.IndexOf(HelperSelector.selectedTable)];
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}


            get { return Followers_; }
            set { Followers_ = value; }
        }
        /// <summary>
        /// جدول المتابعين للحساب المستهدف
        /// </summary>
        public static ObservableCollection<ModelPost> Posts
        {
            get
            {

                return Posts_;

            }
            private set { Posts_ = value; }
        }
        /// <summary>
        /// جدول المنشورات او التعليقات
        /// </summary>
        public static ObservableCollection<ModelComment> Comments { get { return Comments_; } private set { Comments_ = value; } }

        public static void Init()
        {

            Posts = new ObservableCollection<ModelPost>();
            Followers = new ObservableCollection<AccountOperations>();
            Comments = new ObservableCollection<ModelComment>();
        }
        /// <summary>
        /// تحقق من العناصر المكررة 
        /// </summary>
        private static void CheckRepeated<T, U, M>(ObservableCollection<AccountOperations> _CollectionOfUsers, T _Collection = null, U _collection1 = null, M _collection2 = null)
            where T : AccountOperations
            where U : ModelPost
            where M : ModelComment
        {
            try
            {
                if (_Collection != null)
                {
                    var _check = (from _del in _CollectionOfUsers
                                  where (_del.Uid == _Collection.Uid)
                                  select _del).ToList();
                    //LoggerViewModel.Log($"Count of _checkCollection:{_check.ToList().Count}", TypeOfLog.questioncircle);
                    Application.Current.Dispatcher.Invoke(() => {

                    bool _delete = _check.Count > 1 ? _CollectionOfUsers.Remove(_Collection) : _check.Remove(_Collection);
                    });
                }
                else if (_collection1 != null)
                {
                    var _check = Posts.Where(_del => _del == _collection1);
                    bool _delete = _check.ToList().Count > 1 ? Posts.Remove(_collection1) : _check.ToList().Remove(_collection1);
                }
                else if (_collection2 != null)
                {
                    var _check = Comments.Where(_del => _del == _collection2);
                    bool _delete = _check.ToList().Count > 1 ? Comments.Remove(_collection2) : _check.ToList().Remove(_collection2);
                }
            }
            catch (Exception)
            {
                LoggerViewModel.Log("Class:CollectionHelper,Line:44,method:CheckRepeated", TypeOfLog.exclamationcircle);
            }
        }
        /// <summary>
        /// تحقق من العناصر المكررة 
        /// </summary>
        public static void CheckRepeated(ObservableCollection<AccountOperations> _CollectionOfUsers, AccountOperations _c1 = null, ModelPost _c2 = null, ModelComment _c3 = null)
        {
            CheckRepeated<AccountOperations, ModelPost, ModelComment>(_CollectionOfUsers,_c1, _c2, _c3);
        }
        /// <summary>
        /// اضافة بيانات الى قاعدة البيانات
        /// </summary>
        /// <param name="m1">قسم1</param>
        /// <param name="m2">قسم2</param>
        /// <param name="m3">قسم3</param>
        /// <param name="name">اسم الجدول المراد الاضافة فيه</param>
        public static void Push(string name, AccountOperations m1 = null, ModelPost m2 = null, ModelComment m3 = null,List<AccountOperations> _Range=null)
        {
            /* m -> model */
            if (m1 == null && m2 == null && m3 == null)
            {
                LoggerViewModel.Log($"Something went wrong in CollectionsHelper Method Push Line 279~284", TypeOfLog.Warning);
                return;
            }
         
                if (m1 != null)
                {
                        try
                        {
                    var addrange_ = (from range in _Range
                                     let ran = new string[] { range.Username, range.Uid, range.Followers.ToString(), range.IsFollower.ToString(),"0" }
                                     select ran).ToList();
                            if (HelperSelector.regestirTables.IndexOf(HelperSelector.regestirTables.Where(item => item.NameOfTheTable == name).First()) == -1)
                            {
                                LoggerViewModel.Log($"Table Doesn't exist:{name}", TypeOfLog.exclamationcircle);
                        //FollowersDB_.InsertItem(name, new string[] { $"{m1.Username}", $"{m1.Uid}", $"{m1.Followers}", $"{m1.IsFollower}", "0" });
                        FollowersDB_.InsertItem(name, new string[] { $"{m1.Username}", $"{m1.Uid}", $"{m1.Followers}", $"{m1.IsFollower}", "0" });

                    }
                    else
                    {


                        //FollowersDB_.InsertItem(name, new string[] { $"{m1.Username}", $"{m1.Uid}", $"{m1.Followers}", $"{m1.IsFollower}", "0" });
                        FollowersDB_.InsertRange(name, addrange_);


                    }
                }
                        catch (Exception)
                        {
                        }
             

                    }
                
                    else if (m2 != null)
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                if (HelperSelector.regestirTables.IndexOf(HelperSelector.regestirTables.Where(item => item.NameOfTheTable == name).First()) == -1)
                                {
                                    LoggerViewModel.Log($"Table Doesn't exist:{name}", TypeOfLog.exclamationcircle);
                                    PostsDB_.InsertItem(name, new string[] { m2.ContextMedia, m2.UidOfpost, m2.Context, m2.publisher, m2.publishedat, m2.UidOfpublisher, m2.Likes, m2.Views, $"0" });

                                }
                                else
                                {
                                    PostsDB_.InsertItem(name, new string[] { m2.ContextMedia, m2.UidOfpost, m2.Context, m2.publisher, m2.publishedat, m2.UidOfpublisher, m2.Likes, m2.Views, $"0" });
                                }
                            }
                            catch (Exception)
                            {
                            }

                          
                        });
                    }

         
        }
     
   
    }
}
