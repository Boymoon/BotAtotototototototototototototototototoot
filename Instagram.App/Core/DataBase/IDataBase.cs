using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// واجهة لقاعدة البيانات 
    /// </summary>
    interface IDataBase
    {
        /// <summary>
        /// اضافة عنصر جديد 
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <param name="args">ContextMedia,UidOfpost,Context,publisher,publishedat,UidOfpublisher,Likes,Views,name<Required></param>
        /// <returns></returns>
        bool InsertItem(string name, string[] args);
        /// <summary>
        /// حذف عنصر معين من جدول محدد
        /// </summary>
        /// <param name="name">اسم الجدول المراد حذف العنصر منه</param>
        /// <param name="args">برامترز خاصة بالعنصر المراد حذفه</param>
        /// <param name="args">ContextMedia,UidOfpost,Context,publisher,publishedat,UidOfpublisher,Likes,Views,name<Required></param>
        /// <returns></returns>
        bool DeleteItem(string name, string[] args);
        /// <summary>
        /// جلب البيانات الجدول المحدد
        /// </summary>
        /// <param name="name">اسم الجدول المراد جلب البيانات منه</param>
        /// <returns></returns>
        DataTable Fill(string name);
    }
}
