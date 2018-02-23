using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using System.Data.OleDb;
using Oracle.DataAccess;
using System.Configuration;
using System.Data.SQLite;

namespace Ar_Project.Assest
{
    public class Account
    {
        //SQLiteConnection
        //SQLiteConnection
        public static string name = OrcDataAcess.namae;
        public static string pass = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
      
       
        public void Show(DataTable datatable)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            cn.Open();
            String IQuery = "Select * From ACCOUNT";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.CommandText = IQuery;
            cm.Connection = cn;
            SQLiteDataAdapter IODA = new SQLiteDataAdapter(cm);
            IODA.Fill(datatable);
            cn.Close();
        }

        public void Udapting(string name, string Pass,string lol, string ID, String State)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);;
            // String IQuery = "UPDATE ACCOUNT SET NAME='" + name + "' ,PASS='" + lol + "' ,STATE='" + State + "' WHERE ID= " + ID + "";
            String IQuery = $"UPDATE ACCOUNT SET NAME='{name}' ,PASS='{pass}' ,STATE='{State}' WHERE ID  ='{ID}'";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();

        }
        public void Delete(string _ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);;
            String IQuery = $"DELETE from ACCOUNT WHERE ID  ='{_ID}'";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand(IQuery, cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();


        }
        public void Insert(string name, string Num, string State, string id)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);;
            String IQuery = "insert into ACCOUNT(NAME, PASS, STATE, TDATE, ID) values('" + name + "','" + Num + "','" + State + "','" + DateTime.Now + "','" + id + "')";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();

        }
    }
}
