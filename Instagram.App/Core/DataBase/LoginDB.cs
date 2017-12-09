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
    public class LoginDB : PrototypeOfDB, IDataBase
    {
        /// <summary>
        /// حذف عنصر محدد من جدول الحسابات المضافة
        /// </summary>
        /// <param name="name">الجدول المراد الحذف منه</param>
        /// <param name="args">username,password,email</param>
        /// <returns></returns>
        public bool DeleteItem(string name,string[] args)
        {
            name = "account";
            string con = $"delete from {name} where username='{args[0]}' And password='{args[1]}' And email='{args[2]}';";
            var sqlcommand = new SQLiteCommand(con, Connection);
            try
            {
                Connection.Open();
                sqlcommand.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception ex_deleteItem)
            {

                LoggerViewModel.Log($"Error:{ex_deleteItem.InnerException} Method DeleteItem Class LoginDB", TypeOfLog.exclamationcircle);
                Connection.Close();
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool InsertItem(string name, string[] args)
        {
            name = "account";
            try
            {
                string con = $"insert into {name} (username,password,email) Values('{args[0]}','{args[1]}','{args[2]}');";
                var sqliteCommand = new SQLiteCommand(con, Connection.OpenAndReturn());
                sqliteCommand.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception ex_InsertItem)
            {
                LoggerViewModel.Log($"Error:{ex_InsertItem.InnerException} Method InsertItem Class LoginDB", TypeOfLog.exclamationcircle);
                Connection.Close();
                return false;
            }
        }
        /// <summary>
        /// جلب البيانات الجدول المحدد
        /// </summary>
        /// <param name="name">اسم الجدول المراد جلب البيانات منه</param>
        /// <returns></returns>
        public DataTable Fill(string name)
        {
            var dt = new DataTable();
            string con = $"select * from account;";
            Connection.Open();
            try
            {
                var adapter = new SQLiteDataAdapter(con, Connection);
                adapter.Fill(dt);
                Connection.Close();
                return dt;
            }
            catch (Exception ex_Fill)
            {
                LoggerViewModel.Log($"Error:{ex_Fill.InnerException} Method Fill Class LoginDB", TypeOfLog.exclamationcircle);
                return null;
            }
        }
    }
}
