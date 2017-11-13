using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Ar_Project
{
    /// <summary>
    /// Class Regestir:
    /// لتسجيل المؤشر وحفظه منفصلاً عن كلاس MainWindowView
    /// واستخدام المؤشر كنقطة لاكمال ادخال البيانات في الخلايا Cells.
    /// 
    /// 
    /// 
    /// </summary>
    public enum type_of_Count
    {
        Isdone=0,
        IsNotDone=1,
        GetAll=2
    }
    public static class Regestir 
    {
        static int CountingAll = 0;
        static int Countingisdone = 0;
        static int CountingisNotDone = 0;
        private static void a()
        {
            InsertDataIntoDataTable();
        }
        public static string Counting(type_of_Count typeOfCounting)
        {
            a();
            if (typeOfCounting == type_of_Count.GetAll)
            {
                a();
               return string.Format("{0} اجمالي الطلبات", CountingAll.ToString());
            }
            
            else if (typeOfCounting == type_of_Count.Isdone)
            {
                a();
                return string.Format("{0} اجمالي الطلبات المُسلمة", Countingisdone.ToString());
            }
            else if (typeOfCounting == type_of_Count.IsNotDone)
            {
                a();
                return string.Format("{0} طلبات جاري العمل عليها ", CountingisNotDone.ToString());
            }
            else
            {
                return null;
            }
           



           
        }

        private static List<bool> Regestir_;

        public static List<bool> regestir
        {
            get { return Regestir_; }
            set { Regestir_ = value; }
        }
        private static List<int> Count;
       
        public static List<int> count
        {
            get { return Count; }
            set { Count = value; }
        }

       public static int Push()
        {
            int push = 0;
            push += 1;
            return push;
        }
       public static bool GetValueByIndex(int index)
        {
            return Regestir_[index];
        }
        private static void InsertDataIntoDataTable()
        {

            CountingisNotDone = 0;
            CountingAll = 0;
            Countingisdone = 0;
             var datatable = new DataTable();
            var modelmega = new ModelMega();
            modelmega.show(datatable);
            foreach (DataRow item in datatable.Rows)
            {
                //  Regestir_.Add((item.Field<bool>("isdone")));
                if (item.Field<bool>("isdone")) 
                {
                    Countingisdone += 1;
                }
                else if (!item.Field<bool>("isdone"))
                {
                    CountingisNotDone+=1;
                }
                
                //Countingisdone += (item.Field<bool>("isdone")==true) ? Countingisdone++ :0;
                //CountingisNotDone += (item.Field<bool>("isdone")==false) ? CountingisNotDone++ : 0;

                CountingAll += 1;
            }
        }
    }
}
