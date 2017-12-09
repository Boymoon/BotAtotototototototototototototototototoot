using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// نموذج لقاعدة البيانات 
    /// </summary>
   public abstract class PrototypeOfDB
    {
        public SQLiteConnection Connection { get => connection(); }
        /// <summary>
        /// الاتصال بقاعدة البيانات
        /// </summary>
        /// <returns></returns>
        private SQLiteConnection connection()
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
            var con = Connection;
            SQLiteCommand v = new SQLiteCommand();
            v.Connection = con;
            v.CommandText = $"drop table {TableName};";
            con.Open();
            v.ExecuteNonQuery();
            con.Close();
        }
        /// <summary>
        /// حذف جدول كامل مع جداوله المرتبطة به
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool ResetTable(string name)
        {
            Int64 index = GetID(name,TypesSections.AccountsSection);
            string con = $"delete from Tables where name='{name}';delete from SectionF where ID={index};delete from SectionPM where ID={index};";
            SQLiteCommand sq = new SQLiteCommand(con, Connection.OpenAndReturn());
            try
            {
                sq.ExecuteNonQuery();
                Connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                Connection.Close();
                LoggerViewModel.Log($"Error:{ex.Message} at Delete Table Line 61 class PrototypeOfDB", TypeOfLog.exclamationcircle);
                return false;
            }

        }

        /// <summary>
        /// اضافة جدول جديد
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <param name="ID">رقم الايدي</param>
        /// <returns></returns>
        public bool AddTable(string name, Int64 ID,TypesSections typeSection)
        {
            if (check(ID))
            {
                ID++;
                AddTable(name, ID, typeSection);
            }
            string con = $"insert into Tables (name,ID,section) Values('{name}',{ID},'{typeSection.ToString()}');";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(con, Connection.OpenAndReturn());
            try
            {
                sQLiteCommand.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                LoggerViewModel.Log($"Error:{ex.Message} at InsertItem in ProtoTypeOfDB ", TypeOfLog.exclamationcircle);
                Connection.Close();
                return false;
            }
        }
        /// <summary>
        /// التحقق من وجود جدول من عدمه
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <returns>
        /// -true -> يوجد
        /// false -> لايوجد
        /// </returns>
        public bool check(string name)
        {
            string con = $"Select * from Tables Where name='{name}';";
            var datatable = new DataTable();
            var adapter = new SQLiteDataAdapter(con, Connection.OpenAndReturn());
            try
            {
            adapter.Fill(datatable);
                Connection.Close();
                return (datatable.Rows.Count == 0) ? true : false;
            }
            catch (Exception ex_CheckForTable)
            {
                LoggerViewModel.Log($"Error:{ex_CheckForTable.Message} Method Check(1) Class ProtoTypeOfDB", TypeOfLog.exclamationcircle);
                Connection.Close();
                return false;
            }
            
        }
        /// <summary>
        /// التحقق من وجود رقم للجدولة من عدمه
        /// </summary>
        /// <param name="ID">رقم الجدول</param>
        /// <returns>
        /// -true -> يوجد
        /// false -> لايوجد
        /// </returns>
        public bool check(Int64 ID)
        {
            string con = $"Select * from Tables Where ID={ID};";
            var datatable = new DataTable();
            var adapter = new SQLiteDataAdapter(con, Connection.OpenAndReturn());
            try
            {
                adapter.Fill(datatable);
                Connection.Close();
                return (datatable.Rows.Count == 0) ? false : true;
            }
            catch (Exception ex_CheckForTable)
            {
                LoggerViewModel.Log($"Error:{ex_CheckForTable.Message} Method Check(2) Class ProtoTypeOfDB", TypeOfLog.exclamationcircle);
                Connection.Close();
                return false;
            }

        }
        /// <summary>
        /// البحث عن الايدي
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Int64 GetID(string name,TypesSections type)
        {
            string con = $"Select * from Tables Where name='{name}';";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(con, Connection.OpenAndReturn());
            try
            {
                DataTable DT = new DataTable();
                adapter.Fill(DT);
                var id = DT.Rows.Cast<DataRow>().Where(id_ => id_.Field<Int64>("ID") > 0).FirstOrDefault().Field<Int64>("ID");

                Connection.Close();
                return (id == 0) ? 0 : id;
            }
            catch (Exception ex)
            {
                LoggerViewModel.Log($"Error At GetID Line 170-171 Class ProtoType Exception->ex:{ex.Message}", TypeOfLog.exclamationcircle);
                if (ex.Message.Contains("There is no row at position ") ||ex.Message.Contains("row"))
                {
                    if (type==TypesSections.FollowersSection)
                    {
                    HelperSelector.AddTable(new System.Collections.ObjectModel.ObservableCollection<AccountOperations>(), name);

                    }
                    else if (type==TypesSections.CommentsAndPostsSection)
                    {
                        HelperSelector.AddTable(new System.Collections.ObjectModel.ObservableCollection<ModelPost>(), name);

                    }else
                    {
                        /* قسم البحث  */
                    }
                    LoggerViewModel.Log($"ALERT ALERT ALERT :HelperSelector has been add new table {HelperSelector.CurrentSection.ToString()}", TypeOfLog.Warning);
                    GetID(name,type);

                }
                Connection.Close();
                return 0;
            }

        }
        /// <summary>
        /// جلب البيانات الجدول المحدد-
        /// </summary>
        /// <param name="name">اسم الجدول المراد جلب البيانات منه</param>
        /// <returns></returns>
        public DataTable Fill(string Name_)
        {
            var dt = new DataTable();
            string con = $"select * from Tables;";
            try
            {
                var adapter = new SQLiteDataAdapter(con, Connection.OpenAndReturn());
                adapter.Fill(dt);
                Connection.Close();
                return dt;
            }
            catch (Exception ex_Fill)
            {
                LoggerViewModel.Log($"Error:{ex_Fill.InnerException} Method Fill Class LoginDB", TypeOfLog.exclamationcircle);
                Connection.Close();
                return null;
            }
        }
        /// <summary>
        /// تغير اسم جدول محدد
        /// </summary>
        /// <param name="name"></param>
        /// <param name="NewName"></param>
        /// <returns></returns>
        public bool EditTable(string name,string NewName)
        {
            string con = $"Update Tables Set name='{NewName}' Where name='{name}';";
            var command = new SQLiteCommand(con, Connection.OpenAndReturn());
            try
            {
                command.ExecuteNonQuery();
                Connection.Close();
                LoggerViewModel.Log($"You have been changed name of table from {name} to {NewName}.", TypeOfLog.check);
                return true;
            }
            catch (Exception ex_Edittable)
            {
                LoggerViewModel.Log($"Error At Prototype in EditTable Line 234-236 ErrorCode:#1456,Exceotion:{ex_Edittable.Message}",TypeOfLog.exclamationcircle);
                Connection.Close();
                return false;
            }
        }

    }
}
