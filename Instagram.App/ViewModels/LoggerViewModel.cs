using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instagram.App
{
    public static class LoggerViewModel
    {

        private static int index_;

        public static int index
        {
            get { return index_;}
            set { index_ = value;  }
        }
    
        /// <summary>
        /// السجلات
        /// </summary>
        public static ObservableCollection<ModelLogger> Logs { get; set; } = new ObservableCollection<ModelLogger>();
        /// <summary>
        /// اضافة سجل جديد
        /// </summary>
        /// <param name="text">نص السجل</param>
        /// <param name="log">نوع السجل</param>
        public static void Log(string text,TypeOfLog log)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Logs.Add(new ModelLogger()
                {
                    Text = " "+text,
                    TypeOfLog = log,
                    DateTime = DateTime.Now.ToString("h:mm:ss tt")
                });
                index = Logs.Count - 1;
            });
            
        }
        /// <summary>
        /// حذف جميع محتوى المسجل
        /// </summary>
        public static void ClearLog()
        {
            Logs.Clear();
        }

    }
}
