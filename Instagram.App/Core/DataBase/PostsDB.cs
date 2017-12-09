using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{

    public class PostsDB : PrototypeOfDB, IDataBase
    {
        /// <summary>
        /// اضافة عنصر جديد 
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <param name="args">ContextMedia,UidOfpost,Context,publisher,publishedat,UidOfpublisher,Likes,Views,name<Required></param>
        /// <returns></returns>
        public bool InsertItem(string name,string[] args)
        {
            if (args[8] == null || args[8] == "0")
            {
                args[8] = GetID(name,TypesSections.CommentsAndPostsSection).ToString();
                //
            }
            string con = $"insert into SectionPM (ContextMedia,UidOfpost,Context,publisher,publishedat,UidOfpublisher,Likes,Views,ID) " +
                $"Values('{args[0]}','{args[1]}','{args[2]}','{args[3]}','{args[4]}','{args[5]}','{args[6]}','{args[7]}','{args[8]}');";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(con, Connection.OpenAndReturn());
            try
            {
                sQLiteCommand.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                LoggerViewModel.Log($"Error:{ex.InnerException} at InsertItem in PostDB Line 40~45", TypeOfLog.exclamationcircle);
                Connection.Close();
                return false;
            }
        }
        /// <summary>
        /// حذف عنصر معين من جدول محدد
        /// </summary>
        /// <param name="name">اسم الجدول المراد حذف العنصر منه</param>
        /// <param name="args">برامترز خاصة بالعنصر المراد حذفه</param>
        /// <param name="args">ContextMedia,UidOfpost,Context,publisher,publishedat,UidOfpublisher,Likes,Views,name,ID<Required></param>
        /// <returns></returns>
        public bool DeleteItem(string name, string[] args)
        {
            args[8] = GetID(name,TypesSections.CommentsAndPostsSection).ToString();

            string con = $"delete from SectionPM Where ContextMedia='{args[0]}'" +
                $" And UidOfpost                                   ='{args[1]}'" +
                $" And Context                                     ='{args[2]}'" +
                $" And publisher                                   ='{args[3]}'" +
                $" And publishedat                                 ='{args[4]}'" +
                $" And UidOfpublisher                              ='{args[5]}'" +
                $" And Likes                                       ='{args[6]}'" +
                $" And Views                                       ='{args[7]}'" +
                $" And ID                                          ='{args[8]}'";
            var deleteCommand = new SQLiteCommand(con, Connection.OpenAndReturn());
            try
            {
                deleteCommand.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception ex_PostDelete)
            {
                LoggerViewModel.Log($"Error:{ex_PostDelete.InnerException} At PostDB ,in:DeleteItem,Line:49~70,Exception name ->ex_PostDelete", TypeOfLog.exclamationcircle);
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
            Int64 id = GetID(name,TypesSections.CommentsAndPostsSection);
            var dt = new DataTable();
            string con = $"select * from SectionPM where ID={id};";
            try
            {
                var adapter = new SQLiteDataAdapter(con, Connection.OpenAndReturn());
                adapter.Fill(dt);
                Connection.Close();
                return dt;
            }
            catch (Exception ex_Fill)
            {
                LoggerViewModel.Log($"Error:{ex_Fill.InnerException} Method Fill Class PostsDB",TypeOfLog.exclamationcircle);
                return null;
            }
        }
        public int GetCount(Int64 id)
        {
            int idd = 0;
            var dt = new DataTable();
            string con = $"select Count(*) from SectionPM where ID={id};";
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
                LoggerViewModel.Log($"Error:{ex_Fill.InnerException} Method GetCount Class PostsDB", TypeOfLog.exclamationcircle);
                return 0;
            }
        }
    }
}
