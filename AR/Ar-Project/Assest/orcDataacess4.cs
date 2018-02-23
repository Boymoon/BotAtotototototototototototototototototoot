using System.Data;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SQLite;

namespace Ar_Project.Assest
{
    public class orcDataacess4
    {
        public static string name = OrcDataAcess.namae;
        public static string password = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
        public void Add(string name, string price, string items, string State, string id)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            string IQUERY = "INSERT INTO MEGA2(NAME,STATE,ITEMS,PRICE,ID) VALUES('" + name + "','" + State + "','" + items + "','" + price + "','" + id + "')";
            System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(IQUERY, cn);


            cn.Open();
            com.ExecuteNonQuery();
            cn.Close();

        }
        public void Show(DataTable datatAable)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString =  cn.ConnectionString = D.ConnectionString(name, password);
            cn.Open();
            String IQuery = "Select * From MEGA2";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.CommandText = IQuery;
            cm.Connection = cn;
            SQLiteDataAdapter IODA = new SQLiteDataAdapter(cm);
            IODA.Fill(datatAable);
            cn.Close();
        }
        public void Delete(string _ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString =  cn.ConnectionString = D.ConnectionString(name, password);
            String IQuery = "DELETE from MEGA2 WHERE ID  =" + _ID + "";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand(IQuery, cn);


            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();


        }
        public void Updating(string name, String state, string price, string id, string items)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString =  cn.ConnectionString = D.ConnectionString(name, password);
            string IQUERY = "UPDATE MEGA2 SET NAME='" + name + "' ,STATE='" + state + "' ,ITEMS='" + items + "' ,PRICE='" + price + "' WHERE ID= " + id + "";
            System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(IQUERY, cn);


            cn.Open();
            com.ExecuteNonQuery();
            cn.Close();

        }
    }
}
