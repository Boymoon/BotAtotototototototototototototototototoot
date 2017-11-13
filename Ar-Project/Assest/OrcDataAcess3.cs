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
   public class OrcDataAcess3
    {
        //OleDbCommand
        
        public static string name = OrcDataAcess.namae;
        public static string password = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
        public void  Add(string name ,string price,string items,string State,string id)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            string IQUERY = "INSERT INTO MEGA(NAME,STATE,ITEMS,PRICE,ID) VALUES('"+name+"','"+price+"','"+items+"','"+State+"','"+id+"')";
            OleDbCommand com = new OleDbCommand();
            com.CommandText = IQUERY;
            com.Connection = cn;
                cn.Open();
                com.ExecuteNonQuery();
                cn.Close();
            
        }
        public void Show(DataTable datatable)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            cn.Open();
            String IQuery = "Select * From MEGA";
            OleDbCommand cm = new OleDbCommand();
            cm.CommandText = IQuery;
            cm.Connection = cn;
            OleDbDataAdapter IODA = new OleDbDataAdapter(cm);
            IODA.Fill(datatable);
            cn.Close();
        }
        public void Delete(string _ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            String IQuery = "DELETE from [MEGA] WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand(IQuery,cn);
            cm.Parameters.AddWithValue("?", _ID);

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            
        }
        public void Updating(string name,String state,string price,string id,string items)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            string IQUERY = "UPDATE MEGA SET NAME=? ,STATE=? ,ITEMS=?,PRICE=? WHERE ID=? ";
            using(OleDbCommand com = new OleDbCommand(IQUERY, cn))
            {
                com.Parameters.AddWithValue(name, "?");
                com.Parameters.AddWithValue(state, "?");
                com.Parameters.AddWithValue(price, "?");
                com.Parameters.AddWithValue(items, "?");
                com.Parameters.AddWithValue(id, "?");
                cn.Open();
                com.ExecuteNonQuery();
                cn.Close();
            }
               
               
            
        }

    }
}
