using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SQLite;

namespace Ar_Project.Assest
{
   public class OrcDataAcess2
    {
        public static string name = OrcDataAcess.namae;
        public static string pass = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
        public void Show(DataTable datatable)
        {
            
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            cn.Open();
            String IQuery = "Select * From ARGOSTA2";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.CommandText = IQuery;
            cm.Connection = cn;
            SQLiteDataAdapter IODA = new SQLiteDataAdapter(cm);
            IODA.Fill(datatable);
            cn.Close();
        }
        public void  Delete(string _ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            String IQuery = $"DELETE from [ARGOSTA2] WHERE ID  ='{_ID}'";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand(IQuery,cn);
            cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                
            
        }
        public void Udapting(string name, int Num, string ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            String IQuery = $"UPDATE ARGOSTA2 SET NAME='{name}',NUM='{Num}' WHERE ID  ='{ID}'";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        
        public void Insert(string name,int Num,string ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            String IQuery = "INSERT INTO ARGOSTA2(NAME,NUM,ID) VALUES('"+name+"','"+Num+"','"+ID+"')";
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
