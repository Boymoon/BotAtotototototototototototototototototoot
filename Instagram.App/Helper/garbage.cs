using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    public static class garbage
    {
        /// <summary>
        /// قائمة العمليات
        /// </summary>
        private static List<Int64> _Pid { get; set; }
        /// <summary>
        /// تجهيز الدوال
        /// </summary>
        public static void Init()
        {
            _Pid = new List<Int64>();
        }
        /// <summary>
        /// قتل عملية محددة
        /// </summary>
        /// <param name="_processId">رقم العملية</param>
        public static void Kill(Int64 _processId)
        {
            if (_processId == 0)
            {
                return;
            }
            try
            {
                Process.GetProcessById((int)_processId).Kill();
                /* التحقق  من وجود العملية */
                var Check = Process.GetProcessById((int)_processId);
                if (Check == null)
                {
                    LoggerViewModel.Log($"Process has been killed ID:{Process.GetProcessById((int)_processId).Id} Name:{Process.GetProcessById((int)_processId).ProcessName}", TypeOfLog.check);
                    return;
                }
            }
            catch (Exception) { }
        }
        /// <summary>
        /// جلب  ارقام العمليات 
        /// </summary>
        public static void Collect(Int64 _CurrentID)
        {
            _Pid.Add(_CurrentID);
        }
        /// <summary>
        /// حذف  جميع العمليات التي قام بها البرنامج
        /// </summary>
        public static void Clear()
        {
            if (_Pid.Count == 0)
            {
                LoggerViewModel.Log("There's no Processes To Kill", TypeOfLog.exclamationcircle);
                return;
            }
            for (int i = 0; i < _Pid.Count; i++)
            {
                try
                {
                    Process.GetProcessById((int)_Pid[i]).Kill();
                    LoggerViewModel.Log($"Process has been killed ID:{Process.GetProcessById((int)_Pid[i]).Id} Name:{Process.GetProcessById((int)_Pid[i]).ProcessName}", TypeOfLog.exclamationcircle);

                }
                catch (Exception)
                {
                }
            }
        }
    }
}
