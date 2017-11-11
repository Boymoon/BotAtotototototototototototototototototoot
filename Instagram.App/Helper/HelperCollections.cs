using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instagram.App
{
    public static class HelperCollections<Target>
         where Target : AccountOperations
    {
        /// <summary>
        /// قائمة من نوع جدول
        /// </summary>
        public static ObservableCollection<ObservableCollection<Target>> CollectionOfTables =
            new ObservableCollection<ObservableCollection<Target>>();
        /// <summary>
        /// اضافة جداول
        /// </summary>
        /// <param name="Target_Collection"></param>
        public static void Add(ObservableCollection<Target> Target_Collection)
        {
            Application.Current.Dispatcher.Invoke(() => CollectionOfTables.Add(Target_Collection));
        }
        /// <summary>
        /// حذف جداول
        /// </summary>
        /// <param name="Target_Collection"></param>
        public static void Remove(ObservableCollection<Target> Target_Collection)
        {
            CollectionOfTables.Remove(Target_Collection);
        }
        /// <summary>
        /// تعديل على الجدول الحالي
        /// </summary>
        /// <param name="Target_Collection">الجدول الحالي</param>
        /// <param name="arg0">Username</param>
        /// <param name="arg1">Uid       ->Link</param>
        public static void Edit(ObservableCollection<Target> Target_Collection,object arg0, object arg1)
        {
            if (Target_Collection != null)
            {
                for (int i = 0; i < Target_Collection.Count; i++)
                {

                    Target_Collection[i].Username = arg0 as string;
                    Target_Collection[i].Uid = arg1 as string;

                }
            }

        }

    }
}
