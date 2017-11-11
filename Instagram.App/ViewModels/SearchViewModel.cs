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
    public class SearchViewModel : BaseViewModel
    {
        /// <summary>
        /// مكان حفظ العناصر المحددة في  جدول  المنشورات الخاص بواجهة البحث
        /// </summary>
        public ObservableCollection<ModelPost> SelectedItems { get; set; }

        private CurrentPostModel DataContextOfCurrentPost_ = new CurrentPostModel();

        public CurrentPostModel DataContextOfCurrentPost
        {
            get { return DataContextOfCurrentPost_; }
            set { DataContextOfCurrentPost_ = value; }
        }

        private ModelSearch DataContext_ = new ModelSearch();

        public ModelSearch DataContext
        {
            get { return DataContext_; }
            set { DataContext_ = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// ملاحظة:<![CDATA[سيتم  تعديل هذا المتغير الى  اخر  ]]>
        /// <!--مهم-->
        /// </summary>
        public ContainerCollection<ObservableCollection<ModelPost>> container { get; } = new ContainerCollection<ObservableCollection<ModelPost>>();

        private Search _search { get; set; }
        private CurrentPostModel CurrentPost_ = new CurrentPostModel();

        public CurrentPostModel CurrentPost
        {
            get { return CurrentPost_; }
            set { CurrentPost_ = value; }
        }
        private ModelPost _selected = new ModelPost();
        public ModelPost Selected
        {
            get { return _selected; }
            set
            {
                _selected = value; CurrentPost_.Context = value.Context;
                CurrentPost_.ContextMedia = value.ContextMedia;
                CurrentPost_.Username = value.publisher;
            }
        }

        private CancellationTokenSource cts = new CancellationTokenSource();

        /// <summary>
        ///  المنشورات
        /// </summary>
        public ObservableCollection<ModelPost> Posts { get; }
        private CurrentPostViewModel _ViewModelOfCurrentPost;
        public SearchViewModel()
        {
            _search = new Search(DataContext_);
            var ViewModelOfCurrentPost = new CurrentPostViewModel(DataContextOfCurrentPost_, container);
            _ViewModelOfCurrentPost = ViewModelOfCurrentPost;
            Posts = new ObservableCollection<ModelPost>();
            DataContext_.SearchCommand = new BaseCommand(Search);
            DataContext_.DeleteCommand = new BaseCommand(Delete);
            DataContext_.SaveInDataBaseCommand = new BaseCommand(SaveTo);
            DataContext_.CancelSearchCommand = new BaseCommand(EndSearch);
            DataContextOfCurrentPost_.EditCommand = new BaseCommand(ViewModelOfCurrentPost.EditOfTablename);
            DataContextOfCurrentPost_.SaveCommandOfTablename = new BaseCommand(ViewModelOfCurrentPost.SaveOfTablename);
            DataContextOfCurrentPost_.CustomizeSaveCommand = new BaseCommand(ViewModelOfCurrentPost.CustomizeSave);
            DataContextOfCurrentPost_.SaveCommand = new BaseCommand(Save);
            SelectedItems = new ObservableCollection<ModelPost>();
        }
        /// <summary>
        /// دالة الحفظ 
        /// </summary>
        private void Save()
        {
               _ViewModelOfCurrentPost.Save(_selected,SelectedItems);
            
        }

        /// <summary>
        /// حفظ ونقل  البيانات الى قسم اخر 
        /// </summary>
        private void SaveTo()
        {
            /* انواع الجداول
             * جدول البحث  ->G4
             * جدول التعليقات ->G3
             * جدول المنشن ->G5
             * جدول التسجيل ->G6
             * جدول الاستيراد ->G7
             * جدول المتابعين -G2
             */
            if (DataContext_.ParamOfCommandTransfer == "G2")
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < CollectionsHelper.Posts.Count; i++)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            try
                            {
                                if (CollectionsHelper.Followers[CollectionsHelper.Followers.IndexOf(new AccountOperations() { Username = CollectionsHelper.Posts[i].publisher, Uid = CollectionsHelper.Posts[i].UidOfpublisher })].Username != null)
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("index"))
                                {
                                    CollectionsHelper.Followers.Add(new AccountOperations() { Username = CollectionsHelper.Posts[i].publisher, Uid = CollectionsHelper.Posts[i].UidOfpublisher });
                                    LoggerViewModel.Log($"Data Of Accounts that u can follow has been updated " +
                                        $"Username:{CollectionsHelper.Posts[i].publisher}" +
                                        $" Address of Publisher:{CollectionsHelper.Posts[i].UidOfpublisher}"
                                        , TypeOfLog.check);
                                }
                            }

                        });
                    }
                });
            }
            /*  --- بحاجة لإضافة رابط المنشور ---  */
            else if (DataContext_.ParamOfCommandTransfer == "G3")
            {
                var _collection = new ObservableCollection<AccountOperations>();

                Task.Run(() =>
                {
                    for (int i = 0; i < CollectionsHelper.Posts.Count; i++)
                    {
                        _collection.Add(new AccountOperations() { Username = CollectionsHelper.Posts[i].publisher, Uid = CollectionsHelper.Posts[i].UidOfpublisher });
                    }
                    Application.Current.Dispatcher.Invoke(() => HelperCollections<AccountOperations>.Add(_collection));
                });


            }

        }

        /// <summary>
        /// حذف جميع العناصر
        /// </summary>
        private void Delete()
        {
            Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    CollectionsHelper.Posts.Clear();
                });
            });
        }

        /// <summary>
        /// دالة الغاء البحث
        /// </summary>
        public async void EndSearch()
        {
            await _EndSearch();
        }
        private Task _EndSearch()
        {
            return Task.Factory.StartNew(() =>
            {
                _search.canceled = true;

                DataContext_.ParamOfCommand = "readytobegin";

            });
        }
        /// <summary>
        /// دالة البحث
        /// </summary>
        public async void Search()
        {
            await _Search();
        }
        private Task _Search()
        {
            return Task.Factory.StartNew(() =>
            {
                DataContext_.ParamOfCommand = "readytoclose";
                string URL = "";
                if (DataContext_.SearchByTag)
                {
                    URL = _search.FindByTag();
                }
                else
                {
                    URL = _search.FindByLocation();
                }
                if (!String.IsNullOrEmpty(URL))
                {
                    _search.GetTopPosts(Posts, URL, cts);
                    _search.GetMostRecentPosts(Posts, URL, cts);
                }
                DataContext_.ParamOfCommand = "readytobegin";
            });
        }
    }
}
