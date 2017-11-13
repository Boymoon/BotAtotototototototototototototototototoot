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

namespace Ar_Project.Assest
{
   public class OrcDataAcess2
    {
        public static string name = OrcDataAcess.namae;
        public static string pass = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
        public void Show(DataTable datatable)
        {
            
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            cn.Open();
            String IQuery = "Select * From ARGOSTA2";
            OleDbCommand cm = new OleDbCommand();
            cm.CommandText = IQuery;
            cm.Connection = cn;
            OleDbDataAdapter IODA = new OleDbDataAdapter(cm);
            IODA.Fill(datatable);
            cn.Close();
        }
        public void  Delete(string _ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            String IQuery = "DELETE from [ARGOSTA2] WHERE ID  =?";

            OleDbCommand cm = new OleDbCommand(IQuery,cn);
            cm.Parameters.AddWithValue("?", _ID);

        
            cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                
            
        }
        public void Udapting(string name, int Num, string ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            String IQuery = "UPDATE ARGOSTA2 SET NAME=?,NUM=? WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = IQuery;
            cm.Parameters.AddWithValue("?", name);
            cm.Parameters.AddWithValue("?", Num);
            cm.Parameters.AddWithValue("?", ID);



            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        
        public void Insert(string name,int Num,string ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            String IQuery = "INSERT INTO ARGOSTA2(NAME,NUM,ID) VALUES('"+name+"','"+Num+"','"+ID+"')";
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
