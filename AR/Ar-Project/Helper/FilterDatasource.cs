using System.Linq;
using System.Data;
namespace Ar_Project
{

    public static class FilterDatasource
    {
     
        public static DataTable data { get; set; }
        public static bool IsdoneOnly { get; set; } = true;
        public static DataTable FilterDataSource()
        {
            if (data == null)
                throw new System.Exception("DataTable At FilterDataSource is null or empty");
            var datasource = new DataTable();
            
            datasource.Columns.Add("ID");
            datasource.Columns.Add("NAME");
            datasource.Columns.Add("BARCODE");
            datasource.Columns.Add("QUANTITY");
            datasource.Columns.Add("PRICE");
            datasource.Columns.Add("PRICE_A");
            datasource.Columns.Add("Dis");
            datasource.Columns.Add("Price_F");
            datasource.Columns.Add("DAT");

            DataRow datarow;
            foreach (DataRow item in data.Rows)
            {
                if (int.Parse(item.Field<string>("QUANTITY")) == 0 || item.Field<string>("QUANTITY") == "-")
                {
                    datarow = datasource.NewRow();
                    datarow["ID"] = item.Field<string>("ID");
                    datarow["NAME"] = item.Field<string>("NAME");
                    datarow["BARCODE"] = item.Field<string>("BARCODE");
                    datarow["QUANTITY"] = item.Field<string>("QUANTITY");
                    datarow["PRICE"] = item.Field<string>("PRICE");
                    datarow["PRICE_A"] = item.Field<string>("PRICE_A");
                    datarow["Dis"] = item.Field<string>("Dis");
                    datarow["Price_F"] = item.Field<string>("Price_F");
                    datarow["DAT"] = item.Field<string>("DAT");
                    datasource.Rows.Add(datarow);
                }

            }





            return datasource;

        }
    }
}
