using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace Instagram.App
{
    /// <summary>
    /// كلاس للتعامل مع قاعدة البيانات الخاصة بتسجيل الدخول
    /// </summary>
    public class LoginDB : IDataBase
    {
        private MainDB DB_;
        /// <summary>
        /// متغير للتعامل  مع قاعدة البيانات الام
        /// </summary>
        public MainDB DB
        {
            get { return DB_; }
            set { DB_ = value; }
        }
        public LoginDB(MainDB dB)
        {
            DB_ = dB;
        }
        /// <summary>
        /// اضافة جدول
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_item"></param>
        /// <param name="name"></param>
        public void AddTable<T>(T _item, string name)
        {
            /* تحقق من وجود الجدول */
            if (DB.Check(name))
            {
                return;
            }
            try
            {
                var con=DB.Connect();
                con.Open();
                string que = $"create table {name} ({_item})";
                SQLiteCommand smd = new SQLiteCommand(que,con);
                smd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                LoggerViewModel.Log($"Error at LoginDB Line 40~50 Method add table {ex.Message}", TypeOfLog.exclamationcircle);
            }
        }
        /// <summary>
        /// البحث عن جدول
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public bool Check(string TableName)
        {
            return DB.Check(TableName);
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
            return DB_.CheckForItem<T>(_item, TableName);
        }
        /// <summary>
        /// <see cref="DB.Connect()"/>
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection Connect()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// حذف  جدول  محدد 
        /// </summary>
        /// <param name="TableName"></param>
        public void Delete(string TableName)
        {
            DB_.Delete(TableName);
        }
        /// <summary>
        /// حذف صف  محدد من جدول محدد
        /// </summary>
        /// <typeparam name="index"></typeparam>
        /// <param name="_item"></param>
        /// <param name="Tablename"></param>
        public void DeleteItem<index>(index _item, string Tablename, string columnname)
        {
            DB.DeleteItem<index>(_item, Tablename, columnname);
        }
        /// <summary>
        /// تحديث الجدول المراد تحديثه
        /// </summary>
        /// <typeparam name="T">نوع الجدول</typeparam>
        /// <param name="_item">الجدول</param>
        /// <param name="name">اسم الجدول</param>
        public void UpdateTable<T>(T _item, string name)
        {
            var con = DB.Connect();
            string que = $"update {name} Set {_item};";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(que, con);
            con.Open();
            try
            {
                sQLiteCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
             LoggerViewModel.Log($"Error at LoginDB Line 90~99 method updatetable {ex.Message}", TypeOfLog.exclamationcircle);
            }
        }
        /// <summary>
        /// اضافة عناصر جديدة
        /// </summary>
        /// <typeparam name="T">نوع البيانات المدخلة</typeparam>
        /// <param name="_item">تعليمات الادخال</param>
        /// <param name="name">اسم الجدول</param>
        public void InsertItem<T>(T _item, string name)
        {
            var con = DB.Connect();
            string que = $"insert into {name} {_item}";
            SQLiteCommand smd = new SQLiteCommand(que, con);
            try
            {
                con.Open();
                smd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                LoggerViewModel.Log($"Error at LoginDB Line 120~150 method insert... {ex.Message}", TypeOfLog.exclamationcircle);

            }
        }
        /// <summary>
        /// يعمل على تعبئة البيانات وارسالها للجدول المخصص
        /// </summary>
        /// <param name="data"></param>
        /// <param name="query"></param>
        public void Fill(DataSet data, string Tablename)
        {
            DB.Fill(data, Tablename);
        }
    }
}
