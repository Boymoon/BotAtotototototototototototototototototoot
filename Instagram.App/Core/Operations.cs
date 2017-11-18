/// <summary>
/// للتعامل  مع العمليات التي يتم تنفيذها داخل  البرنامج
/// </summary>
namespace Instagram.App
{
    using System.Collections.Generic;

    public static class Operations
    {
        private static  OperationsTypes _CurrentOT=new OperationsTypes();
        private static List<OperationsTypes> _operations = new List<OperationsTypes>();

        /// <summary>
        /// عدد العمليات 
        /// </summary>
        private static int OperationsCount { get => operations.Count; }
        /// <summary>
        /// -العملية الحالية-التي تعمل في الوقت الحالي  
        /// </summary>
        public static OperationsTypes CurrentOT
        {
            get => _CurrentOT; set
            {
                _CurrentOT = value;
                if (!(value == OperationsTypes.CancelCurrentOperation))
                {
                    operations = null;
                }
            }
        } 
        /// <summary>
        /// العمليات المنفذة في الجلسة الحالية 
        /// </summary>
        public static List<OperationsTypes> operations { get => _operations; set => _operations.Add(CurrentOT); }
        /// <summary>
        /// جلب العملية الحالية
        /// </summary>
        /// <returns>العملية الحالية</returns>
        public static OperationsTypes GetCurrentOT(int index)
        {
            /* -1 معناه العملية التي يتم تنفيذها اذا لم يجد اذاً اخر عملية تم تنفيذها */
            if (index == -1)
            {
                return _CurrentOT;
            }
            return operations[index];
        }
        /// <summary>
        /// جلب جميع العمليات التي تم تنفيذها
        /// </summary>
        /// <returns>جميع العمليات المنفذة </returns>
        public static List<OperationsTypes> GetCurrentOT()
        {
            if (!(operations.Count > 0))
            {
                return null;
            }
            return operations;
        }
        public static void ShowOperations()
        {
            LoggerViewModel.Log($"Operation That Running Now ({CurrentOT}) Total ({OperationsCount}) ",TypeOfLog.Warning);
        }

    }
}
