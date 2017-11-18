using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static FollowersDB FollowersDB_;
        /// <summary>
        /// قاعدة البيانات الحالية المراد التعامل معها
        /// </summary>
        private static SearchDB SearchDB_;
        public static string NameOfSelectedTableOfPosts_;
        public static string NameOfSelectedTableOfComments_;
        public static string NameOfSelectedTableOfFollowers_;
        /// <summary>
        /// الجدول المختار  من قسم المنشورات
        /// </summary>
        public static string NameOfSelectedTableOfPosts
        {
            get
            {
                if (!PostsDB_.Check(NameOfSelectedTableOfPosts_))
                {
                    return NameOfSelectedTableOfPosts_ = "p14";
                }
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
                if (!PostsDB_.Check(NameOfSelectedTableOfPosts_))
                {
                    return NameOfSelectedTableOfPosts_ = "p14";
                }
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
            set {
                if (!FollowersDB_.Check(NameOfSelectedTableOfFollowers_))
                {
                    value = "f14";
                }
                NameOfSelectedTableOfFollowers_ = value; }
        }

        private static ObservableCollectionCore<AccountOperations> Followers_;
        private static ObservableCollection<ModelPost> Posts_;
        private static ObservableCollection<ModelComment> Comments_;
        /// <summary>
        /// جدول المتابعين للحساب المستهدف
        /// </summary>
        public static ObservableCollectionCore<AccountOperations> Followers
        {
            get
            {
                if (Followers_ == null || Followers_.Count == 0)
                {
                    return Followers_;
                }
               var t=Task.Run(() =>
                {
                    if (NameOfSelectedTableOfFollowers_ == "f14")
                    {
                        FollowersDB_.AddTable<string>($"Username TEXT," +
                            $"Uid TEXT," +
                            $"Following TEXT," +
                            $"Followers TEXT," +
                            $"IsFollower TEXT",
                            "f14");
                        FollowersDB_.InsertItem<string>($"(Username,Uid,Following,Followers,IsFollower) " +
                           $"Values('{Followers_[Followers_.Count - 1].Username}'," +
                           $"'{Followers_[Followers_.Count - 1].Uid}'," +
                           $"'{Followers_[Followers_.Count - 1].Following}'," +
                           $"'{Followers_[Followers_.Count - 1].Followers}'," +
                           $"'{Followers_[Followers_.Count - 1].IsFollower}')",
                           NameOfSelectedTableOfFollowers_);
                    }
                    else
                    {
                        FollowersDB_.InsertItem<string>("$(Username,Uid,Following,Followers,IsFollower) " +
                            $"Values('{Followers_[Followers_.Count - 1].Username}'," +
                            $"'{Followers_[Followers_.Count - 1].Uid}'," +
                            $"'{Followers_[Followers_.Count - 1].Following}'," +
                            $"'{Followers_[Followers_.Count - 1].IsFollower}')",
                            NameOfSelectedTableOfFollowers_);
                    }
                });
                return Followers_;
            }
            private set { Followers_ = value; }
        }
        /// <summary>
        /// جدول المتابعين للحساب المستهدف
        /// </summary>
        public static ObservableCollection<ModelPost> Posts
        {
            get
            {
                if (Posts_ == null || Posts_.Count == 0)
                {
                    return Posts_;
                }
                Task.Run(() =>
                {

                    if (NameOfSelectedTableOfPosts_ == "p14")
                    {
                        PostsDB_.AddTable<string>($"ContextMedia TEXT," +
                            $"UidOfpost TEXT," +
                            $"Context TEXT," +
                            $"publisher TEXT ," +
                            $"publishedat TEXT ," +
                            $"UidOfpublisher TEXT ," +
                            $"Likes TEXT ," +
                            $"Views TEXT ",
                            "p14");
                    }
                    else
                    {
                        PostsDB_.InsertItem<string>($"(ContextMedia" +
                            $",Uidofpost" +
                            $",Context" +
                            $",publisher" +
                            $",publishedat" +
                            $",UidOfpublisher," +
                            $"Likes," +
                            $"Views) " +
                            $"Values" +
                            $"('{Posts_[Posts_.Count - 1].ContextMedia}'" +
                            $"'{Posts_[Posts_.Count - 1].UidOfpost}'" +
                            $"'{Posts_[Posts_.Count - 1].Context}'" +
                            $"'{Posts_[Posts_.Count - 1].publisher}'" +
                            $"'{Posts_[Posts_.Count - 1].publishedat}'" +
                            $"'{Posts_[Posts_.Count - 1].UidOfpublisher}'" +
                            $"'{Posts_[Posts_.Count - 1].Likes}'" +
                            $"'{Posts_[Posts_.Count - 1].Views}'" +
                            $")", NameOfSelectedTableOfPosts_);
                    }
                });
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
            PostsDB_ = new PostsDB(new MainDB());
            FollowersDB_ = new FollowersDB(new MainDB());
            Posts = new ObservableCollection<ModelPost>();
            Followers = new ObservableCollectionCore<AccountOperations>();
            Comments = new ObservableCollection<ModelComment>();
        }
        /// <summary>
        /// تحقق من العناصر المكررة 
        /// </summary>
        private static void CheckRepeated<T, U, M>(T _Collection = null, U _collection1 = null, M _collection2 = null)
            where T : AccountOperations
            where U : ModelPost
            where M : ModelComment
        {
            try
            {
                if (_Collection != null)
                {
                    var _check = (from _del in Followers
                                  where (_del.Uid == _Collection.Uid)
                                  select _del).ToList();
                    //LoggerViewModel.Log($"Count of _checkCollection:{_check.ToList().Count}", TypeOfLog.questioncircle);
                    bool _delete = _check.Count > 1 ? Followers.Remove(_Collection) : _check.Remove(_Collection);
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
        public static void CheckRepeated(AccountOperations _c1 = null, ModelPost _c2 = null, ModelComment _c3 = null)
        {
            CheckRepeated<AccountOperations, ModelPost, ModelComment>(_c1, _c2, _c3);
        }
    }
}
