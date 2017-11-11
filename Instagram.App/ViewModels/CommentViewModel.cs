using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using DevExpress.Xpf.Core;

namespace Instagram.App
{
    public class CommentViewModel:BaseViewModel
    {
        public ObservableCollection<ModelPost> Posts { get; } = new ObservableCollection<ModelPost>();
        public ObservableCollection<ObservableCollection<AccountOperations>> TablesComment { get { return HelperCollections<AccountOperations>.CollectionOfTables; }}
        public ContainerCollection<ObservableCollection<ModelPost>> container { get; } = new ContainerCollection<ObservableCollection<ModelPost>>();
        public ObservableCollection<string> Items_ { get
            {
                return ContainerCollection<ObservableCollection<ModelPost>>.Tables;
            } }
        private string select_;
        public string Select
        {
            get
            {
                return select_;
            }
            set
            {
                select_ = value;
                container.Selected = ContainerCollection<ObservableCollection<ModelPost>>.Container[ContainerCollection<ObservableCollection<ModelPost>>.Tables.IndexOf(value)];

            }
        }
        private ObservableCollection<ModelPost> SelectedItems_=new ObservableCollection<ModelPost>();
        /// <summary>
        /// المنشورات المحددة
        /// </summary>
        public ObservableCollection<ModelPost> SelectedItems { get {
                return SelectedItems_;
            } set {
                SelectedItems_ = value;
                OnPropertyChanged();
            }
        } 
        private ModelComment Comment_op;
        
        public ModelComment Comment
        {
            get { return Comment_op; }
            set { Comment_op = value; }
        }
        /// <summary>
        /// /كلاس ارسال التعليقات او كلاس  التعليقات
        /// </summary>
        private Comment Comment_;
        public CommentViewModel(ModelComment mComment)
        {
            //ارسال تعليق
            mComment.Command_Comment = new BaseCommand(SendAComment);
            Comment_op = mComment;
            //اظهار صفحة اختيار المنشنز
            mComment.CommandAddTags = new BaseCommand(() => {
                LoggerViewModel.Log(SelectedItems.Count.ToString(), TypeOfLog.questioncircle);
                var win = new Mention();
                var datacontext = new MentionViewModel(Comment_op, new ModelMention(),win);
                win.DataContext = datacontext;
                win.ShowDialog();
            });
            Comment = Comment_op;
            for (int i = 0; i < 5; i++)
            {
                Posts.Add(new ModelPost()
                {
                    Context = "context",
                    ContextMedia = "www.mdmd.com/mp4",
                    Likes = "0",
                    publishedat = "2:10 pm",
                    publisher = "Person",
                    UidOfpost = "www.post.com",
                    UidOfpublisher = "www.person.com",
                    Views = "100"
                });
            }
               ContainerCollection<ObservableCollection<ModelPost>>.Insert($"Table {ContainerCollection<ObservableCollection<ModelPost>>.Tables.Count}", Posts);         

        }
        private void SendAComment()
        {
            LoggerViewModel.Log("Getting Started...", TypeOfLog.check);
        
        Comment_ = new Comment(Comment_op);
            if (!String.IsNullOrEmpty(Comment_op.TargetPost) && Regex.IsMatch(Comment_op.TargetPost, "taken-by"))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Task.Run(() =>
                    {
                        Comment_.SendComment(Comment_op.TargetPost);
                    });
                });
            }
            else if (!string.IsNullOrEmpty(Comment_op.Target))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Task.Run(() =>
                    {
                        Comment_.SendComment_UnderTest(Posts);
                        LoggerViewModel.Log("Finished", TypeOfLog.exclamationcircle);

                    });
                });
            }
            else 
            {
                DXMessageBox.Show("رجاء تأكد من كتابة عنوان الحساب او عنوان المنشور ", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerViewModel.Log("Please Make Sure That you write Link Of Adress Or Comment", TypeOfLog.exclamationcircle);
            }


        }
    }
}
