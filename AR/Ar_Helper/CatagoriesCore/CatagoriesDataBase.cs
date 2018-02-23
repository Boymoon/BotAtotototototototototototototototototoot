using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper.CatagoriesCore
{
   public  class CatagoriesDataBase
    {
        protected  string connectiongStrings = $"Data Source=" + System.Windows.Forms.Application.StartupPath + "\\dbPascal.db;Version=3;";
        
        public void Show(DataTable data)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectiongStrings;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand();
            string query = "Select * from Catagories";
            cm.CommandText = query;
            cm.Connection = cn;
            SQLiteDataAdapter Oracldata = new SQLiteDataAdapter(cm);
            Oracldata.Fill(data);

            cn.Close();
        }
     


       
        
    }
}
