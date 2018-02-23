using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using System.Data.OleDb;
using System.Data.SQLite;

namespace Ar_Project.Assest
{

    public class Capt2
    {
        public static string name = OrcDataAcess.namae;
        public static string pass = OrcDataAcess.pasas;
        private OrcDataAcess D = new OrcDataAcess();
        public void show(DataTable datatable)
        {

            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            cn.Open();
            string Iquery = "Select * From Doll";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();
            cm.CommandText = Iquery;
            cm.Connection = cn;
            SQLiteDataAdapter IODA = new SQLiteDataAdapter(cm);
            IODA.Fill(datatable);
            cn.Close();
        }
        public void Updating2(string day)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            string IQuery = "UPDATE Doll SET DAY=" + day + "";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();


            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }
        public void Updating3(string mounth)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            string IQuery = "UPDATE Doll SET YEAR=" + mounth + "";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();


            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }
        public void Updating4(string Year)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            string IQuery = "UPDATE Doll SET MOUNTH=" + Year + "";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();

            cm.Connection = cn;
            cm.CommandText = IQuery;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }

        public void Updating(string Price, string dat, string day, string year, string mounth)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            string IQuery = "UPDATE Doll SET PRICE='" + Price + "' ,DAT='" + dat + "',DAY='" + day + "',YEAR='" + year + "',MOUNTH='" + mounth + "' WHERE DAY= " + day + "";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand();

            cm.Connection = cn;
            cm.CommandText = IQuery;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }
        public void Insert(string price, string day, string mounth, string year, string dat,String name)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = D.ConnectionString(name, pass);
            cn.Open();
            String IQuery = $"insert into Doll (PRICE, DAT, DAY,MOUNTH,YEAR,NAME) values('{price}','{dat}','{day}','{mounth}','{year}','{name}')";
            System.Data.SQLite.SQLiteCommand cm = new System.Data.SQLite.SQLiteCommand(IQuery,cn);

            cm.ExecuteNonQuery();
            cn.Close();
            cm.Dispose();



        }
    }
}
