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
   public class OrcDataAcess3
    {
        //SQLiteCommand
        
        public static string name = OrcDataAcess.namae;
        public static string password = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
        public void  Add(string name ,string price,string items,string State,string id)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            string IQUERY = "INSERT INTO MEGA(NAME,STATE,ITEMS,PRICE,ID) VALUES('"+name+"','"+price+"','"+items+"','"+State+"','"+id+"')";
            SQLiteCommand com = new SQLiteCommand();
            com.CommandText = IQUERY;
            com.Connection = cn;
                cn.Open();
                com.ExecuteNonQuery();
                cn.Close();
            
        }
        public void Show(DataTable datatable)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            cn.Open();
            String IQuery = "Select * From MEGA";
            SQLiteCommand cm = new SQLiteCommand();
            cm.CommandText = IQuery;
            cm.Connection = cn;
            SQLiteDataAdapter IODA = new SQLiteDataAdapter(cm);
            IODA.Fill(datatable);
            cn.Close();
        }
        public void Delete(string _ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            String IQuery = $"DELETE from [MEGA] WHERE ID  ='{_ID}'";
            SQLiteCommand cm = new SQLiteCommand(IQuery,cn);

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            
        }
        public void Updating(string name,String state,string price,string id,string items)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            string IQUERY = $"UPDATE MEGA SET NAME='{name}' ,STATE='{state}' ,ITEMS='{price}',PRICE='{items}' WHERE ID='{id}' ";
            using(SQLiteCommand com = new SQLiteCommand(IQUERY, cn))
            {
                cn.Open();
                com.ExecuteNonQuery();
                cn.Close();
            }
               
               
            
        }

    }
}
