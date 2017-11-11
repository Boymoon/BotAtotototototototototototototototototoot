using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instagram.App
{
    public class CurrentPostModel : BaseViewModel
    {
        private string Context_="NotFound";
        /// <summary>
        /// وصف المنشور الحالي
        /// </summary>
        public string Context
        {
            get { return Context_; }
            set { Context_ = value;OnPropertyChanged(); }
        }
        private string ContextMedia_;
        /// <summary>
        /// المحتوى المرئي للمنشور
        /// </summary>
        public string ContextMedia
        {
            get { return ContextMedia_; }
            set { ContextMedia_ = value; OnPropertyChanged(); }
        }
        private string Username_="NotFound";
        /// <summary>
        /// اسم الناشر
        /// </summary>
        public string Username
        {
            get { return Username_; }
            set { Username_ = value; OnPropertyChanged(); }
        }

        private string Tablename_;
        /// <summary>
        /// اسم الجدول المراد حفظ البيانات الحالية به
        /// </summary>
        public string Tablename
        {
            get { return Tablename_; }
            set { Tablename_ = value; OnPropertyChanged(); }
        }
        private bool IsEditable_;
        /// <summary>
        /// حالة التعديل على اسم الجدول
        /// </summary>
        public bool IsEditable
        {
            get { return IsEditable_; }
            set { IsEditable_ = value; OnPropertyChanged(); }
        }

        private bool IsCustomizeEnable_;
        /// <summary>
        /// حالة تخصيص الحفظ
        /// </summary>
        public bool IsCustomizeEnable
        {
            get { return IsCustomizeEnable_; }
            set { IsCustomizeEnable_ = value; OnPropertyChanged(); }
        }
        private bool IsSectionAccounts_=true;
        /// <summary>
        /// حالة خيار قسم الحسابات
        /// </summary>
        public bool IsSectionAccounts
        {
            get { return IsSectionAccounts_; }
            set { IsSectionAccounts_ = value; OnPropertyChanged(); }
        }
        private bool IsSectionComments_=true;
        /// <summary>
        /// حالة خيار قسم التعليقات
        /// </summary>
        public bool IsSectionComments
        {
            get { return IsSectionComments_; }
            set { IsSectionComments_ = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// حفظ
        /// </summary>
        public ICommand SaveCommand { get; set; }
        /// <summary>
        /// تخصيص الحفظ
        /// </summary>
        public ICommand CustomizeSaveCommand { get; set; }
        /// <summary>
        /// التعديل  على  اسم الجدول
        /// </summary>
        public ICommand EditCommand { get; set; }
        /// <summary>
        /// حفظ اسم الجدول
        /// </summary>
        public ICommand SaveCommandOfTablename { get; set; }

    }
}
