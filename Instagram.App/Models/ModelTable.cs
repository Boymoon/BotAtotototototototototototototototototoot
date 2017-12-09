using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instagram.App
{
    /// <summary>
    /// للتعامل مع <see cref="SelectTableToShow in MainWindow.Xaml"/>
    /// <![CDATA[SelectTableToShow Is Item ]]>
    /// </summary>
   public class ModelTable:BaseViewModel
    {
        private TypesSections TypesSections_=TypesSections.FollowersSection;
        /// <summary>
        /// نوع القسم المراد  جدولته
        /// </summary>
        public TypesSections typessections
        {
            get { return TypesSections_; }
            set { TypesSections_= value; OnPropertyChanged(); }
        }
        private string NameOfTheTable_;
        /// <summary>
        /// اسم الجدول 
        /// </summary>
        public string NameOfTheTable
        {
            get { return NameOfTheTable_; }
            set { NameOfTheTable_ = value;OnPropertyChanged(); }
        }
        private int CountOfItems_;
        /// <summary>
        /// عدد العناصر
        /// </summary>
        public int CountOfItems
        {
            get { return CountOfItems_; }
            set { CountOfItems_ = value;OnPropertyChanged(); }
        }
        private int Count_;
        /// <summary>
        /// العدد الكلي للجداول
        /// </summary>
        public int Count
        {
            get { return Count_; }
            set { Count_ = value;OnPropertyChanged(); }
        }
        /// <summary>
        /// حذف الجداول المحدد عليها
        /// </summary>
        public ICommand DeleteCurrentTable { get; set; }
        /// <summary>
        /// مسح جميع الجداول
        /// </summary>
        public ICommand Clear{ get; set; }
        /// <summary>
        /// اضافة جدول
        /// </summary>
        public ICommand AddNewTable { get; set; }
        /// <summary>
        /// التعديل على الجدول الحالي
        /// </summary>
        public ICommand EditCurrentTable { get; set; }

    }
}
