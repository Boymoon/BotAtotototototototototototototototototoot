using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Project
{
    public class ModelMega : IModelMega
    {
        Assest.OrcDataAcess data = null;

      





        public OleDbConnection cn()
        {
            var a = new Assest.OrcDataAcess();
            return new OleDbConnection(a.ConnectionString("", ""));

        }
        
        
        
        
        
        
        
        
        
        
               ///  


        public void add1(string id,string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone)
         {
            var d = new Assest.OrcDataAcess();
            OleDbConnection cna = new OleDbConnection();
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








            OleDbCommand cm = new OleDbCommand();


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
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = "DELETE from [MEGARIP2]";
            OleDbCommand cm = new OleDbCommand(insert_query, cn);
          //  cm.Parameters.AddWithValue("?", index);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Delete1(String index)
        {
            var d = new Assest.OrcDataAcess();
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = "DELETE from [MEGARIP2] WHERE ID=?";
            OleDbCommand cm = new OleDbCommand(insert_query, cn);
            cm.Parameters.AddWithValue("?", index);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Edit1(string id, string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone)
        {
            //ID,NAME,PRICE,DAT,discounts,datrec,conprou,typeprou,isdone
            OleDbConnection cn = new OleDbConnection();
            var d = new Assest.OrcDataAcess();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = "UPDATE MEGARIP2 SET NAME=?,PRICE=? ,DAT=? ,discounts=? ,datrec=? ,conprou=? ,typeprou=? ,isdone=? WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;
            cm.Parameters.AddWithValue("?", name);
            cm.Parameters.AddWithValue("?", price);
            cm.Parameters.AddWithValue("?", date);
            cm.Parameters.AddWithValue("?", discounts);
            cm.Parameters.AddWithValue("?", darec);
            cm.Parameters.AddWithValue("?", conprou);
            cm.Parameters.AddWithValue("?", typeprou);
            cm.Parameters.AddWithValue("?", isdone);
            cm.Parameters.AddWithValue("?", id);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }

        public void show1(DataTable data)
        {
            data.MinimumCapacity = 9999999;

            cn().Open();
            OleDbCommand cm = new OleDbCommand();
            string query = "Select * from MEGARIP2";
            cm.CommandText = query;
            cm.Connection = cn();
            OleDbDataAdapter Oracldata = new OleDbDataAdapter(cm);
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
            OleDbConnection cna = new OleDbConnection();
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

            // string insert_query = "INSERT INTO MEGARIP ([ID],[NAME],[PRICE],[DAT],[discounts],[datrec],[conprou],[typeprou],[isdone]) VALUES(?,?,?,?,?,?,?,?,?)";


            //  string insert = "INSERT INTO MEGARIP(ID,NAME,PRICE,DAT,discounts,datrec,conprou,typeprou,isdone) VALUES('"+"g"+"','"+"A"+"','"+"123"+"','"+"ABC"+"','"+"HG"+"','"+"ABC"+"','"+"as"+"','"+"HGT"+"','"+Booolint+"')";


            // String Ainsert="INSERT INTO MEGARIP(ID,NAME,PRICE,DAT,discounts,datrec)"








            OleDbCommand cm = new OleDbCommand();


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

        public void Delete()
        {
            var d = new Assest.OrcDataAcess();
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = "DELETE from [MEGARIP]";
            OleDbCommand cm = new OleDbCommand(insert_query, cn);
          //  cm.Parameters.AddWithValue("?", index);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Delete(String index)
        {
            var d = new Assest.OrcDataAcess();
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = "DELETE from [MEGARIP] WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand(insert_query, cn);
            cm.Parameters.AddWithValue("?", index);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Edit(string id, string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone)
        {
            //ID,NAME,PRICE,DAT,discounts,datrec,conprou,typeprou,isdone
            OleDbConnection cn = new OleDbConnection();
            var d = new Assest.OrcDataAcess();
            cn.ConnectionString = d.ConnectionString("", "");
            string insert_query = "UPDATE MEGARIP SET NAME=?,PRICE=? ,DAT=? ,discounts=? ,datrec=? ,conprou=? ,typeprou=? ,isdone=? WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;
            cm.Parameters.AddWithValue("?", name);
            cm.Parameters.AddWithValue("?", price);
            cm.Parameters.AddWithValue("?", date);
            cm.Parameters.AddWithValue("?", discounts);
            cm.Parameters.AddWithValue("?", darec);
            cm.Parameters.AddWithValue("?", conprou);
            cm.Parameters.AddWithValue("?", typeprou);
            cm.Parameters.AddWithValue("?", isdone);
            cm.Parameters.AddWithValue("?", id);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }

        public void show(DataTable data)
        {
            data.MinimumCapacity = 600;
            cn().Open();
            OleDbCommand cm = new OleDbCommand();
            string query = "Select * from MEGARIP";
            cm.CommandText = query;
            cm.Connection = cn();
            OleDbDataAdapter Oracldata = new OleDbDataAdapter(cm);
            Oracldata.Fill(data);
            cn().Close();
        }
    }
}
