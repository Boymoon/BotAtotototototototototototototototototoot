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

namespace Ar_Project.Assest
{
    public class Account
    {
        //OleDbConnection
        //OleDbConnection
        public static string name = OrcDataAcess.namae;
        public static string pass = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
      
       
        public void Show(DataTable datatable)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            cn.Open();
            String IQuery = "Select * From ACCOUNT";
            OleDbCommand cm = new OleDbCommand();
            cm.CommandText = IQuery;
            cm.Connection = cn;
            OleDbDataAdapter IODA = new OleDbDataAdapter(cm);
            IODA.Fill(datatable);
            cn.Close();
        }

        public void Udapting(string name, string Pass,string lol, string ID, String State)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);;
            // String IQuery = "UPDATE ACCOUNT SET NAME='" + name + "' ,PASS='" + lol + "' ,STATE='" + State + "' WHERE ID= " + ID + "";
            String IQuery = "UPDATE ACCOUNT SET NAME=? ,PASS=? ,STATE=? WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = IQuery;
            cm.Parameters.AddWithValue("?", name);
            cm.Parameters.AddWithValue("?", lol);
            cm.Parameters.AddWithValue("?", State);
            cm.Parameters.AddWithValue("?", ID);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();

        }
        public void Delete(string _ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);;
            String IQuery = "DELETE from ACCOUNT WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand(IQuery, cn);
            cm.Parameters.AddWithValue("?", _ID); ;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();


        }
        public void Insert(string name, string Num, string State, string id)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);;
            String IQuery = "insert into ACCOUNT(NAME, PASS, STATE, TDATE, ID) values('" + name + "','" + Num + "','" + State + "','" + DateTime.Now + "','" + id + "')";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();

        }
    }
}
