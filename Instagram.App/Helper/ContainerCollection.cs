using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// <![CDATA[عمل  كولكشن  متصلة مع اسم الجدول ]]>
    /// </summary>
    public class ContainerCollection<T> : BaseViewModel
    {
        private T Selected_;
        /// <summary>
        /// العنصر  المحدد  من قائمة الجداول
        /// </summary>
        public T Selected
        {
            get
            {
                return Selected_;
            }
            set
            {
                Selected_ = GetSelected(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// حالة طلب اضافة  جدول  جديد 
        /// True -> تم قبوله 
        /// False -> تم رفضه
        /// </summary>
        public static bool GetStateOfRequest { get; private set; }
        /// <summary>
        /// اسماء الجداول
        /// </summary>
        public static ObservableCollection<string> Tables { get; private set; }
        /// <summary>
        /// <!--كولكشن ممتدة-->
        /// </summary>
        public static ObservableCollection<T> Container { get; private set; }

        public static void Init()
        {
            Container =new ObservableCollection<T>();
            Tables = new ObservableCollection<string>();
        }
        /// <summary>
        /// <!--اضافة جدول-->
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <param name="CurrentItem">الجدول المراد اضافته</param>
        public static void AddTable(string name, T CurrentItem)
        {
            if (Check(name) || string.IsNullOrEmpty(name))
            {
                GetStateOfRequest = false;
                return;
            }
            Container.Add(CurrentItem);
            Tables.Add(name);
        }
        /// <summary>
        /// اضافة عناصر الى الجدول المحدد
        /// </summary>
        /// <param name="name"></param>
        /// <param name="CurrentItem"></param>
        public static void Insert(string name,T CurrentItem)
        {
            if (Tables.IndexOf(name) ==-1)
            {
                AddTable(name, CurrentItem);
            }
            else
            {
                Container[Tables.IndexOf(name)] = CurrentItem;
            }
        }
        /// <summary>
        /// التحقق  من اسم الجدول
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <returns>
        /// <code>
        /// False -> لم يجد تطابق
        /// True  -> وجد تطابق
        /// </code>
        /// </returns>
        private static bool Check(string name)
        {
            if (Tables.Count <= 0)
            {
                return false;
            }

            var check_ = Tables.Where(c => string.IsNullOrEmpty((c.IndexOf(name) > 0).ToString()));

            if (check_.ToList().Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T GetSelected(T Value)
        {
            try
            {
                var CItem = Container[Container.IndexOf(Value)];
                return CItem;
            }
            catch (Exception)
            {
                return Value;
            }

        }
    }

}

