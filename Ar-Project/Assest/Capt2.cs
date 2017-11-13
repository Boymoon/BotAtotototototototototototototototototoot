using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using System.Data.OleDb;

namespace Ar_Project.Assest
{

    public class Capt2
    {
        public static string name = OrcDataAcess.namae;
        public static string pass = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
        public void show(DataTable datatable)
        {

            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            cn.Open();
            string Iquery = "Select * From Doll";
            OleDbCommand cm = new OleDbCommand();
            cm.CommandText = Iquery;
            cm.Connection = cn;
            OleDbDataAdapter IODA = new OleDbDataAdapter(cm);
            IODA.Fill(datatable);
            cn.Close();
        }
        public void Updating2(string day)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            string IQuery = "UPDATE Doll SET DAY=" + day + "";
            OleDbCommand cm = new OleDbCommand();


            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }
        public void Updating3(string mounth)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            string IQuery = "UPDATE Doll SET YEAR=" + mounth + "";
            OleDbCommand cm = new OleDbCommand();


            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }
        public void Updating4(string Year)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            string IQuery = "UPDATE Doll SET MOUNTH=" + Year + "";
            OleDbCommand cm = new OleDbCommand();

            cm.Connection = cn;
            cm.CommandText = IQuery;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }

        public void Updating(string Price, string dat, string day, string year, string mounth)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            string IQuery = "UPDATE Doll SET PRICE='" + Price + "' ,DAT='" + dat + "',DAY='" + day + "',YEAR='" + year + "',MOUNTH='" + mounth + "' WHERE DAY= " + day + "";
            OleDbCommand cm = new OleDbCommand();

            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }
        public void Insert(string price, string day, string mounth, string year, string dat,String name)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            cn.Open();
            String IQuery = "insert into [Doll]([PRICE], [DAT], [DAY], [MOUNTH], [YEAR],[NAME]) values(?,?,?,?,?,?)";
            OleDbCommand cm = new OleDbCommand(IQuery,cn);
            cm.Parameters.AddWithValue("?", price);
            cm.Parameters.AddWithValue("?", dat);
            cm.Parameters.AddWithValue("?", day);
            cm.Parameters.AddWithValue("?", mounth);
            cm.Parameters.AddWithValue("?", year);
            cm.Parameters.AddWithValue("?", name);

            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }
    }
}
