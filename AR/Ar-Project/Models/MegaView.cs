using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace Ar_Project
{
   public class MegaView
    {
       public DataTable GetAllItemsHasSold()
        {
            var Datatable = new DataTable();//target DataTable
            #region Columns
            Datatable.Columns.Add("ID", typeof(string));
            Datatable.Columns.Add("NAME", typeof(string));
            Datatable.Columns.Add("PRICE", typeof(string));
            Datatable.Columns.Add("DAT", typeof(string));
            Datatable.Columns.Add("discounts", typeof(string));
            Datatable.Columns.Add("datrec", typeof(string));
            Datatable.Columns.Add("conprou", typeof(string));
            Datatable.Columns.Add("typeprou", typeof(string));
            Datatable.Columns.Add("isdone",typeof(Int64));
            #endregion
            var datatable = new DataTable();
            var HData = new ModelMega();
            HData.show(datatable);
            foreach (DataRow item in datatable.Rows)
            {
                if (item.Field<Int64>("isdone")==-1)
                {
                    Datatable.Rows.Add
                  (item.Field<String>("ID"),
                  item.Field<String>("NAME"),
                  item.Field<String>("PRICE"),
                  item.Field<String>("DAT"),
                  item.Field<String>("discounts"),
                  item.Field<String>("datrec"),
                  item.Field<String>("conprou"),
                  item.Field<String>("typeprou"),
                  -1
                  );
                }
            }
            return Datatable;
              
            
        }
        public DataTable GetAllItemsHasSold2()
        {
            var Datatable = new DataTable();//target DataTable
            #region Columns
            Datatable.Columns.Add("ID", typeof(string));
            Datatable.Columns.Add("NAME", typeof(string));
            Datatable.Columns.Add("PRICE", typeof(string));
            Datatable.Columns.Add("DAT", typeof(string));
            Datatable.Columns.Add("discounts", typeof(string));
            Datatable.Columns.Add("datrec", typeof(string));
            Datatable.Columns.Add("conprou", typeof(string));
            Datatable.Columns.Add("typeprou", typeof(string));
            Datatable.Columns.Add("isdone", typeof(bool));
            #endregion
            var datatable = new DataTable();
            var HData = new ModelMega();
            HData.show1(datatable);
            foreach (DataRow item in datatable.Rows)
            {
                if (item.Field<Int64>("isdone")==-1)
                {
                    Datatable.Rows.Add
                  (item.Field<String>("ID"),
                  item.Field<String>("NAME"),
                  item.Field<String>("PRICE"),
                  item.Field<String>("DAT"),
                  item.Field<String>("discounts"),
                  item.Field<String>("datrec"),
                  item.Field<String>("conprou"),
                  item.Field<String>("typeprou"),
                  -1
                  );
                }
            }
            return Datatable;


        }

    }
}
