using System.Data;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;

namespace Ar_Project.Assest
{
    public class orcDataacess4
    {
        public static string name = OrcDataAcess.namae;
        public static string password = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
        public void Add(string name, string price, string items, string State, string id)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, password);
            string IQUERY = "INSERT INTO MEGA2(NAME,STATE,ITEMS,PRICE,ID) VALUES('" + name + "','" + State + "','" + items + "','" + price + "','" + id + "')";
            OleDbCommand com = new OleDbCommand(IQUERY, cn);


            cn.Open();
            com.ExecuteNonQuery();
            cn.Close();

        }
        public void Show(DataTable datatAable)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString =  cn.ConnectionString = D.ConnectionString(name, password);
            cn.Open();
            String IQuery = "Select * From MEGA2";
            OleDbCommand cm = new OleDbCommand();
            cm.CommandText = IQuery;
            cm.Connection = cn;
            OleDbDataAdapter IODA = new OleDbDataAdapter(cm);
            IODA.Fill(datatAable);
            cn.Close();
        }
        public void Delete(string _ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString =  cn.ConnectionString = D.ConnectionString(name, password);
            String IQuery = "DELETE from MEGA2 WHERE ID  =" + _ID + "";
            OleDbCommand cm = new OleDbCommand(IQuery, cn);


            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();


        }
        public void Updating(string name, String state, string price, string id, string items)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString =  cn.ConnectionString = D.ConnectionString(name, password);
            string IQUERY = "UPDATE MEGA2 SET NAME='" + name + "' ,STATE='" + state + "' ,ITEMS='" + items + "' ,PRICE='" + price + "' WHERE ID= " + id + "";
            OleDbCommand com = new OleDbCommand(IQUERY, cn);


            cn.Open();
            com.ExecuteNonQuery();
            cn.Close();

        }
    }
}
