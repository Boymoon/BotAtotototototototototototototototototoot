using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

namespace Ar_Project.Reports
{
    public partial class XtraReport8 : DevExpress.XtraReports.UI.XtraReport
    {
        private void GetInvoice()
        {
            DataTable fff = new DataTable();
            var orcc = new Assest.OrcDataAcess();
            orcc.show3(fff);
            var list = new List<string>();
            int result = 0;
            foreach (DataRow R in fff.Rows)
            {
                //list.Add(R.Field<string>("NUMF"));
                result = int.Parse(R.Field<string>("NUMF"));
            }
            result += 1;
            xrLabel11.Text = result.ToString();


        }
        public XtraReport8()
        {
            InitializeComponent();
            var a = new ReportHelper(); xrLabel7.Text = a.SumPrice();
            xrLabel9.Text = DateTime.Now.ToString();
            GetInvoice();
        }

    }
}
