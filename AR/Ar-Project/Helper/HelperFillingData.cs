using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Ar_Project
{
    public static class HelperFillingData
    {
        public static void FillData(DevExpress.Xpf.Grid.GridControl GC)
        {
            var helper = new HelperData<Coustomer>();
            var datatable = new System.Data.DataTable();
            var GetData = new Assest.OrcDataAcess();
            GetData.Show(datatable);
            foreach (System.Data.DataRow item in datatable.Rows)
            {
                helper.Fill().Add(new Coustomer()
                {
                    NAME = item.Field<string>("NAME"),
                    BARCODE = item.Field<string>("BARCODE"),
                    DAT = item.Field<string>("DAT"),
                    Price_F = item.Field<string>("Price_F"),
                    Dis = item.Field<string>("Dis"),
                    ID = item.Field<string>("ID"),
                    PRICE = item.Field<string>("PRICE"),
                    PRICE_A = item.Field<string>("PRICE_A"),
                    QUANTITY = item.Field<string>("QUANTITY")

                });
            }
            GC.ItemsSource.Equals(helper.Fill());
           
        }
    }
}
