using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// مودل لواجهة التحميل
    /// </summary>
   public class LoadingModel : BaseViewModel
    {
        /* قيد التشغيل */
        private bool _IsRunning = false;
        /* الشفافية */
        private double _opacity = 1;
        /// <summary>
        /// درجة الشفافية 
        /// </summary>
        public double opacity { get { return _opacity; } set { _opacity = value; OnPropertyChanged(); } }
        /// <summary>
        /// حالة العملية المراد تحميلها
        /// </summary>
        public bool IsRunning { get { return _IsRunning; } set { _IsRunning = value; _opacity = (value) ? 0.4 : 1; OnPropertyChanged("opacity"); OnPropertyChanged(); } }
    }
}
