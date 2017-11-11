using DevExpress.Xpo.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// انواع المسجلات 
    /// </summary>
    public enum TypeOfLog
    {
        /// <summary>
        /// تحذير
        /// </summary>
        Warning = 0,
        /// <summary>
        /// خطأ
        /// </summary>
        exclamationcircle = 1,
        /// <summary>
        /// خطأ مجهول
        /// </summary>
        questioncircle = 2,
        /// <summary>
        /// تمت العملية بنجاح
        /// </summary>
        check = 3
    }
    public class ModelLogger : BaseViewModel
    {
        private string Type_;
        /// <summary>
        /// نوع المسجل 
        /// </summary>
        public string TypeOfLogConv
        {
            get => Type_;
            set { Type_ = value; OnPropertyChanged(); }
        }
        private string Text_;
        /// <summary>
        /// نص المسجل 
        /// </summary>
        public string Text
        {
            get { return Text_; }
            set { Text_ = value; OnPropertyChanged(); }
        }
        private string DateTime_;
        /// <summary>
        /// وقت الارسال 
        /// </summary>
        public string DateTime
        {
            get { return DateTime_; }
            set { DateTime_ = value; OnPropertyChanged(); }
        }

        private TypeOfLog TypeOfLog_;
        /// <summary>
        /// نوع المسجل
        /// </summary>
        public TypeOfLog TypeOfLog
        {
            get { return TypeOfLog_; }
            set
            {
                TypeOfLog_ = value;
                if (TypeOfLog_ == TypeOfLog.check)
                {
                    Type_ = "Check";
                }
                else if (TypeOfLog_ == TypeOfLog.exclamationcircle)
                {
                    Type_ = "ExclamationCircle";
                }
                else if (TypeOfLog_ == TypeOfLog.questioncircle)
                {
                    Type_ = "QuestionCircle";
                }
                else if (TypeOfLog_ == TypeOfLog.Warning)
                {
                    Type_ = "Warning";
                }
                OnPropertyChanged();
            }
        }
    }
}
