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
        /// الاتصال بقاعدة البيانات
        /// </summary>
        SQLiteConnection Connect();
        /// <summary>
        /// اضافة الجدول
        /// </summary>
        /// <returns>اضافة جدول جديد</returns>
        void AddTable<T>(T _item,string name);
        /// <summary>
        /// تعديل الجدول
        /// </summary>
        /// <returns></returns>
        void UpdateTable<T>(T _item, string name);
        /// <summary>
        /// اضافة عناصر جديدة
        /// </summary>
        /// <typeparam name="T">نوع البيانات المدخلة</typeparam>
        /// <param name="_item">تعليمات الادخال</param>
        /// <param name="name">اسم الجدول</param>
        void InsertItem<T>(T _item, string name);
        /// <summary>
        /// حذف جدول محدد
        /// </summary>
        void Delete(string TableName);
        /// <summary>
        /// حذف عنصر محدد
        /// </summary>
        /// <typeparam name="index"></typeparam>
        /// <param name="_item"></param>
        /// <param name="Tablename">اسم الجدول المراد حذف العنصر منه</param>
        void DeleteItem<index>(index _item, string Tablename,string columnname);
        /// <summary>
        /// البحث عن جدول
        /// </summary>
        /// <param name="TableName">اسم الجدول المراد البحث عنه</param>
        /// <returns>القيمة المنطقية للبحث</returns>
        bool Check(string TableName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName">الجدول المراد البحث فيه</param>
        /// <param name="_item">العنصر المراد البحث عنه</param>
        /// <returns></returns>
        bool CheckForItem<T>(T _item,string TableName);
        /// <summary>
        /// تعبئة جدول محدد
        /// </summary>
        /// <typeparam name="T">نوع الجدول المراد تعبئته</typeparam>
        /// <param name="collection">الجدول المراد تعبئته</param>
        void Fill(DataSet data,string Tablename);
    }
}
