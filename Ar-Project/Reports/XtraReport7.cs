using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

namespace Ar_Project.Reports
{
    public partial class XtraReport7 : DevExpress.XtraReports.UI.XtraReport
    {
        void GetPrice()
        {
            double result = 0;
            double result1 = 0;
            var result_ = new List<double>();
            DataTable dt = new DataTable();
            var acc = new Assest.OrcDataAcess();
            acc.Show(dt);
            var Price = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
               // Price.Add(item.Field<string>("Price_F").Replace("SAR",""));
               // result_.Add(double.Parse(item.Field<string>("Price_F").Replace("SAR", "")));
                result += double.Parse(item.Field<string>("PRICE").Replace("SAR ", ""));
                result1 += double.Parse(item.Field<string>("PRICE_A").Replace("SAR ", ""));


            }
            T1.Text = result.ToString("N0") + "ر.س";
            xrTableCell1.Text = result1.ToString("N0") + "ر.س";
        }


        public XtraReport7()
        {
            InitializeComponent();
            GetPrice();


        }

    }
}
