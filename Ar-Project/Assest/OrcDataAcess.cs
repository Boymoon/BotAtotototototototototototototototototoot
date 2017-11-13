using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

namespace Ar_Project.Assest
{
    public class OrcDataAcess
    {
  
        string path = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
        public OrcDataAcess(string path = null)
        {
            this.path = path;
        }
        public static string namae = null;
        public static string pasas = null;

        public string ConnectionString(string name, string pass)
        {

            string connectiongStrings = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Windows.Forms.Application.StartupPath + "\\Data.accdb" + ";" +
                "Persist Security Info = False;";
            return connectiongStrings;
        }
        public void Delete(int _ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "DELETE from [ARGOSTA] WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand(insert_query, cn);
            cm.Parameters.AddWithValue("?", _ID);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void _Delete(double price)
        {
            OleDbConnection cn = new OleDbConnection();

            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "DELETE * from CARA  ";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();



        }



        //public void _Delete(double price)
        //{
        //    OleDbConnection cn = new OleDbConnection();

        //    cn.ConnectionString = ConnectionString(namae, pasas);
        //    string insert_query = "DELETE from CARA WHERE PRICE  =" + price + "";
        //    OleDbCommand cm = new OleDbCommand();
        //    cm.Connection = cn;
        //    cm.CommandText = insert_query;

        //    cn.Open();
        //    cm.ExecuteNonQuery();
        //    cn.Close();



        //}
        public void _Add(string name, string price, String Barcode)
        {


            string Filtring = price.ToString().Replace("SAR", "");
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "insert into CARA (BARCODE,NAME,PRICE) VALUES ('" + Barcode + "','" + name + "','" + double.Parse(Filtring) + "')";

            OleDbCommand cm = new OleDbCommand();
            cm.CommandText = insert_query;

            cm.Connection = cn;


            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Show_(DataTable datatable)
        {


            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            OleDbCommand cm = new OleDbCommand();
            string query = "Select * from CARA";
            cm.CommandText = query;
            cm.Connection = cn;
            OleDbDataAdapter Oracldata = new OleDbDataAdapter(cm);
            Oracldata.Fill(datatable);

            cn.Close();
        }
        public void Show_set(DataSet dataset)
        {


            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            OleDbCommand cm = new OleDbCommand();
            string query = "Select * from CARA";
            cm.CommandText = query;
            cm.Connection = cn;
            OleDbDataAdapter Oracldata = new OleDbDataAdapter(cm);
            Oracldata.Fill(dataset);

            cn.Close();
        }
        public void Updating(String Name, string Price, int Quantity, String Barcode, String Dis, String Price_F, string Price_a, int ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "UPDATE ARGOSTA SET NAME=?,PRICE=? ,QUANTITY=? ,BARCODE=? ,PRICE_A=? ,Dis=? ,Price_F=? WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;
            cm.Parameters.AddWithValue("?", Name);
            cm.Parameters.AddWithValue("?", Price);
            cm.Parameters.AddWithValue("?", Quantity);
            cm.Parameters.AddWithValue("?", Barcode);
            cm.Parameters.AddWithValue("?", Price_a);
            cm.Parameters.AddWithValue("?", Dis);
            cm.Parameters.AddWithValue("?", Price_F);
            cm.Parameters.AddWithValue("?", ID);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Updating_QUa(string qua, string id)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "UPDATE [ARGOSTA] SET QUANTITY=?  WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;
            cm.Parameters.AddWithValue("?", qua);
            cm.Parameters.AddWithValue("?", id);

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Show(DataTable datatable)
        {

            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            OleDbCommand cm = new OleDbCommand();
            string query = "Select * from ARGOSTA";
            cm.CommandText = query;
            cm.Connection = cn;
            OleDbDataAdapter Oracldata = new OleDbDataAdapter(cm);
            Oracldata.Fill(datatable);
            cn.Close();



        }
        public void insert(string name, string Price, String Dat, String ID, String Qua, String price_a,String Dis,String Price_F, String barcode = "0")
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "INSERT INTO ARGOSTA (NAME,PRICE,DAT,BARCODE,ID,QUANTITY,PRICE_A,Dis,Price_F) VALUES ('" + name + "','" + Price + "','" + DateTime.Now + "','" + barcode + "','" + ID + "','" + Qua + "','" + price_a +"','"+Dis+"','"+Price_F+"')";
            OleDbCommand cm = new OleDbCommand();


            cm.Connection = cn;
            cm.CommandText = insert_query;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();


        }
       
        public void show3(DataTable datatable)
        {

            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            OleDbCommand cm = new OleDbCommand();
            string query = "Select * from ARGOSTA3";
            cm.CommandText = query;
            cm.Connection = cn;
            OleDbDataAdapter Oracldata = new OleDbDataAdapter(cm);
            Oracldata.Fill(datatable);
            cn.Close();



        }
        public void Delete3()
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "DELETE from [ARGOSTA3]";
            OleDbCommand cm = new OleDbCommand(insert_query, cn);
            // cm.Parameters.AddWithValue("?", "1");
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void Delete3(string ID)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "DELETE from [ARGOSTA3] WHERE ID  =?";
            OleDbCommand cm = new OleDbCommand(insert_query, cn);
            cm.Parameters.AddWithValue("?", ID);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void insert3(string tt, string name, string Price, String ID, String Qua, String price_a, String barcode = "0", String NUMF = "0",string DOW="Na/N",string SUMPRICE="0")
        {
            Guid id = Guid.NewGuid();
            ID = id.ToString().Replace("-","");


            OleDbConnection cn = new OleDbConnection();
                cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "INSERT INTO ARGOSTA3 (NAME,NAME2,PRICE,DAT,BARCODE,ID,QUANTITY,PRICE_A,NUMF,DOW) VALUES ('" + name + "','" + SUMPRICE  + "','" + Price + "','" + tt + "','" + barcode + "','" + ID + "','" + Qua + "','" + price_a + "','" + NUMF + "','" + DOW + "')";
            OleDbCommand cm = new OleDbCommand();


            cm.Connection = cn;
            cm.CommandText = insert_query;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }



        public void show4(DataTable datatable)
        {

            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            cn.Open();
            OleDbCommand cm = new OleDbCommand();
            string query = "Select * from ARGOSTA4";
            cm.CommandText = query;
            cm.Connection = cn;
            OleDbDataAdapter Oracldata = new OleDbDataAdapter(cm);
            Oracldata.Fill(datatable);
            cn.Close();



        }
        public void Delete4()
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "DELETE from [ARGOSTA4]";
            OleDbCommand cm = new OleDbCommand(insert_query, cn);
           // cm.Parameters.AddWithValue("?", "1");
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }
        public void insert4(string tt, string name, string Price, String Qua, String price_a, String barcode = "0", String NUMF = "0", string DOW = "Na/N", string SUMPRICE = "0")
        {
            

            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = ConnectionString(namae, pasas);
            string insert_query = "INSERT INTO ARGOSTA4 (NAME,NAME2,PRICE,DAT,BARCODE,ID,QUANTITY,PRICE_A,NUMF,DOW) VALUES ('" + name + "','" + SUMPRICE + "','" + Price + "','" + tt + "','" + barcode + "','" + "1" + "','" + Qua + "','" + price_a + "','" + NUMF + "','" + DOW + "')";
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = insert_query;
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

        }


    }
}



    
        


    












