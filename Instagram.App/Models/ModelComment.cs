using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instagram.App
{
    public class ModelComment:BaseViewModel
    {
        private bool IsSleep_;
        /// <summary>
        /// الفاصل الزمني
        /// </summary>
        public bool IsSleep
        {
            get { return IsSleep_; }
            set { IsSleep_ = value; OnPropertyChanged(); }
        }
        private int Sleep_;
        /// <summary>
        /// المدة 
        /// </summary>
        public int Sleep
        {
            get { return Sleep_; }
            set { Sleep_ = value; OnPropertyChanged(); }
        }
        private string Unit_;
        /// <summary>
        /// الوحدة
        /// </summary>
        public string Unit
        {
            get { return Unit_; }
            set { Unit_ = value; OnPropertyChanged(); }
        }
        private int SentSuccess_;
        /// <summary>
        /// عدد مرات الارسال الناجحة 
        /// </summary>
        public int SentSuccess
        {
            get { return SentSuccess_; }
            set { SentSuccess_ = value; OnPropertyChanged(); }
        }
        private int UnableToSend_;
        /// <summary>
        /// عدد المرات التي  تعذر فيها الارسال
        /// </summary>
        public int UnableToSend
        {
            get { return UnableToSend_; }
            set { UnableToSend_ = value; OnPropertyChanged(); }
        }
        private int SendMentionSuccess_;
        /// <summary>
        /// عدد مرات الارسال الناجحة 
        /// </summary>
        public int SendMentionSuccess
        {
            get { return SendMentionSuccess_; }
            set { SendMentionSuccess_ = value; OnPropertyChanged(); }
        }
        private string TargetPost_;
        /// <summary>
        /// المنشور المستهدف
        /// </summary>
        public string TargetPost
        {
            get { return TargetPost_; }
            set { TargetPost_ = value; OnPropertyChanged(); }
        }
        private string Target_;
        /// <summary>
        /// عنوان الحساب المستهدف
        /// </summary>
        public string Target
        {
            get { return Target_; }
            set { Target_= value; OnPropertyChanged(); }
        }
        private string Text_;
        /// <summary>
        /// نص التعليق
        /// </summary>
        public string Text
        {
            get { return Text_; }
            set { Text_ = value; OnPropertyChanged(); }
        }
        private string Tag_;
        /// <summary>
        /// منشن لشخص
        /// </summary>
        public string Tag
        {
            get { return Tag_; }
            set { Tag_ = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// ارسال تعليق
        /// </summary>
        public ICommand Command_Comment { get; set; }
        /// <summary>
        /// اضافة tags Example: @mention
        /// </summary>
        public ICommand CommandAddTags { get; set; }

    }
}
