using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Project
{
    public class ModelMega : IModelMega
    {
        Assest.OrcDataAcess data = null;

      





        public SQLiteConnection cn()
        {
            var a = new Assest.OrcDataAcess();
            return new SQLiteConnection(a.ConnectionString("", ""));

        }
        
        
        
        
        
        
        
        
        
        
               ///  


        public void add1(string id,string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone)
         {
            var d = new Assest.OrcDataAcess();
            SQLiteConnection cna = new SQLiteConnection();
            cna.ConnectionString = d.ConnectionString("", "");
           
            string insert_query = null;
            insert_query = "INSERT INTO MEGARIP2 (NAME,PRICE,DAT,discounts,datrec,conprou,typeprou,isdone,ID) VALUES ('" + name
                         + "','" +
                                                                  price
                        + "','"
                      + date +
                      "','" +
                                                                           discounts +
                       "','" +
                                                                                       darec
                        + "','"
                                                                                              + conprou
                        + "','"
                                                                                                        + typeprou
                        + "','"
                      +
                                                                                                                 isdone + "','"
                                                                                                                     + id.ToString().Replace("-", "")

                                                                                                                 +
                    "')";

            // string insert_query = "INSERT INTO MEGARIP ([ID],[NAME],[PRICE],[DAT],[discounts],[datrec],[conprou],[typeprou],[isdone]) VALUES(?,?,?,?,?,?,?,?,?)";


            //  string insert = "INSERT INTO MEGARIP(ID,NAME,PRICE,DAT,discounts,datrec,conprou,typeprou,isdone) VALUES('"+"g"+"','"+"A"+"','"+"123"+"','"+"ABC"+"','"+"HG"+"','"+"ABC"+"','"+"as"+"','"+"HGT"+"','"+Booolint+"')";


            // String Ainsert="INSERT INTO MEGARIP(ID,NAME,PRICE,DAT,discounts,datrec)"








            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();


            cm.Connection = cna;
           // cm.CommandType = CommandType.Text;
            cm.CommandText = insert_query;
            //cm.Parameters.AddWithValue("?", id);//1
            //cm.Parameters.AddWithValue("?", name);//2
            //cm.Parameters.AddWithValue("?", price);//3
            //cm.Parameters.AddWithValue("?", date);//4
            //cm.Parameters.AddWithValue("?", discounts);//5
            //cm.Parameters.AddWithValue("?", "FG");//6
            //cm.Parameters.AddWithValue("?", conprou);//7
            //cm.Parameters.AddWithValue("?", typeprou);//8
            //cm.Parameters.AddWithValue("?", isdone);//9
            cna.Open();
            cm.ExecuteNonQuery();
            cna.Close();






    }


        /// </summary>

        public void Delete1()
        {
            var d = new Assest.OrcDataAcess();
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = "DELETE from [MEGARIP2]";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand(insert_query, cn);
          //  cm.Parameters.AddWithValue("?", index);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Delete1(String index)
        {
            var d = new Assest.OrcDataAcess();
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = $"DELETE from [MEGARIP2] WHERE ID='{index}'";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand(insert_query, cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Edit1(string id, string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone)
        {
            //ID,NAME,PRICE,DAT,discounts,datrec,conprou,typeprou,isdone
            SQLiteConnection cn = new SQLiteConnection();
            var d = new Assest.OrcDataAcess();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = $"UPDATE MEGARIP2 SET NAME='{name}',PRICE='{price}' ,DAT='{date}' ,discounts='{discounts}' ,datrec='{darec}' ,conprou='{conprou}' ,typeprou='{typeprou}',isdone='{isdone}' WHERE ID  ='{id}'";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }

        public void show1(DataTable data)
        {
            data.MinimumCapacity = 9999999;

            cn().Open();
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            string query = "Select * from MEGARIP2";
            cm.CommandText = query;
            cm.Connection = cn();
            SQLiteDataAdapter Oracldata = new SQLiteDataAdapter(cm);
            Oracldata.Fill(data);
            cn().Close();
        }
        
        
        
        /*
        في نظام الاضافة لقسم الصيانة نحتاج الى 
        -----------------------------------------------
       اسم الصنف  //name
       ------------------------------------------
       ترميز الصنف   //id
       ----------------------------------------------
       تاريخ اضافة الصنف  //date
       ----------------------------------------------

       موعد استلام الصنف  //darec
       ---------------------------------------------
---------------------
      نسبة الخصم.. //discounts
        ----------------------------------------------
       وصف العطل في الصنف conprou
       --------------------------------------------------
       لمعرفة هل الطلب تم تسليمه ام لا  isdone?
       --------------------------------------------------------
       نوع الصنف   typeprou
       -----     --------------------------------------------------------
            */  /// <summary>
                ///  Erd Sys
                ///  


        public void add(string id,string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone)
         {
            var d = new Assest.OrcDataAcess();
            SQLiteConnection cna = new SQLiteConnection();
            cna.ConnectionString = d.ConnectionString("", "");
           
            string insert_query = null;
            insert_query = "INSERT INTO MEGARIP (NAME,PRICE,DAT,discounts,datrec,conprou,typeprou,isdone,ID) VALUES ('" + name
                         + "','" +
                                                                  price
                        + "','"
                      + date +
                      "','" +
                                                                           discounts +
                       "','" +
                                                                                       darec
                        + "','"
                                                                                              + conprou
                        + "','"
                                                                                                        + typeprou
                        + "','"
                      +
                                                                                                                 isdone + "','"
                                                                                                                     + id.ToString().Replace("-", "")

                                                                                                                 +
                    "')";

            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();


            cm.Connection = cna;
           // cm.CommandType = CommandType.Text;
            cm.CommandText = insert_query;
            cna.Open();
            cm.ExecuteNonQuery();
            cna.Close();






    }


        /// </summary>

        public void Delete()
        {
            var d = new Assest.OrcDataAcess();
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = "DELETE from [MEGARIP]";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand(insert_query, cn);
          //  cm.Parameters.AddWithValue("?", index);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Delete(String index)
        {
            var d = new Assest.OrcDataAcess();
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = $"DELETE from [MEGARIP] WHERE ID  ='{index}'";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand(insert_query, cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Edit(string id, string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone)
        {
            //ID,NAME,PRICE,DAT,discounts,datrec,conprou,typeprou,isdone
            SQLiteConnection cn = new SQLiteConnection();
            var d = new Assest.OrcDataAcess();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = $"UPDATE MEGARIP SET NAME='{name}',PRICE='{price}' ,DAT='{date}' ,discounts='{discounts}' ,datrec='{darec}' ,conprou='{conprou}' ,typeprou='{typeprou}',isdone='{isdone}' WHERE ID  ='{id}'";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }

        public void show(DataTable data)
        {
            data.MinimumCapacity = 600;
            cn().Open();
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            string query = "Select * from MEGARIP";
            cm.CommandText = query;
            cm.Connection = cn();
            SQLiteDataAdapter Oracldata = new SQLiteDataAdapter(cm);
            Oracldata.Fill(data);
            cn().Close();
        }
    }
}
