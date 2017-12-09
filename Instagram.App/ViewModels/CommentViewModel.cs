using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using DevExpress.Xpf.Core;
using System.Data;

namespace Instagram.App
{
    public class CommentViewModel:BaseViewModel
    {
        public ObservableCollection<ModelPost> Posts { get; set; } = new ObservableCollection<ModelPost>();
        public ObservableCollection<ModelTable> Tables
        {
            get
            {
                return new ObservableCollection<ModelTable>(HelperSelector.regestirTables.Where(item => item.typessections == TypesSections.CommentsAndPostsSection));
            }
        }
        private ModelTable select_;
        public ModelTable Select
        {
            get
            {
                return select_;
            }
            set
            {
                var LastSelected = select_;
                if (value==null)
                {
                    value = LastSelected;
                }
                select_ = value;
                if (value!=null)
                {
                DataContextOfModelTable.NameOfTheTable = value.NameOfTheTable;

                }
                if (value !=null && HelperSelector.check(value.NameOfTheTable)!=-1)
                {
                    Posts = new ObservableCollection<ModelPost>(HelperSelector.ParentOfPostsTable[HelperSelector.regestirTables.IndexOf(HelperSelector.regestirTables.Where(item => item.NameOfTheTable== value.NameOfTheTable).FirstOrDefault())]);
                    OnPropertyChanged("Posts");
                }
            }
        }
        /// <summary>
        /// كونتكست للجداول
        /// </summary>
        public ModelTable DataContextOfModelTable { get; set; }
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
            DataContextOfModelTable = new ModelTable();
            //HelperSelector.Init();
            //ارسال تعليق
            mComment.Command_Comment = new BaseCommand(SendAComment);
            Comment_op = mComment;
            DataContextOfModelTable.DeleteCurrentTable = new BaseCommand(DeleteCurrentTable);
            DataContextOfModelTable.AddNewTable = new BaseCommand(AddNewTable);
            DataContextOfModelTable.EditCurrentTable = new BaseCommand(EditTable);
            //اظهار صفحة اختيار المنشنز
            mComment.CommandAddTags = new BaseCommand(() => {
                LoggerViewModel.Log(SelectedItems.Count.ToString(), TypeOfLog.questioncircle);
                var win = new Mention();
                var datacontext = new MentionViewModel(Comment_op, new ModelMention(),win);
                win.DataContext = datacontext;
                win.ShowDialog();
            });
            Comment = Comment_op;
            Task.Run(() => {
                while (((PrototypeOfDB)new PostsDB()).Fill("Tables").Rows.Cast<DataRow>().Where(type_ => type_.Field<string>("section") == TypesSections.CommentsAndPostsSection.ToString()).ToList().Count > 0 && Tables.Count <= 0)
                {
                    OnPropertyChanged("Tables");
                }
            });
        }
        /// <summary>
        /// تعديل اسم الجدول الحالي
        /// </summary>
        private void EditTable()
        {
            try
            {
                HelperSelector.EditTable(select_.NameOfTheTable, DataContextOfModelTable.NameOfTheTable);
                OnPropertyChanged("Tables");
            }
            catch (Exception)
            {

            }
         
        }

        /// <summary>
        /// اضافة جدول جديد
        /// </summary>
        private void AddNewTable()
        {
            DataContextOfModelTable.typessections = TypesSections.CommentsAndPostsSection;
            HelperSelector.AddTable(new ObservableCollection<ModelPost>(), DataContextOfModelTable.NameOfTheTable);
            OnPropertyChanged("Tables");
        }
        /// <summary>
        /// حذف الجدول الحالي
        /// </summary>
        private void DeleteCurrentTable()
        {
            HelperSelector.DeleteTable(select_, select_.NameOfTheTable, TypesSections.CommentsAndPostsSection);
            OnPropertyChanged("Tables");
            OnPropertyChanged("Posts");
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
                        Comment_.SendComment_UNDERTEST();
                        //Comment_.SendComment(Comment_op.TargetPost);
                    });
                });
            }
            else if (!string.IsNullOrEmpty(Comment_op.Target))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Task.Run(() =>
                    {
                        Comment_.SendComment_UNDERTEST();
                        //Comment_.SendComment_UnderTest(Posts,select_.NameOfTheTable);
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
