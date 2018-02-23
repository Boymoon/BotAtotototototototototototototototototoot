using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Windows.Input;

namespace Ar_Project.Assest
{
    public class OrcDataAcess
    {
  
        string path = System.Windows.Forms.Application.StartupPath + "\\dbPascal.db";
        public OrcDataAcess(string path = null)
        {
            this.path = path;
        }
        public static string namae = null;
        public static string pasas = null;

        public string ConnectionString(string name, string pass)
        {

            string connectiongStrings = $"Data Source=" + System.Windows.Forms.Application.StartupPath + "\\dbPascal.db;Version=3;";
            return connectiongStrings;
        }
        public void Delete(int _ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = $"DELETE from [ARGOSTA] WHERE ID  ='{_ID}'";
            SQLiteCommand cm = new SQLiteCommand(insert_query, cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void _Delete(double price)
        {
            SQLiteConnection cn = new SQLiteConnection();

            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "DELETE from CARA";
            SQLiteCommand cm = new SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();



        }



        //public void _Delete(double price)
        //{
        //    SQLiteConnection cn = new SQLiteConnection();

        //    cn.ConnectionString = ConnectionString(namae, pasas);
        //    string insert_query = "DELETE from CARA WHERE PRICE  =" + price + "";
        //    SQLiteCommand cm = new SQLiteCommand();
        //    cm.Connection = cn;
        //    cm.CommandText = insert_query;

        //    cn.Open();
        //    cm.ExecuteNonQuery();
        //    cn.Close();



        //}
        public void _Add(string name, string price, String Barcode)
        {


            string Filtring = price.ToString().Replace("SAR", "");
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "insert into CARA (BARCODE,NAME,PRICE) VALUES ('" + Barcode + "','" + name + "','" + double.Parse(Filtring) + "')";

            SQLiteCommand cm = new SQLiteCommand();
            cm.CommandText = insert_query;

            cm.Connection = cn;


            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Show_(DataTable datatable)
        {


            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand();
            string query = "Select * from CARA";
            cm.CommandText = query;
            cm.Connection = cn;
            SQLiteDataAdapter Oracldata = new SQLiteDataAdapter(cm);
            Oracldata.Fill(datatable);

            cn.Close();
        }
        public void Show_set(DataSet dataset)
        {


            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand();
            string query = "Select * from CARA";
            cm.CommandText = query;
            cm.Connection = cn;
            SQLiteDataAdapter Oracldata = new SQLiteDataAdapter(cm);
            Oracldata.Fill(dataset);

            cn.Close();
        }
        public void Updating(String Name, string Price, int Quantity, String Barcode, String Dis, String Price_F, string Price_a, int ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = $"UPDATE ARGOSTA SET NAME='{Name}',PRICE='{Price}' ,QUANTITY='{Quantity}' ,BARCODE='{Barcode}' ,PRICE_A='{Price_a}' ,Dis='{Dis}' ,Price_F='{Price_F}' WHERE ID  ='{ID}'";
            SQLiteCommand cm = new SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;
            //cm.Parameters.AddWithValue("?", Name);
            //cm.Parameters.AddWithValue("?", Price);
            //cm.Parameters.AddWithValue("?", Quantity);
            //cm.Parameters.AddWithValue("?", Barcode);
            //cm.Parameters.AddWithValue("?", Price_a);
            //cm.Parameters.AddWithValue("?", Dis);
            //cm.Parameters.AddWithValue("?", Price_F);
            //cm.Parameters.AddWithValue("?", ID);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public void Updating_QUa(string qua, string id)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = $"UPDATE [ARGOSTA] SET QUANTITY='{qua}'  WHERE ID  ='{id}'";
            SQLiteCommand cm = new SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;


            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Show(DataTable datatable)
        {

            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand();
            string query = "Select * from ARGOSTA";
            cm.CommandText = query;
            cm.Connection = cn;
            SQLiteDataAdapter Oracldata = new SQLiteDataAdapter(cm);
            Oracldata.Fill(datatable);
            cn.Close();



        }
        public void insert(string name, string Price, String Dat, String ID, String Qua, String price_a,String Dis,String Price_F, String barcode = "0")
        {
            ID = new Random().Next(14, (int)999999999).ToString();
            var datatable__ = new DataTable();
            Show(datatable__);
            var Check_For_ID = datatable__.Rows.Cast<DataRow>().Where(row => row.Field<string>("ID") == ID).FirstOrDefault();
            if (Check_For_ID.Field<string>("ID") == ID)
            {
                insert(name, Price, Dat, ID, Qua, price_a, Dis, Price_F, barcode);
            }
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "INSERT INTO ARGOSTA (NAME,PRICE,DAT,BARCODE,ID,QUANTITY,PRICE_A,Dis,Price_F) VALUES ('" + name + "','" + Price + "','" + DateTime.Now + "','" + barcode + "','" + ID + "','" + Qua + "','" + price_a +"','"+Dis+"','"+Price_F+"')";
            SQLiteCommand cm = new SQLiteCommand();


            cm.Connection = cn;
            cm.CommandText = insert_query;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();


        }
       
        public void show3(DataTable datatable)
        {

            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand();
            string query = "Select * from ARGOSTA3";
            cm.CommandText = query;
            cm.Connection = cn;
            SQLiteDataAdapter Oracldata = new SQLiteDataAdapter(cm);
            Oracldata.Fill(datatable);
            cn.Close();



        }
        public void Delete3()
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "DELETE from [ARGOSTA3]";
            SQLiteCommand cm = new SQLiteCommand(insert_query, cn);
            // cm.Parameters.AddWithValue("?", "1");
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Delete3(string ID)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = $"DELETE from [ARGOSTA3] WHERE ID  ='{ID}'";
            SQLiteCommand cm = new SQLiteCommand(insert_query, cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void insert3(string tt, string name, string Price, String ID, String Qua, String price_a, String barcode = "0", String NUMF = "0",string DOW="Na/N",string SUMPRICE="0")
        {
            Guid id = Guid.NewGuid();
            ID = id.ToString().Replace("-","");


            SQLiteConnection cn = new SQLiteConnection();
                cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "INSERT INTO ARGOSTA3 (NAME,NAME2,PRICE,DAT,BARCODE,ID,QUANTITY,PRICE_A,NUMF,DOW) VALUES ('" + name + "','" + SUMPRICE  + "','" + Price + "','" + tt + "','" + barcode + "','" + ID + "','" + Qua + "','" + price_a + "','" + NUMF + "','" + DOW + "')";
            SQLiteCommand cm = new SQLiteCommand();


            cm.Connection = cn;
            cm.CommandText = insert_query;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }



        public void show4(DataTable datatable)
        {

            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand();
            string query = "Select * from ARGOSTA4";
            cm.CommandText = query;
            cm.Connection = cn;
            SQLiteDataAdapter Oracldata = new SQLiteDataAdapter(cm);
            Oracldata.Fill(datatable);
            cn.Close();



        }
        public void Delete4()
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "DELETE from [ARGOSTA4]";
            SQLiteCommand cm = new SQLiteCommand(insert_query, cn);
           // cm.Parameters.AddWithValue("?", "1");
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void insert4(string tt, string name, string Price, String Qua, String price_a, String barcode = "0", String NUMF = "0", string DOW = "Na/N", string SUMPRICE = "0")
        {
            

            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "INSERT INTO ARGOSTA4 (NAME,NAME2,PRICE,DAT,BARCODE,ID,QUANTITY,PRICE_A,NUMF,DOW) VALUES ('" + name + "','" + SUMPRICE + "','" + Price + "','" + tt + "','" + barcode + "','" + "1" + "','" + Qua + "','" + price_a + "','" + NUMF + "','" + DOW + "')";
            SQLiteCommand cm = new SQLiteCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }


    }
}



    
        


    












