using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Ar_Project
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        string GetPrice()
        {
            DataTable a = new DataTable();
            var Getdt = new Assest.OrcDataAcess();
            Getdt.show3(a);
            string result = "";
            double price = 0;
            foreach (DataRow item in a.Rows)
            {
                price += double.Parse(item.Field<string>("PRICE").Replace("SAR ", ""));
            }
            result = price.ToString("N0") + "ر.س";
            return result;

        }
        string GetPricea()
        {
            DataTable a = new DataTable();
            var Getdt = new Assest.OrcDataAcess();
            Getdt.show3(a);
            string result = "";
            double price = 0;
            foreach (DataRow item in a.Rows)
            {
                price += double.Parse(item.Field<string>("PRICE_A").Replace("SAR ", ""));
            }
            result = price.ToString("N0") + "ر.س";
            return result;

        }
        public XtraReport1()
        {
            InitializeComponent();
            xrTableCell15.Text = GetPrice();
            xrTableCell6.Text = GetPricea();

        }

        private void BottomMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
