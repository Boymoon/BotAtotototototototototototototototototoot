using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Project
{
    public class Trial
    {
        /// <summary>
        /// اذا انتهت المرحلة التجريبية
        /// </summary>
        public bool IsTrialFinishes { get
            {
                return (timestorun <= 0) ? true : false;
            } }
        /// <summary>
        /// عدد مرات التشغيل
        /// </summary>
        public int timestorun { get { return GetTimestorun(); } set { } }
        /// <summary>
        /// عدد مرات التشغيل
        /// </summary>
        /// <returns>عدد مرات التشغيل المتبقية</returns>
        private int GetTimestorun()
        {
            return Properties.Settings.Default.Timestorun;
        }
        /// <summary>
        /// عند الدخول للبرنامج
        /// </summary>
        public void NewSession()
        {
            Properties.Settings.Default.Timestorun+=999;
            Properties.Settings.Default.Save();
        }
        
    }
}
