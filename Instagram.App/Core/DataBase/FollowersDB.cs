using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    public class FollowersDB : PrototypeOfDB, IDataBase
    {
        /// <summary>
        /// حذف عنصر محدد من جدول
        /// </summary>
        /// <param name="name">اسم الجدول المراد الحذف منه</param>
        /// <param name="args">SectionF(username TEXT ,Uid TEXT,Followers TEXT,IsFollower TEXT,ID INTEGER64)</param>
        /// <returns></returns>
        public bool DeleteItem(string name, string[] args)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// اضافة عنصر جديد للجدول المحدد
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <param name="args">
        /// برامترز خاصة بالعنصر المراد اضافته
        /// username,Uid,Followers,IsFollower,ID
        /// </param>
        /// <returns></returns>
        public bool InsertItem(string name, string[] args)
        {
            args[4] = GetID(name,TypesSections.FollowersSection).ToString();
            string con = $"insert into SectionF (username,Uid,Followers,IsFollower,ID) Values('{args[0]}','{args[1]}','{args[2]}','{args[3]}',{Int64.Parse(args[4])});";
            var sqlcommand = new SQLiteCommand(con, Connection.OpenAndReturn());
            try
            {
                sqlcommand.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception ex_InsertItem)
            {
                Connection.Close();
                LoggerViewModel.Log($"Error:{ex_InsertItem.InnerException} Method InsertItem Class FollowersDB", TypeOfLog.exclamationcircle);
                return false;
            }

        }
        /// <summary>
        /// اضافة عنصر جديد للجدول المحدد
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <param name="args">
        /// برامترز خاصة بالعنصر المراد اضافته
        /// username,Uid,Followers,IsFollower,ID
        /// </param>
        /// <returns></returns>
        public bool InsertRange(string name, List<string[]> args)
        {
            string con = $"insert into SectionF (username,Uid,Followers,IsFollower,ID) Values('{args[0]}','{args[1]}','{args[2]}','{args[3]}',{Int64.Parse(args[0][4])});";
            var sqlcommand = new SQLiteCommand();
            sqlcommand.Connection = Connection.OpenAndReturn();
            for (int i = 0; i < args.Count; i++)
            {
              args[i][4] = GetID(name, TypesSections.FollowersSection).ToString();
                con = $"insert into SectionF (username,Uid,Followers,IsFollower,ID) Values('{args[i][0]}','{args[i][1]}','{args[i][2]}','{args[i][3]}',{Int64.Parse(args[i][4])});";
                sqlcommand.CommandText = con;
                sqlcommand.ExecuteNonQuery();
                LoggerViewModel.Log($"I {i}", TypeOfLog.Warning);
            }
            try
            {
                Connection.Close();
                return true;
            }
            catch (Exception ex_InsertItem)
            {
                Connection.Close();
                LoggerViewModel.Log($"Error:{ex_InsertItem.InnerException} Method InsertItem Class FollowersDB", TypeOfLog.exclamationcircle);
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
            Int64 id = GetID(name,TypesSections.FollowersSection);
            var dt = new DataTable();
            string con = $"select * from SectionF Where ID={id};";
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
        public int GetCount(Int64 id)
        {
            int idd = 0;
            var dt = new DataTable();
            string con = $"select Count(*) from SectionF where ID={id};";
            try
            {
                var adapter = new SQLiteDataAdapter(con, Connection.OpenAndReturn());
                adapter.Fill(dt);
                idd = int.Parse(dt.Rows.Cast<DataRow>().FirstOrDefault().Field<Int64>("Count(*)").ToString());
                Connection.Close();
                return idd;
            }
            catch (Exception ex_Fill)
            {
                LoggerViewModel.Log($"Error:{ex_Fill.InnerException} Method GetCount Class FollowersDB", TypeOfLog.exclamationcircle);
                return 0;
            }
        }
    }
}
