using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Data;

namespace Instagram.App
{
    /// <summary>
    /// كلاس للتعامل مع قاعدة البيانات الاصلية 
    /// الاتصال  وخلافه
    /// </summary>
    public class MainDB : IDataBase
    {
        /// <summary>
        /// البحث عن جدول
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public bool Check(string TableName)
        {
         var t= Connect();
            t.Open();
            string que = $"Select * From {TableName};";
            SQLiteCommand CommandSQ = new SQLiteCommand(que, t);
            try
            {
                CommandSQ.ExecuteNonQuery();
                t.Close();
                return true;
            }
            catch (Exception ex)
            {
                t.Close();
                return false;
            }
        }
        /// <summary>
        /// البحث عن عنصر في جدول
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_item"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public bool CheckForItem<T>(T _item, string TableName)
        {
            var con = Connect();
            string que = $"Select * From {TableName} Where {TableName} Match {_item};";
            con.Open();
            SQLiteCommand sQ = new SQLiteCommand(que,con);
            try
            {
            SQLiteDataReader reader = sQ.ExecuteReader();

            con.Close();

            return (reader.FieldCount == 0) ? false : true;
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
            return true;
            /* تحقق من نتائج البحث */
        }
        /// <summary>
        /// دالة الاتصال بقاعدة البيانات
        /// </summary>
        public SQLiteConnection Connect()
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection();
            string ConnectionString = $"Data Source=E:\\InstaBot\\TestDB.db;Version=3;";
            sQLiteConnection.ConnectionString = ConnectionString;
            return sQLiteConnection;
        }
        /// <summary>
        /// حذف  جدول  محدد 
        /// </summary>
        /// <param name="TableName"></param>
        public void Delete(string TableName)
        {
           var con=Connect();
            SQLiteCommand v = new SQLiteCommand();
            v.Connection = con;
            v.CommandText = $"drop table {TableName};";
            con.Open();
            v.ExecuteNonQuery();
            con.Close();
        }
        /// <summary>
        /// حذف صف  محدد من جدول محدد
        /// </summary>
        /// <typeparam name="index"></typeparam>
        /// <param name="_item"></param>
        /// <param name="Tablename"></param>
        public void DeleteItem<index>(index _item, string Tablename, string columnname)
        {
            var con = Connect();
            string que = $"Delete from {Tablename} where {columnname} ='{_item}';";
            con.Open();
            SQLiteCommand sQLiteCommand = new SQLiteCommand(que, con);
            sQLiteCommand.ExecuteNonQuery();
            con.Close();
        }
        /// <summary>
        /// اضافة  جدول جديد
        /// </summary>
        /// <typeparam name="T">نوع الجدول</typeparam>
        /// <param name="_item">الجدول</param>
        /// <param name="name">اسم الجدول</param>
        public void AddTable<T>(T _item, string name)
        {
            return;
        }
        /// <summary>
        /// تحديث الجدول المراد تحديثه
        /// </summary>
        /// <typeparam name="T">نوع الجدول</typeparam>
        /// <param name="_item">الجدول</param>
        /// <param name="name">اسم الجدول</param>
        public void UpdateTable<T>(T _item, string name)
        {
            return;
        }
        /// <summary>
        /// اضافة عناصر جديدة
        /// </summary>
        /// <typeparam name="T">نوع البيانات المدخلة</typeparam>
        /// <param name="_item">تعليمات الادخال</param>
        /// <param name="name">اسم الجدول</param>
        public void InsertItem<T>(T _item, string name)
        {
            return;
        }
        /// <summary>
        /// يعمل على تعبئة البيانات وارسالها للجدول المخصص
        /// </summary>
        /// <param name="data"></param>
        /// <param name="query"></param>
        public void Fill(DataSet data, string Tablename)
        {
            try
            {
                var con = Connect();
                string que = $"Select * From {Tablename};";
                con.Open();
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(que, con);
                sQLiteDataAdapter.Fill(data);
                con.Close();
            }
            catch (Exception ex)
            {
                LoggerViewModel.Log($"Error at Fill in line 150~153 Class MainDB {ex.Message}", TypeOfLog.exclamationcircle);
            }

        }
    }
}

